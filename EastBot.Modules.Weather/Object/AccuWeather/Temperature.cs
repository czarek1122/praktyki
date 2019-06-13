using System;
using System.Collections.Generic;
using System.Text;

namespace EastBot.Modules.Weather.Object.AccuWeather
{
    public class Temperature
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "Minimum")]
        public TemperatureMinimum TemperatureMinimum { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "Maximum")]
        public TemperatureMaximum TemperatureMaximum {get; set;}
    }
}
