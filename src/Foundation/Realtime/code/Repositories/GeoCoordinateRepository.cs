namespace VisionsInCode.Foundation.Realtime.Repositories
{
  using System.Collections.Generic;
  using System.Globalization;
  using System.Linq;
  using VisionsInCode.Foundation.Realtime.Models;

  public class GeoCoordinateRepository : IGeoCoordinateRepository
  {

    public GeoCoordinate? Get(string latitude, string longitude)
    {
      if (string.IsNullOrWhiteSpace(latitude) || string.IsNullOrWhiteSpace(longitude))
        return null;


      string coordinates = string.Concat(latitude, ",", longitude);
      return Get(coordinates);

    }

    public GeoCoordinate? Get(double latitude, double longitude)
    {

      return new GeoCoordinate(latitude, longitude);
    }

    public GeoCoordinate? Get(string coordinates)
    {
      if (string.IsNullOrWhiteSpace(coordinates))
        return null;

      string[] coordinateArray = coordinates.Split(',');

      if (coordinateArray.Length == 0)
        return null;

      if (string.IsNullOrWhiteSpace(coordinateArray[0]) || string.IsNullOrWhiteSpace(coordinateArray[1]))
        return null;

      return new GeoCoordinate(double.Parse(coordinateArray[0], NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture), double.Parse(coordinateArray[1], NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture));

    }

    public IEnumerable<GeoCoordinate?> Get(IEnumerable<string> manyCoordinates)
    {
      return manyCoordinates.Select(Get);
    }
  }
}