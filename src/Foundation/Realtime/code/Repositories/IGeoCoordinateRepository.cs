namespace VisionsInCode.Foundation.Realtime.Repositories
{
  using System.Collections.Generic;
  using VisionsInCode.Foundation.Realtime.Models;

  public interface IGeoCoordinateRepository
  {
    GeoCoordinate? Get(string latitude, string longitude);
    GeoCoordinate? Get(double latitude, double longitude);
    GeoCoordinate? Get(string coordinates);
    IEnumerable<GeoCoordinate?> Get(IEnumerable<string> manyCoordinates);
  }
}
