using System;
using System.Collections.Generic;
using System.Text;

namespace EastBot.Modules.Weather.Object.AccuWeather
{
    public class HeadLine
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "Text")]
        public string Text { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "Link")]
        public string Link { get; set; }
    }
}
