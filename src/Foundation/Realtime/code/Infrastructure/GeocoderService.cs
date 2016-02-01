
namespace VisionsInCode.Foundation.Realtime.Infrastructure
{
  using System.Collections.Generic;
  using System.Linq;
  using Geocoding;
  using Geocoding.Google;
  using VisionsInCode.Foundation.Realtime.Models;

  public class GeocoderService : IGeocoderService
  {
    private readonly IGeocoder geocoder;

    public GeocoderService()
    {
      geocoder = new GoogleGeocoder();
    }

    public string GetFormattedGeoLocationData(GeoCoordinate? geoCoordinate)
    {
      if (!geoCoordinate.HasValue)
        return string.Empty;

      
      IEnumerable<Address> geoData = geocoder.ReverseGeocode(geoCoordinate.Value.Latitude, geoCoordinate.Value.Longitude);

      return geoData.First().FormattedAddress;
    }
  }
}