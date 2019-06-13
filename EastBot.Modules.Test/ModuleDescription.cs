using EastBot.Core.Interfaces;
using EastBot.Core.Object;
using EastBot.Modules.Test.ActionHandlers;
using System.Collections.Generic;
using Unity;

namespace EastBot.Modules.Test
{
    public class ModuleDescription : IPlugin
    {
        public List<CommandHelpDescription> CommandHelpDescription
        {
            get
            {
                return new List<CommandHelpDescription>
                {
                    new CommandHelpDescription("Przedstaw się", "  Komunikator wysyła przywitanie na danym kanale. Działa tylko na publicznych kanałach."),
                    new CommandHelpDescription("Ping", "  Komunikator odpowiada wiadomością \"pong\".")
                };
            }
        }

        public void Register(IUnityContainer unityContainer)
        {
            unityContainer.RegisterSingleton(typeof(IActionHandler), typeof(PingActionHandler), "PingModule");
        }
    }
}
