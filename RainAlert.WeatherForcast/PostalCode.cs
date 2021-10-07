namespace RainAlert.WeatherForecast
{
    public record PostalCode
    {
        public PostalCode (string countryCode, string code)
        {
            CountryCode = countryCode;
            Code = code;
        }
        public string Code { get; init; }
        public string CountryCode { get; init; }

        public static implicit operator string(PostalCode postalCode) => postalCode.Code;

        public override string ToString() => $"{Code}";

        public Location? Location { get; set;  }

        public static PostalCode Empty => new PostalCode(string.Empty, string.Empty);
    }
}