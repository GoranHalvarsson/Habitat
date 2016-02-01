namespace VisionsInCode.Foundation.Realtime.Models
{
  using System;
  using System.Collections.Generic;
  using MongoDB.Bson.Serialization.Attributes;

  public class RealtimeMetaData
  {
    public Dictionary<string, string> MetaData { get; set; }

    [BsonElement("loc")]
    public GeoJson GeoCoordinates { get; set; }

    public DateTime LastUpdateDate { get; set; }
  }
}