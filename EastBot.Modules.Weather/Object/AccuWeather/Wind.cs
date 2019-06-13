using System;
using System.Collections.Generic;
using System.Text;

namespace EastBot.Modules.Weather.Object.AccuWeather
{
    public class Wind
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "Speed")]
        public WindSpeed WindSpeed { get; set; }
    }
}
