namespace RainAlert.WeatherForecast.Services;

public class WeatherForecastOptions
{
    public string? ApiBaseAddress { get; set; } = "https://atlas.microsoft.com/search";
    public string ApiVersion { get; set; } = "1.0";
    public string ApiKey { get; set; } = string.Empty;
    public string ClientId { get; set; } = string.Empty;
}
