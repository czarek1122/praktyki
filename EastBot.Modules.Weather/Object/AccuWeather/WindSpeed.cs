using System;
using System.Collections.Generic;
using System.Text;

namespace EastBot.Modules.Weather.Object.AccuWeather
{
    public class WindSpeed
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "Value")]
        public double Value { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "Unit")]
        public string Unit { get; set; }
    }
}
