namespace RainAlert.WeatherForecast.Services;

public interface IWeatherForecast
{
    Task<PostalCodeProbabilities> GetPrecipitationProbabilities(PostalCode postalCode);
}

