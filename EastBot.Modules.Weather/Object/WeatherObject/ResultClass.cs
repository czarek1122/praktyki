using System;
using System.Collections.Generic;
using System.Text;

namespace Eastbot.Objects
{
    public class ResultClass
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "main")]
        public Main WeatherMain { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "wind")]
        public Wind WeatherWind { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "clouds")]
        public Clauds WeatherClauds { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "dt")]
        public long LastUpdate { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "name")]
        public string CityName { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "weather")]
        public List<Description> WeatherDescriptionsList { get; set; }
        public ResultClass()
        {
        }

        public ResultClass(Main weatherMain, Wind weatherWind, Clauds weatherClauds, long lastUpdate,
            string cityName, List<Description> weatherDescriptions)
        {
            WeatherMain = weatherMain;
            WeatherWind = weatherWind;
            WeatherClauds = weatherClauds;
            LastUpdate = lastUpdate;
            CityName = cityName;
            WeatherDescriptionsList = weatherDescriptions;
        }

        public DateTime GetDate()
        {
            System.DateTime dateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
            dateTime = dateTime.AddSeconds(LastUpdate);

            return dateTime;
        }

    }
}
