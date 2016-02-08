namespace VisionsInCode.Foundation.Realtime.Repositories
{
  using System;
  using System.Collections.Generic;
  using System.Configuration;
  using System.Threading.Tasks;
  using MongoDB.Bson;
  using MongoDB.Driver;
  using VisionsInCode.Foundation.Realtime.Infrastructure;
  using VisionsInCode.Foundation.Realtime.Models;

  public class RealtimeVisitorRepository : IRealtimeVisitorRepository
  {
    
    private readonly IMongoCollection<RealtimeVisitor> realtimeVisitorCollection;
   
  
    public RealtimeVisitorRepository() 
    {
      realtimeVisitorCollection = GetCollection<RealtimeVisitor>(ConfigurationManager.ConnectionStrings[Constants.Realtime.DatabaseName].ConnectionString, Constants.Realtime.CollectionNames.RealtimeVisitor);
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

    public async Task<RealtimeVisitor> Get(IHubContextService hubContextService)
    {
      return await realtimeVisitorCollection.Find(visitor => visitor.ContactId == hubContextService.ContactId).FirstOrDefaultAsync();
    }


    public async Task<bool> AddConnection(IHubContextService hubContextService)
    {

      FilterDefinition<RealtimeVisitor> filter = GetContactIdFilter(hubContextService.ContactId);

      UpdateDefinition<RealtimeVisitor> update = Builders<RealtimeVisitor>.Update.Push(user => user.RealtimeConnections, new RealtimeConnection()
      {
        ConnectionId = hubContextService.ConnectionId,
        SessionId = hubContextService.SessionId,
        ConnectedAt = DateTime.Now,
        UserAgent = hubContextService.Headers,
        GeoCoordinates = new GeoJson() {Type = "Point", Coordinates = null}
      });


      return await Update(filter, update);
    }



    public async Task<bool> UpdateGeoLocation(IHubContextService hubContextService, GeoCoordinate? geoCoordinate)
    {
      if (!geoCoordinate.HasValue)
        return false;

      FilterDefinition<RealtimeVisitor> filter = GetContactIdFilter(hubContextService.ContactId);

      UpdateDefinition<RealtimeVisitor> update = Builders<RealtimeVisitor>.Update.Set("RealtimeMetaData.loc.Coordinates",
        new BsonArray {geoCoordinate.Value.Latitude, geoCoordinate.Value.Longitude});


      return await Update(filter, update);
    }



    public async Task<bool> UpdateGeoLocationOnConnection(IHubContextService hubContextService, int indexOfRealtimeConnection, GeoCoordinate? geoCoordinate)
    {
      if (!geoCoordinate.HasValue)
        return false;

      FilterDefinition<RealtimeVisitor> filter = GetContactIdFilter(hubContextService.ContactId);

      UpdateDefinition<RealtimeVisitor> update = Builders<RealtimeVisitor>.Update.Set(
        $"RealtimeConnections.{indexOfRealtimeConnection}.loc.Coordinates",
        new BsonArray {geoCoordinate.Value.Latitude, geoCoordinate.Value.Longitude});


      return await Update(filter, update);
    }



    public async Task<bool> RemoveConnection(IHubContextService hubContextService)
    {

      UpdateDefinition<RealtimeVisitor> updateFilter = Builders<RealtimeVisitor>.Update.PullFilter(p => p.RealtimeConnections,
        r => r.ConnectionId == hubContextService.ConnectionId);

      UpdateResult updateResult = await
        realtimeVisitorCollection.UpdateOneAsync(
          user => user.ContactId == hubContextService.ContactId, updateFilter);

      return updateResult.IsAcknowledged;
    }


    public async Task<bool> UpdateMetaData(IHubContextService hubContextService, VisitorDataContainer metaDataContainer)
    {


      FilterDefinition<RealtimeVisitor> filter = GetContactIdFilter(hubContextService.ContactId);

      UpdateDefinition<RealtimeVisitor> update = Builders<RealtimeVisitor>.Update.Set(user => user.RealtimeMetaData.MetaData,
        metaDataContainer.Container)
        .Set(user => user.RealtimeMetaData.LastUpdateDate,
          DateTime.UtcNow);


      return await Update(filter, update);

    }


    public async Task<RealtimeVisitor> Create(IHubContextService hubContextService, VisitorDataContainer visitorDataContainer)
    {
      RealtimeVisitor realTimeUser = new RealtimeVisitor()
      {
        ContactId = hubContextService.ContactId,
        CreatedDate = DateTime.UtcNow,
        RealtimeConnections = new List<RealtimeConnection>()
        {
          new RealtimeConnection()
          {
            ConnectionId = hubContextService.ConnectionId,
            SessionId = hubContextService.SessionId,
            ConnectedAt = DateTime.UtcNow,
            UserAgent = hubContextService.Headers,
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