namespace VisionsInCode.Foundation.Realtime.Infrastructure
{
  using VisionsInCode.Foundation.Realtime.Models;

  public interface IGeocoderService
  {
    string GetFormattedGeoLocationData(GeoCoordinate? geoCoordinate);
  }
}