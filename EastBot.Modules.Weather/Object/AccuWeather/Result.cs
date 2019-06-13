using System;
using System.Collections.Generic;
using System.Text;

namespace EastBot.Modules.Weather.Object.AccuWeather
{
    public class Result
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "Headline")]
        public HeadLine Headline { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "DailyForecasts")]
        public List<DailyForecast> DailyForecasts { get; set; }
    }
}
