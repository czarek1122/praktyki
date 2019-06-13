using EastBot.Core.Interfaces;
using EastBot.Core.Object;
using EastBot.Modules.Weather.ActionHandlers;
using EastBot.Modules.Weather.Services;
using System.Collections.Generic;
using Unity;

namespace EastBot.Modules.Weather
{
    public class ModuleDescription : IPlugin
    {
        public List<CommandHelpDescription> CommandHelpDescription
        {
            get
            {
                return new List<CommandHelpDescription>
                {
                    new CommandHelpDescription("Pogoda", "  Komunikator wypisuje aktualne dane pogodowe dla miasta Siedlce."),
                    new CommandHelpDescription("Pogoda miasto", "  Komunikator wypisuje aktualne dane pogodowe dla zadanego miasta.")
                };
            }
        }

        public void Register(IUnityContainer unityContainer)
        {
            unityContainer.RegisterSingleton(typeof(IWeatherService), typeof(WeatherService));
            unityContainer.RegisterSingleton(typeof(IActionHandler), typeof(WeatherActionHandler), "WeatherModule");
        }
    }
}
