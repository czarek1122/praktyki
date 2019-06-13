using System;
using System.Collections.Generic;
using System.Text;

namespace Eastbot.Objects
{
    public class Description
    {
        public Description()
        {
        }

        public Description(int weatherDescriptionId, string weatherDescriptionMain, string weatherDescriptionDescription, string weatherDescriptionIcon)
        {
            WeatherDescriptionId = weatherDescriptionId;
            WeatherDescriptionMain = weatherDescriptionMain;
            WeatherDescriptionDescription = weatherDescriptionDescription;
            WeatherDescriptionIcon = weatherDescriptionIcon;
        }

        [Newtonsoft.Json.JsonProperty(PropertyName = "id")]
        public int WeatherDescriptionId { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "main")]
        public string WeatherDescriptionMain { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "description")]
        public string WeatherDescriptionDescription { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "icon")]
        public string WeatherDescriptionIcon { get; set; }
    }
}
