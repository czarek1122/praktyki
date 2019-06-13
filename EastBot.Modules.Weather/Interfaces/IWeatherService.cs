using System;
using System.Collections.Generic;
using System.Text;

namespace EastBot.Core.Interfaces
{
    public interface IWeatherService
    {
        string WeatherResponse(string address);
        string AccuResponse(string address);
    }
}
