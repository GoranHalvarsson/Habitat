namespace VisionsInCode.Foundation.Realtime.Infrastructure
{
  using System;
  using System.Linq;
  using System.Net;
  using System.Threading.Tasks;
  using Microsoft.AspNet.SignalR;
  using Microsoft.AspNet.SignalR.Hubs;
  using MongoDB.Driver;
  using Newtonsoft.Json;
  using Sitecore.Analytics.Lookups;
  using VisionsInCode.Foundation.Realtime.Enums;
  using VisionsInCode.Foundation.Realtime.Models;
  using VisionsInCode.Foundation.Realtime.Repositories;

  [HubName("RealtimeConnector")]
  public class RealtimeHub : Hub
  {
    private readonly IRealtimeVisitorRepository realTimeUserRepository;
    private readonly IGeoCoordinateRepository geoCoordinateRepository;
    private readonly IHubContextService hubContextService;
    private readonly IGeocoderService geocoderService;

    public RealtimeHub(IRealtimeVisitorRepository realTimeUserRepository,
        IGeoCoordinateRepository geoCoordinateRepository,
        IHubContextService contextService,
        IGeocoderService geocoderService)
    {
      this.realTimeUserRepository = realTimeUserRepository;
      this.geoCoordinateRepository = geoCoordinateRepository;
      this.geocoderService = geocoderService;
      this.hubContextService = contextService;

    }

    public override Task OnConnected()
    {


      this.Clients.Caller.onWhoIs();

      //var name = Context
      //using (var db = new UserContext())
      //{
      //    var user = db.Users
      //        .Include(u => u.Connections)
      //        .SingleOrDefault(u => u.UserName == name);

      //    if (user == null)
      //    {
      //        user = new User
      //        {
      //            UserName = name,
      //            Connections = new List<Connection>()
      //        };
      //        db.Users.Add(user);
      //    }

      //    user.Connections.Add(new Connection
      //    {
      //        ConnectionID = Context.ConnectionId,
      //        UserAgent = Context.Request.Headers["User-Agent"],
      //        Connected = true
      //    });
      //    db.SaveChanges();
      //}



      return base.OnConnected();
    }

    public override async Task OnDisconnected(bool stopCalled)
    {
      //Client closed connection
      if (stopCalled)
      {

        await this.realTimeUserRepository.RemoveConnection(hubContextService.Resolve(Context));

        RealtimeVisitor realTimeVisitor = await this.realTimeUserRepository.Get(hubContextService.Resolve(Context));

        if (!realTimeVisitor.RealtimeConnections.Any())
        {
          realTimeVisitor.IsToBeDeleted = true;
          await this.realTimeUserRepository.Update(realTimeVisitor);
        }

      }

      //await CleanUpOldVisitors(10);

      await base.OnDisconnected(stopCalled);
    }

    private async Task CleanUpOldVisitors(int minutesOld)
    {
      await Task.Delay(new TimeSpan(0, minutesOld, 0));

      await this.realTimeUserRepository.Collection().Find(v => v.IsToBeDeleted).ForEachAsync((visitor, i) =>
      {
        if (visitor.RealtimeMetaData.LastUpdateDate.AddMinutes(minutesOld) >= DateTime.Now)
          return;

        this.realTimeUserRepository.Delete(visitor.Id);
        this.Clients.Group(Constants.Realtime.SubscriberGroups.Listeners).onVisitorHasLeft(visitor);
      });
    }

    private async Task NotifyListenersVisitorHasLeft(RealtimeVisitor visitor)
    {
      await this.Clients.Group(Constants.Realtime.SubscriberGroups.Listeners).onVisitorHasLeft(visitor);
    }

    public async Task<bool> AuthenticateListener()
    {

      //Authenticate sitecore user etc (using Context)
      IHubContextService hubService = this.hubContextService.Resolve(Context);

      if (!hubService.IsUserAuthenticated())
        return false;

      await SubscribeToChannel(Constants.Realtime.SubscriberGroups.Listeners);

      //await CleanUpOldVisitors(30);

      return true;
    }



    public async Task ShowAllVisitors()
    {
      //Authenticate sitecore user etc (using Context)
      IHubContextService hubService = this.hubContextService.Resolve(Context);

      if (!hubService.IsUserAuthenticated())
        return;

      await Task.Delay(new TimeSpan(0, 0, 0, 1));

      await this.realTimeUserRepository.Collection().Find(v => v.ContactId != null).ForEachAsync(async (visitor, i) =>
      {
        await Task.Delay(new TimeSpan(0, 0, 0, 2));

        await NotifyVisitor(visitor);
      });
    }

    private async Task NotifyVisitor(RealtimeVisitor visitor)
    {
      await this.Clients.Group(Constants.Realtime.SubscriberGroups.Listeners).onVisitorChanged(visitor);
    }

    public async Task SendClientMetaData(Object jsonData)
    {
      VisitorDataContainer visitorMetaDataContainer = JsonConvert.DeserializeObject<VisitorDataContainer>(jsonData.ToString());

      RealtimeVisitor realTimeVisitor = await this.realTimeUserRepository.Get(hubContextService.Resolve(Context)) ??
                                    await this.realTimeUserRepository.Create(hubContextService.Resolve(Context), visitorMetaDataContainer);


      if (realTimeVisitor.IsToBeDeleted && realTimeVisitor.RealtimeConnections.Any(
          conn => conn.SessionId == this.hubContextService.Resolve(Context).SessionId))
      {
        realTimeVisitor.IsToBeDeleted = false;
        await this.realTimeUserRepository.Update(realTimeVisitor);
      }


      await SubscribeToChannel(this.hubContextService.Resolve(Context).ContactId);


      await this.realTimeUserRepository.UpdateMetaData(hubContextService.Resolve(Context), visitorMetaDataContainer);


      if (realTimeVisitor.RealtimeConnections.All(conn =>
          conn.ConnectionId != this.hubContextService.Resolve(Context).ConnectionId))
        await this.realTimeUserRepository.AddConnection(hubContextService.Resolve(Context));

      //Get geodata
      this.Clients.Caller.onWhereIs();
    }


    public async Task SendClientLocationData(Object jsonData)
    {
      VisitorDataContainer visitorMetaDataContainer = JsonConvert.DeserializeObject<VisitorDataContainer>(jsonData.ToString());

      //If no coordinates from client, let's use the ip to get the geo location
      if (!visitorMetaDataContainer.ContainsParamkey(VisitorDataKeys.Coordinates))
        visitorMetaDataContainer = await SetGeoIpData(visitorMetaDataContainer);

      //No coordinates found
      if (!visitorMetaDataContainer.ContainsParamkey(VisitorDataKeys.Coordinates))
        return;

      GeoCoordinate? geoCoordinate =
          this.geoCoordinateRepository.Get(visitorMetaDataContainer.GetValueByKey(VisitorDataKeys.Coordinates));

      await this.realTimeUserRepository.UpdateGeoLocation(hubContextService.Resolve(Context), geoCoordinate);

      RealtimeVisitor realTimeUser = await this.realTimeUserRepository.Get(hubContextService.Resolve(Context));

      Int32 indexOfRealtimeConnection = realTimeUser.RealtimeConnections.ToList()
          .FindIndex(
              connection => connection.ConnectionId == this.hubContextService.Resolve(Context).ConnectionId);

      bool success =
          await
              this.realTimeUserRepository.UpdateGeoLocationOnConnection(hubContextService.Resolve(Context), indexOfRealtimeConnection,
                  geoCoordinate);

      if (!success)
        return;

      if (geoCoordinate.HasValue)
        this.Clients.Group(Constants.Realtime.SubscriberGroups.Listeners).onVisitorChanged(realTimeUser);

      string geoData = geocoderService.GetFormattedGeoLocationData(geoCoordinate);

      if (string.IsNullOrWhiteSpace(geoData))
        geoData = "No address";

      this.Clients.Caller.onSetClientData(geoData);

    }


    public async Task SubscribeToChannel(string channel)
    {
      await Groups.Add(Context.ConnectionId, channel);
    }

    public async Task SubscribeToVisitors()
    {
      await SubscribeToChannel(Constants.Realtime.SubscriberGroups.Visitors);
    }

    public async Task UnSubscribeChannel(string channel)
    {
      await Groups.Remove(Context.ConnectionId, channel);
    }

    public async Task GetClientData(string group)
    {
      await this.Clients.Group(group).onGetClientData();
    }

    public async Task GetClientDataFromVisitors()
    {
      await GetClientData(Constants.Realtime.SubscriberGroups.Visitors);
    }

    //public async Task NewContosoChatMessage(string name, string message)
    //{
    //    await Clients.Others.addContosoChatMessageToPage(data);
    //    Clients.Caller.notifyMessageSent();
    //}

    private async Task<VisitorDataContainer> SetGeoIpData(VisitorDataContainer visitorDataContainer)
    {
      //Get geoIp
      if (!visitorDataContainer.ContainsParamkey(VisitorDataKeys.IpAddress) ||
          visitorDataContainer.GetValueByKey(VisitorDataKeys.IpAddress).Contains("127"))
        return visitorDataContainer;


      GeoIpResult geoIpResult = null;

      await Task.Run(() =>
      {
        geoIpResult = Sitecore.Analytics.Lookups.GeoIpManager.GetGeoIpData(new GeoIpOptions()
        {
          Ip = IPAddress.Parse(visitorDataContainer.GetValueByKey(VisitorDataKeys.IpAddress)),
          MillisecondsTimeout = 10
        });
      });


      if (geoIpResult == null || geoIpResult.GeoIpData == null)
        return visitorDataContainer;

      visitorDataContainer.SetValueByKey(VisitorDataKeys.Coordinates, $"{geoIpResult.GeoIpData.Latitude},{geoIpResult.GeoIpData.Longitude}");
      visitorDataContainer.SetValueByKey(VisitorDataKeys.City, geoIpResult.GeoIpData.City);
      visitorDataContainer.SetValueByKey(VisitorDataKeys.Country, geoIpResult.GeoIpData.Country);

      return visitorDataContainer;
    }



  }
}