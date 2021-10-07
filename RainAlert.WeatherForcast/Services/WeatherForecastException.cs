using System.Runtime.Serialization;

namespace RainAlert.WeatherForecast.Services
{
    [Serializable]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    internal class WeatherForecastException : Exception
    {
        private Exception ex;


        public WeatherForecastException()
        {
        }

        public WeatherForecastException(Exception ex)
        {
            this.ex = ex;
        }

        public WeatherForecastException(string? message) : base(message)
        {
        }

        public WeatherForecastException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected WeatherForecastException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}