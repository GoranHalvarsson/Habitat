
namespace VisionsInCode.Foundation.Realtime.Models
{
  using System;

  public struct GeoCoordinate
  {
    public double Latitude { get; }
    public double Longitude { get; }
    public double? Heading { get; }
    public double? Speed { get; }

    internal GeoCoordinate(double latitude, double longitude)
    {
      Latitude = latitude;
      Longitude = longitude;

      Heading = null;
      Speed = null;
    }

    internal GeoCoordinate(double latitude, double longitude, double? speed, double? heading)
        : this(latitude, longitude)
    {
      Heading = heading;
      Speed = speed;
    }


    public override string ToString()
    {
      return $"{Latitude},{Longitude}";
    }

    public override bool Equals(Object other)
    {
      return other is GeoCoordinate && Equals((GeoCoordinate)other);
    }

    public bool Equals(GeoCoordinate other)
    {
      return Math.Abs(Latitude - other.Latitude) < double.Epsilon && Math.Abs(Longitude - other.Longitude) < double.Epsilon;
    }

    public override int GetHashCode()
    {
      return Latitude.GetHashCode() ^ Longitude.GetHashCode();
    }




  }
}