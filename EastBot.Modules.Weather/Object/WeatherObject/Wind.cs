using System;
using System.Collections.Generic;
using System.Text;

namespace Eastbot.Objects
{
    public class Wind
    {
        public Wind()
        {
        }

        public Wind(double windSpeed)
        {
            WindSpeed = windSpeed;
        }

        [Newtonsoft.Json.JsonProperty(PropertyName = "speed")]
        public double WindSpeed { get; set; }
    }
}
