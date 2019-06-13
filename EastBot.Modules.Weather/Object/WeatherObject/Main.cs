using System;
using System.Collections.Generic;
using System.Text;

namespace Eastbot.Objects
{
    public class Main
    {
        public Main()
        {
        }

        public Main(double temperature, double pressure, double humidity, double temperatureMin, double temperatureMax)
        {
            Temperature = temperature;
            Pressure = pressure;
            Humidity = humidity;
            TemperatureMin = temperatureMin;
            TemperatureMax = temperatureMax;
        }

        [Newtonsoft.Json.JsonProperty(PropertyName = "temp")]
        public double Temperature { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "pressure")]
        public double Pressure { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "humidity")]
        public double Humidity { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "temp_min")]
        public double TemperatureMin { get; set; }
        [Newtonsoft.Json.JsonProperty(PropertyName = "temp_max")]
        public double TemperatureMax { get; set; }


        
    }
}
