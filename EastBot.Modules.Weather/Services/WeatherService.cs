using Eastbot.Objects;
using EastBot.Core.Interfaces;
using EastBot.Modules.Weather.Object.AccuWeather;
using System;
using System.Collections.Generic;
using System.Text;

namespace EastBot.Modules.Weather.Services
{
    public class WeatherService : IWeatherService
    {
        private IJsonHelper jsonHelper;

        public WeatherService(IJsonHelper jsonHelper)
        {
            this.jsonHelper = jsonHelper;
        }

        public string AccuResponse(string address)
        {
            Result temp = jsonHelper.SendGetRequest<Result>(address, null);

            if (temp == null)
            {
                return "**Coś poszło nie tak**";
            }

            string response = $"**Pogoda na dziś {DateTimeOffset.Now.Day}.{DateTimeOffset.Now.Month}. **\n" +
                $"**{temp.DailyForecasts[0].Day.Phrase}** \n" +
                $"**Temperatura:** {temp.DailyForecasts[0].Temperature.TemperatureMinimum.Value}{temp.DailyForecasts[0].Temperature.TemperatureMinimum.Unit}" +
                $"/{temp.DailyForecasts[0].Temperature.TemperatureMaximum.Value}{temp.DailyForecasts[0].Temperature.TemperatureMaximum.Unit} \n" +
                $"**Predkość wiatru:** {temp.DailyForecasts[0].Day.Wind.WindSpeed.Value}{temp.DailyForecasts[0].Day.Wind.WindSpeed.Unit} \n" +
                $"**Szansa opadów:** {temp.DailyForecasts[0].Day.PrecipitationProbability}% \n" +
                $"**Ilość opadów:** {temp.DailyForecasts[0].Day.TotalLiquid.Value}{temp.DailyForecasts[0].Day.TotalLiquid.Unit} \n" +
                $"**Zachmurzenie:** {temp.DailyForecasts[0].Day.ClaoudCover}% \n" +
                $"**Wschód/Zachód słońca:** {temp.DailyForecasts[0].Sun.GetSunRiseTime()} / {temp.DailyForecasts[0].Sun.GetSunSetTime()}\n" +
                $"**Więcej informacji pod** [linkiem]({temp.Headline.Link})\n";



            return response;
        }

        public string WeatherResponse(string address)
        {
            ResultClass weather = jsonHelper.SendGetRequest<ResultClass>(address, null);  //poniewaz samo Weather nie mozna

            if (weather == null)
            {
                return "Niepoprawne wartości";
            }
            else
            {
                string weatherResponse =
                    $"**Pogoda {weather.CityName}**: {weather.WeatherMain.Temperature}°C, {weather.WeatherDescriptionsList[0].WeatherDescriptionDescription} \n" +
                    $"**Ciśnienie**: {weather.WeatherMain.Pressure}, **Wilgotność**: {weather.WeatherMain.Humidity}%\n" +
                    $"**Zachmurzenie**: {weather.WeatherClauds.ClaudsValue}%\n" +
                    $"**Prędkość wiatru**: {weather.WeatherWind.WindSpeed * 3.6} km/h\n" +
                    $"**Ostatnia aktualizacja**: {weather.GetDate()}";

                return weatherResponse;
            }
        }
    }
}
