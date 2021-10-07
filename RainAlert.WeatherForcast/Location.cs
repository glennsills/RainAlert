using System.ComponentModel;

namespace RainAlert.WeatherForecast;

public record Location
{
    public Location(float latitude, float longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
    }

    [Description("The latitude of the position")] float Latitude { get; init; }
    [Description("The longitude of the position")] float Longitude { get; init; }

    public static implicit operator string(Location location)
    {
        return $"{location.Latitude:00.00000},{location.Longitude:00.00000}";
    }

    public override string ToString()
    {
        return $"{Latitude:00.00000},{Longitude:00.00000}";
    }
}
