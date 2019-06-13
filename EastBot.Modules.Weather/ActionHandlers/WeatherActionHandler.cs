using Eastbot.Objects;
using EastBot.Core.Interfaces;
using EastBot.Modules.Weather.Object.AccuWeather;
using EastBot.Modules.Weather.Services;
using System;
using XmlConfig;

namespace EastBot.Modules.Weather.ActionHandlers
{
    public class WeatherActionHandler : IActionHandler
    {
        private IConnection connection;
        private IJsonHelper jsonHelper;
        private ISettingsProvider settingsProvider;
        private IWeatherService weatherService;
        private string appKey;
        private string weatherURL;
        private string accuKey;
        private string accuUrl;

        public WeatherActionHandler(IConnection connection, IJsonHelper jsonHelper, ISettingsProvider settingsProvider,
            IWeatherService weatherService)
        {
            this.connection = connection;
            this.jsonHelper = jsonHelper;
            this.settingsProvider = settingsProvider;
            this.weatherService = weatherService;
            appKey = settingsProvider.GetString("Weather", "APPKey");
            weatherURL = settingsProvider.GetString("Weather", "APIUrl");
            accuKey = settingsProvider.GetString("AccuWeather", "APPKey");
            accuUrl = settingsProvider.GetString("AccuWeather", "APPUrl");
        }

        public bool HandleRequest(Post message)
        {
            if (message.Message.StartsWith("pogoda dziś", StringComparison.InvariantCultureIgnoreCase))
            {
                var splited = message.Message.Split(new char[] { ' ' }, 3); // niepotrzebne aktualnie 
                string response = weatherService.AccuResponse($"{accuUrl}/forecasts/v1/daily/1day/264814?apikey={accuKey}&language=pl-pl&details=true&metric=true");
                connection.SendMessage(message.Channel, response);

                return true;
            }
            else if (message.Message.StartsWith("pogoda", StringComparison.InvariantCultureIgnoreCase))
            {
                var splited = message.Message.Split(new char[] { ' ' }, 2);
                

                if (splited.Length == 2)
                {
                    string response = weatherService.WeatherResponse($"{weatherURL}?q={splited[1]}&appid={appKey}&units=metric&lang=pl");
                    connection.SendMessage(message.Channel, response);
                }
                else
                {
                    string response = weatherService.WeatherResponse($"{weatherURL}?q=Siedlce&appid={appKey}&units=metric&lang=pl");
                    connection.SendMessage(message.Channel, response);
                }

                return true;
            }
            return false;
        }
    }
}
