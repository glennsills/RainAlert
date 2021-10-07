using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainAlert.WeatherForecast.Services;

public class GeocodeResults
{
    public Summary? summary { get; set; }
    public Result[] results { get; set; } = new Result[0];
}

public class Summary
{
    public string? query { get; set; }
    public string? queryType { get; set; }
    public int queryTime { get; set; }
    public int numResults { get; set; }
    public int offset { get; set; }
    public int totalResults { get; set; }
    public int fuzzyLevel { get; set; }
}

public class Result
{
    public string? type { get; set; }
    public string? id { get; set; }
    public float score { get; set; }
    public string? entityType { get; set; }
    public Address? address { get; set; }
    public Position? position { get; set; }
    public Viewport? viewport { get; set; }
    public Boundingbox? boundingBox { get; set; }
    public Datasources? dataSources { get; set; }
}

public class Address
{
    public string municipality { get; set; } = String.Empty;
    public string countrySecondarySubdivision { get; set; } = String.Empty;
    public string countrySubdivision { get; set; } = String.Empty;
    public string countrySubdivisionName { get; set; } = String.Empty;
    public string postalCode { get; set; } = String.Empty;
    public string postalName { get; set; } = String.Empty;
    public string countryCode { get; set; } = String.Empty;
    public string country { get; set; } = String.Empty;
    public string countryCodeISO3 { get; set; } = String.Empty;
    public string freeformAddress { get; set; } = String.Empty;
    public string streetName { get; set; } = String.Empty;
    public string extendedPostalCode { get; set; } = String.Empty;
    public string localName { get; set; } = String.Empty;
}

public class Position
{
    public float lat { get; set; } = -1.0f;
    public float lon { get; set; } = -1.0f;
}

public class Viewport
{
    public Topleftpoint? topLeftPoint { get; set; }
    public Btmrightpoint? btmRightPoint { get; set; }
}

public class Topleftpoint
{
    public float lat { get; set; } = -1.0f;
    public float lon { get; set; } = -1.0f;
}

public class Btmrightpoint
{
    public float lat { get; set; } = -1.0f;
    public float lon { get; set; } = -1.0f;
}

public class Boundingbox
{
    public Topleftpoint1? topLeftPoint { get; set; }
    public Btmrightpoint1? btmRightPoint { get; set; }
}

public class Topleftpoint1
{
    public float lat { get; set; } = -1.0f;
    public float lon { get; set; } = -1.0f;
}

public class Btmrightpoint1
{
    public float lat { get; set; } = -1.0f;
    public float lon { get; set; } = -1.0f;
}

public class Datasources
{
    public Geometry? geometry { get; set; }
}

public class Geometry
{
    public string id { get; set; } = string.Empty;
}

