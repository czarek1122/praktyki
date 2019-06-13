using EastBot.Core.Interfaces;
using EastBot.Core.Object;
using EastBot.Modules.Translator.ActionHandlers;
using System.Collections.Generic;
using Unity;

namespace EastBot.Modules.Translator
{
    public class ModuleDescription : IPlugin
    {
        public List<CommandHelpDescription> CommandHelpDescription
        {
            get
            {
                return new List<CommandHelpDescription>
                {
                   new CommandHelpDescription("Translate z do tekst", "  Komunikator wysyła w odpowiedzi przetłumaczony tekst z języka wskazanego na język docelowy." +
                   "W przypadku niepodania jezyków teskt zostanie przetłumaczony z języka polskiego na język angielski \n" +
                   "Przykład: translate pl en tekst do przetłumaczenia; translate tekst do przetłumaczenia"),
                   new CommandHelpDescription("Translate języki", "  Komunikator wysyła dostępne języki do tłumaczeń")
                };
            }
        }

        public void Register(IUnityContainer unityContainer)
        {
            unityContainer.RegisterSingleton(typeof(IActionHandler), typeof(TranslateActionHandlers), "TranslateModule");
        }
    }
}
