using System;
using System.Collections.Generic;
using System.Text;

namespace EastBot.Modules.Weather.Object.AccuWeather
{
    public class Sun
    {
        [Newtonsoft.Json.JsonProperty(PropertyName = "EpochRise")]
        public long Rise { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "EpochSet")]
        public long Set { get; set; }

        public string GetSunRiseTime()
        {
            System.DateTime dateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
            dateTime = dateTime.AddSeconds(Rise);
            dateTime = dateTime.AddHours(2);

            return $"{dateTime.Hour}:{dateTime.Minute}";
        }

        public string GetSunSetTime()
        {
            System.DateTime dateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
            dateTime = dateTime.AddSeconds(Set);
            dateTime = dateTime.AddHours(2);

            return $"{dateTime.Hour}:{dateTime.Minute}";
        }
    }
}
