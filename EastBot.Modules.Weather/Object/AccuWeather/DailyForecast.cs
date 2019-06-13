using System;
using System.Collections.Generic;
using System.Text;

namespace EastBot.Modules.Weather.Object.AccuWeather
{
    public class DailyForecast
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "Day")]
        public DayNight Day { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "Night")]
        public DayNight Night { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "Sun")]
        public Sun Sun { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "Temperature")]
        public Temperature Temperature { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "RealFeelTemperature")]
        public RealFeelTemperature RealFeelTemperature { get; set; }
    }
}
