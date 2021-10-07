using System.ComponentModel;

namespace RainAlert.WeatherForecast
{
    public record PostalCodeProbabilities
    {
        public PostalCodeProbabilities(PostalCode postalCode, int rainProbability, int precipitationProbability, int snowProbability, int iceProbability)
        {
            PostalCode = postalCode;
            RainProbability = rainProbability;
            PrecipitationProbability = precipitationProbability;
            SnowProbability = snowProbability;
            IceProbability = iceProbability;
        }
        [Description("The postal code of the probability")] public PostalCode PostalCode { get; init; }
        [Description("The probability of rain as a percentage value")] public int RainProbability { get; init; }
        [Description("The probability of precipitation as a percentage value" )] public int PrecipitationProbability { get; init; }
        [Description("The probability of precipitation as a percentage value")] public int SnowProbability { get; init; }
        [Description("The probability of precipitation as a percentage value")] public int IceProbability { get; init; }

        public static PostalCodeProbabilities Empty => new PostalCodeProbabilities(new PostalCode("US", "00000"), -1, -1, -1, -1);
    }
}