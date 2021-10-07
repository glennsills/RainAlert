using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("RainAlert.Tests")]
namespace RainAlert.WeatherForecast.Services;

public class ForecastService : IWeatherForecast
{
    private readonly WeatherForecastOptions _options;
    private readonly HttpClient _client;

    public ForecastService(IOptions<WeatherForecastOptions> options, HttpClient client)
    {
        _options = options.Value;
        _client = client;
        _client.BaseAddress = new Uri(uriString: _options.ApiBaseAddress!);
        _client.DefaultRequestHeaders.Add("x-ms-client-id", _options.ClientId);
    }
    public async Task<PostalCodeProbabilities> GetPrecipitationProbabilities(PostalCode postalCode)
    {
        try
        {
            var forecasts = await GetForecasts(postalCode);
            if (forecasts.forecasts.Length > 0)
            {
                var forecast = forecasts.forecasts[0];
                return new PostalCodeProbabilities(postalCode, forecast.rainProbability, forecast.precipitationProbability,
                    forecast.snowProbability, forecast.iceProbability);
            }
            else
            {
                return PostalCodeProbabilities.Empty;
            }
        }
        catch(Exception ex)
        {
            throw new WeatherForecastException(ex); 
        }
    }

    internal async Task<Forecasts> GetForecasts(PostalCode postalCode)
    {
        try
        {
            if (postalCode.Location == null)
            {
                postalCode = await LocatePostalCode(postalCode);
            }
            if (postalCode == PostalCode.Empty)
            {
                return Forecasts.Empty;
            }

            var path = $"weather/forecast/hourly/json?subscription-key={_options.ApiKey}&api-version={_options.ApiVersion}&query={postalCode.Location}&duration=12";

            var forecasts = await _client.GetFromJsonAsync<Forecasts>(path);
            if (forecasts == null)
            {
                forecasts = Forecasts.Empty; 
            }

            return forecasts;
        }
        catch (WeatherForecastException)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new WeatherForecastException(ex);
        }

    }

    internal async Task<PostalCode> LocatePostalCode(PostalCode postalCode)
    {

        var path = $"search/address/structured/json?subscription-key={_options.ApiKey}&api-version={_options.ApiVersion}&countryCode={postalCode.CountryCode}&postalCode={postalCode}";

        try
        {
            var result = await _client.GetFromJsonAsync<GeocodeResults>(path);
            var position = result?.results.FirstOrDefault(r => r.entityType == "PostalCodeArea")?.position;
            if ( position != null)
            {
                postalCode.Location = new Location(position.lat, position.lon);

            }     
            else
            {
                postalCode = PostalCode.Empty;
            }
        }
        catch (Exception ex)
        {
            throw new WeatherForecastException(ex);
        }
        return postalCode;
    }
}