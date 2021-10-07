using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using RainAlert.WeatherForecast;
using RainAlert.WeatherForecast.Services;
using Xunit;

namespace RainAlert.Tests.WeatherForecast;

public class WeatherForecastTests
{
    private IOptions<WeatherForecastOptions> _weatherForecastOptions;

    public WeatherForecastTests()
    {
        var configuration = new ConfigurationBuilder().AddUserSecrets<WeatherForecastTests>().Build();

        var weatherForecastOptions = new WeatherForecastOptions
        {
            ApiKey = configuration["WeatherForecastOptions:ApiKey"],
            ApiBaseAddress = configuration["WeatherForecastOptions:ApiBaseAddress"],
            ApiVersion = configuration["WeatherForecastOptions:ApiVersion"],
            ClientId = configuration["WeatherForecastOptions:ClientId"]

        };
        _weatherForecastOptions = Options.Create<WeatherForecastOptions>(weatherForecastOptions);
    }

    [Fact]
    public async Task ReturnsCorrectPosition()
    {
        var cut = new ForecastService(_weatherForecastOptions, new HttpClient());
        var postalCode = new PostalCode("US", "33760");
        var result = await cut.LocatePostalCode(postalCode);
        Assert.Equal("27.91275,-82.71522", result.Location!);
    }

    [Fact]
    public async Task GetForecastSucceeds()
    {
        var cut = new ForecastService(_weatherForecastOptions, new HttpClient());
        var postalCode = new PostalCode("US", "33760");
        var forecasts = await cut.GetForecasts(postalCode);
        Assert.True(forecasts.forecasts.Length > 0);
    }

    [Fact]
    public async Task GetRainProbabilityReturnsAValue()
    {
        var cut = new ForecastService(_weatherForecastOptions, new HttpClient());
        var postalCode = new PostalCode("US", "33760");
        var rainProbability = await cut.GetPrecipitationProbabilities(postalCode);
        Assert.NotNull(rainProbability);    
    }

    [Fact]
    public async Task GetRainProbabilityReturnsEmptyForInvalidZipcod()
    {
        var cut = new ForecastService(_weatherForecastOptions, new HttpClient());
        var postalCode = new PostalCode("US", "00000");
        var rainProbability = await cut.GetPrecipitationProbabilities(postalCode);
        Assert.Equal(PostalCodeProbabilities.Empty, rainProbability);
    }
}

