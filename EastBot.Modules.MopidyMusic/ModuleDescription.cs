using EastBot.Core.Interfaces;
using EastBot.Core.Object;
using EastBot.Modules.MopidyMusic.Interfaces;
using EastBot.Modules.MopidyMusic.Services;
using EastBot.Modules.MopidySecond.ActionHandlers;
using System.Collections.Generic;
using Unity;

namespace EastBot.Modules.MopidyMusic
{
    public class ModuleDescription : IPlugin
    {
        public List<CommandHelpDescription> CommandHelpDescription
        {
            get
            {
                return new List<CommandHelpDescription>
                {
                    new CommandHelpDescription("Muzyka", "  Zwraca aktualnie odtwarzany utwór oraz parametry odtwarzanej muzyki."),
                    new CommandHelpDescription("Muzyka następny", "  Rozpoczyna 30 sekundowe głosowanie nad zmianą utworu na następny. " +
                    "Jeżeli głosowanie trwa, zlicza głosy. Działa tylko na publicznych kanałach."),
                    new CommandHelpDescription("Muzyka stop", "  Wstrzymuj aktualnie odtwarzany utwór. Działa tylko na publicznych kanałach."),
                    new CommandHelpDescription("Muzyka play", "  Wznawia odtwarzanie utworu. Działa tylko na publicznych kanałach."),
                    new CommandHelpDescription("Muzyka ciszej", "  Zmniejsza głośność odtwarzanej muzyki."),
                    new CommandHelpDescription("Muzyka głośniej", "  Zwiększa głośność odtwarzanej muzyki.")
                };

            }
        }

        public void Register(IUnityContainer unityContainer)
        {
            unityContainer.RegisterSingleton(typeof(IMopidyService), typeof(MopidyService));
            unityContainer.RegisterSingleton(typeof(IActionHandler), typeof(MopidyActionHandler), "MopidyModule");
        }
    }
}
