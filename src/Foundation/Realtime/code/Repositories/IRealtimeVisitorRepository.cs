namespace VisionsInCode.Foundation.Realtime.Repositories
{
  using System.Threading.Tasks;
  using Microsoft.AspNet.SignalR.Hubs;
  using MongoDB.Driver;
  using VisionsInCode.Foundation.Realtime.Infrastructure;
  using VisionsInCode.Foundation.Realtime.Models;

  public interface IRealtimeVisitorRepository
  {
    IMongoCollection<RealtimeVisitor> Collection();
    Task<RealtimeVisitor> Get(IHubContextService hubContextService);
    Task<RealtimeVisitor> Get(string id);
    Task<RealtimeVisitor> Create(IHubContextService hubContextService, VisitorDataContainer visitorDataContainer);
    Task<RealtimeVisitor> Update(RealtimeVisitor realTimeVisitor);
    Task<bool> Delete(string id);

    Task<bool> AddConnection(IHubContextService hubContextService);
    Task<bool> RemoveConnection(IHubContextService hubContextService);

    Task<bool> UpdateMetaData(IHubContextService hubContextService, VisitorDataContainer metaDataContainer);

    Task<bool> UpdateGeoLocation(IHubContextService hubContextService, GeoCoordinate? geoCoordinate);
    Task<bool> UpdateGeoLocationOnConnection(IHubContextService hubContextService, int indexOfRealtimeConnection, GeoCoordinate? geoCoordinate);
  }
}
