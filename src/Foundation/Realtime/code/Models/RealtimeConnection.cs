
namespace VisionsInCode.Foundation.Realtime.Models
{
  using System;
  using MongoDB.Bson.Serialization.Attributes;

  public class RealtimeConnection
  {
    public string ConnectionId { get; set; }
    
    public string UserAgent { get; set; }
    public DateTime ConnectedAt { get; set; }

    [BsonElement("loc")]
    public GeoJson GeoCoordinates { get; set; }

    public string SessionId { get; set; }
  }
}