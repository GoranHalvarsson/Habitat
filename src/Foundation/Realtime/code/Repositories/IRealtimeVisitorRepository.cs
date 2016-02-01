namespace VisionsInCode.Foundation.Realtime.Repositories
{
  using System.Threading.Tasks;
  using Microsoft.AspNet.SignalR.Hubs;
  using MongoDB.Driver;
  using VisionsInCode.Foundation.Realtime.Models;

  public interface IRealtimeVisitorRepository
  {
    IMongoCollection<RealtimeVisitor> Collection();
    Task<RealtimeVisitor> Get(HubCallerContext hubContext);
    Task<RealtimeVisitor> Get(string id);
    Task<RealtimeVisitor> Create(HubCallerContext hubContext, VisitorDataContainer visitorDataContainer);
    Task<RealtimeVisitor> Update(RealtimeVisitor realTimeVisitor);
    Task<bool> Delete(string id);

    Task<bool> AddConnection(HubCallerContext hubContext);
    Task<bool> RemoveConnection(HubCallerContext hubContext);

    Task<bool> UpdateMetaData(HubCallerContext hubContext, VisitorDataContainer metaDataContainer);

    Task<bool> UpdateGeoLocation(HubCallerContext hubContext, GeoCoordinate? geoCoordinate);
    Task<bool> UpdateGeoLocationOnConnection(HubCallerContext hubContext, int indexOfRealtimeConnection, GeoCoordinate? geoCoordinate);
  }
}
