using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RainAlert.WeatherForecast.Services
{
    public class Point
    {
        public Point (string value)
        {
            Value = value;
        }

        public string Value { get; private set; }
        public static Point FromLatLong(decimal latitude, decimal longitude)
        {
            return new Point($"{latitude:00.0000},{longitude:00.0000}");
        }
    }
}
