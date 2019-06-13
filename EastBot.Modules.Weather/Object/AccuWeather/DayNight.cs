using System;
using System.Collections.Generic;
using System.Text;

namespace EastBot.Modules.Weather.Object.AccuWeather
{
    public class DayNight
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "LongPhrase")]
        public string Phrase { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "Wind")]
        public Wind Wind { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "TotalLiquid")]
        public TotalLiquid TotalLiquid { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "HoursOfPrecipitation")]
        public string HoursOfPrecipitation { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "CloudCover")]
        public int ClaoudCover { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "PrecipitationProbability")]
        public int PrecipitationProbability { get; set; }
    }
}
