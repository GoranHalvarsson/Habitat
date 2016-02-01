namespace VisionsInCode.Foundation.Realtime.Repositories
{
  using System;
  using System.Collections.Generic;
  using System.Configuration;
  using System.Threading.Tasks;
  using Microsoft.AspNet.SignalR.Hubs;
  using MongoDB.Bson;
  using MongoDB.Driver;
  using VisionsInCode.Foundation.Realtime.Infrastructure;
  using VisionsInCode.Foundation.Realtime.Models;

  public class RealtimeVisitorRepository : IRealtimeVisitorRepository
  {
    internal const string CollectionName = "RealtimeVisitor";

    private readonly IMongoCollection<RealtimeVisitor> realtimeVisitorCollection;
    private readonly IHubContextService hubContextService;

    public RealtimeVisitorRepository(IHubContextService hubContextService)
    {
      realtimeVisitorCollection = GetCollection<RealtimeVisitor>(ConfigurationManager.ConnectionStrings["signalr"].ConnectionString, CollectionName);

      this.hubContextService = hubContextService;
    }

    public IMongoCollection<RealtimeVisitor> Collection()
    {
      return realtimeVisitorCollection;
    }

    //public async Task<IEnumerable<RealTimeVisitor>> GetAll()
    //{
    //    return await this._realTimeVisitorCollection. .ForeEchAsync(db => Console.Writeline(db["name"])); Find(v => !string.IsNullOrWhiteSpace(v.ContactId) ).ToListAsync();
    //}

    public async Task<RealtimeVisitor> Get(string id)
    {
      return await realtimeVisitorCollection.Find(visitor => visitor.Id == id).FirstOrDefaultAsync();
    }

    public async Task<RealtimeVisitor> Update(RealtimeVisitor realTimeVisitor)
    {
      return await realtimeVisitorCollection.FindOneAndUpdateAsync(Builders<RealtimeVisitor>.Filter.Eq(c => c.ContactId, realTimeVisitor.ContactId),
        Builders<RealtimeVisitor>.Update.Set(v => v.IsToBeDeleted, realTimeVisitor.IsToBeDeleted));
    }

    public async Task<RealtimeVisitor> Get(HubCallerContext hubContext)
    {
      return await realtimeVisitorCollection.Find(visitor => visitor.ContactId == this.hubContextService.Resolve(hubContext).ContactId).FirstOrDefaultAsync();
    }


    public async Task<bool> AddConnection(HubCallerContext hubContext)
    {

      FilterDefinition<RealtimeVisitor> filter = GetContactIdFilter(this.hubContextService.Resolve(hubContext).ContactId);

      UpdateDefinition<RealtimeVisitor> update = Builders<RealtimeVisitor>.Update.Push(user => user.RealtimeConnections, new RealtimeConnection()
      {
        ConnectionId = this.hubContextService.Resolve(hubContext).ConnectionId,
        SessionId = this.hubContextService.Resolve(hubContext).SessionId,
        ConnectedAt = DateTime.Now,
        UserAgent = this.hubContextService.Resolve(hubContext).Headers,
        GeoCoordinates = new GeoJson() {Type = "Point", Coordinates = null}
      });


      return await Update(filter, update);
    }



    public async Task<bool> UpdateGeoLocation(HubCallerContext hubContext, GeoCoordinate? geoCoordinate)
    {
      if (!geoCoordinate.HasValue)
        return false;

      FilterDefinition<RealtimeVisitor> filter = GetContactIdFilter(this.hubContextService.Resolve(hubContext).ContactId);

      UpdateDefinition<RealtimeVisitor> update = Builders<RealtimeVisitor>.Update.Set("RealtimeMetaData.loc.Coordinates",
        new BsonArray {geoCoordinate.Value.Latitude, geoCoordinate.Value.Longitude});


      return await Update(filter, update);
    }



    public async Task<bool> UpdateGeoLocationOnConnection(HubCallerContext hubContext, int indexOfRealtimeConnection, GeoCoordinate? geoCoordinate)
    {
      if (!geoCoordinate.HasValue)
        return false;

      FilterDefinition<RealtimeVisitor> filter = GetContactIdFilter(this.hubContextService.Resolve(hubContext).ContactId);

      UpdateDefinition<RealtimeVisitor> update = Builders<RealtimeVisitor>.Update.Set(
        String.Format("RealTimeConnections.{0}.loc.Coordinates", indexOfRealtimeConnection),
        new BsonArray {geoCoordinate.Value.Latitude, geoCoordinate.Value.Longitude});


      return await Update(filter, update);
    }



    public async Task<bool> RemoveConnection(HubCallerContext hubContext)
    {

      UpdateDefinition<RealtimeVisitor> updateFilter = Builders<RealtimeVisitor>.Update.PullFilter(p => p.RealtimeConnections,
        r => r.ConnectionId == this.hubContextService.Resolve(hubContext).ConnectionId);

      UpdateResult updateResult = await
        realtimeVisitorCollection.UpdateOneAsync(
          user => user.ContactId == this.hubContextService.Resolve(hubContext).ContactId, updateFilter);

      return updateResult.IsAcknowledged;
    }


    public async Task<bool> UpdateMetaData(HubCallerContext hubContext, VisitorDataContainer metaDataContainer)
    {


      FilterDefinition<RealtimeVisitor> filter = GetContactIdFilter(this.hubContextService.Resolve(hubContext).ContactId);

      UpdateDefinition<RealtimeVisitor> update = Builders<RealtimeVisitor>.Update.Set(user => user.RealtimeMetaData.MetaData,
        metaDataContainer.Container)
        .Set(user => user.RealtimeMetaData.LastUpdateDate,
          DateTime.UtcNow);


      return await Update(filter, update);

    }


    public async Task<RealtimeVisitor> Create(HubCallerContext hubContext, VisitorDataContainer visitorDataContainer)
    {
      RealtimeVisitor realTimeUser = new RealtimeVisitor()
      {
        ContactId = this.hubContextService.Resolve(hubContext).ContactId,
        CreatedDate = DateTime.UtcNow,
        RealtimeConnections = new List<RealtimeConnection>()
        {
          new RealtimeConnection()
          {
            ConnectionId = this.hubContextService.Resolve(hubContext).ConnectionId,
            SessionId = this.hubContextService.Resolve(hubContext).SessionId,
            ConnectedAt = DateTime.UtcNow,
            UserAgent = this.hubContextService.Resolve(hubContext).Headers,
            GeoCoordinates = new GeoJson() {Type = "point", Coordinates = new[] {0d, 0d}}
          }
        },
        RealtimeMetaData = new RealtimeMetaData()
        {
          MetaData = visitorDataContainer.Container,
          GeoCoordinates = new GeoJson() {Type = "point", Coordinates = new[] {0d, 0d}},
          LastUpdateDate = DateTime.UtcNow
        }
      };

      await realtimeVisitorCollection.InsertOneAsync(realTimeUser);


      return await Task.Run(() => realTimeUser);

    }

    public async Task<bool> Delete(string id)
    {
      DeleteResult deleteResult = await this.realtimeVisitorCollection.DeleteOneAsync(Builders<RealtimeVisitor>.Filter.Eq(v => v.Id, id));

      return deleteResult.IsAcknowledged;
    }

    private async Task<bool> Update(FilterDefinition<RealtimeVisitor> filter, UpdateDefinition<RealtimeVisitor> update)
    {
      UpdateResult result = await this.realtimeVisitorCollection.UpdateOneAsync(filter, update);

      return result.IsAcknowledged;

    }


   
    private FilterDefinition<RealtimeVisitor> GetContactIdFilter(string contactId)
    {
      return Builders<RealtimeVisitor>.Filter.Eq(c => c.ContactId, contactId);
    }


   
    private IMongoCollection<T> GetCollection<T>(string connectionString, string collectionName) where T : class
    {
      var url = new MongoUrl(connectionString);

      return new MongoClient(url).GetDatabase(url.DatabaseName).GetCollection<T>(collectionName);
    }
  }

}