namespace RainAlert.WeatherForecast.Services;

public class Forecasts
{
    public Forecast[] forecasts { get; set; } = new Forecast[0];
    public static Forecasts Empty { get => new Forecasts(); }
}

public class Forecast
{
    public DateTime date { get; set; }
    public int iconCode { get; set; }
    public string iconPhrase { get; set; } = string.Empty;
    public bool hasPrecipitation { get; set; }
    public bool isDaylight { get; set; }
    public Temperature? temperature { get; set; }
    public Realfeeltemperature? realFeelTemperature { get; set; }
    public Wetbulbtemperature? wetBulbTemperature { get; set; }
    public Dewpoint? dewPoint { get; set; }
    public Wind? wind { get; set; }
    public Windgust? windGust { get; set; }
    public int relativeHumidity { get; set; }
    public Visibility? visibility { get; set; }
    public int cloudCover { get; set; }
    public Ceiling? ceiling { get; set; }
    public int uvIndex { get; set; }
    public string uvIndexPhrase { get; set; } = string.Empty;
    public int precipitationProbability { get; set; }
    public int rainProbability { get; set; }
    public int snowProbability { get; set; }
    public int iceProbability { get; set; }
    public Totalliquid? totalLiquid { get; set; }
    public Rain? rain { get; set; }
    public Snow? snow { get; set; }
    public Ice? ice { get; set; }
}

public class TypedUnit
{
    public float? value { get; set; }
    public string? unit { get; set; }
    public int? unitType { get; set; }
}

public class Temperature : TypedUnit { };

public class Realfeeltemperature : TypedUnit { };

public class Wetbulbtemperature : TypedUnit { };

public class Dewpoint : TypedUnit { };


public class Wind
{
    public Direction? direction { get; set; }
    public Speed? speed { get; set; }
}

public class Direction
{
    public float degrees { get; set; }
    public string localizedDescription { get; set; } = string.Empty;
}

public class Speed : TypedUnit { };


public class Windgust
{
    public Speed1? speed { get; set; }
}

public class Speed1 : TypedUnit { };

public class Visibility : TypedUnit { };

public class Ceiling : TypedUnit { };

public class Totalliquid : TypedUnit { };

public class Rain : TypedUnit { };

public class Snow : TypedUnit { };

public class Ice : TypedUnit { };
