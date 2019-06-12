using EastBot.Core.Interfaces;
using EastBot.Core.Object;
using EastBot.Modules.Plejada.ActionHandlers;
using System;
using System.Collections.Generic;
using System.Text;
using Unity;

namespace EastBot.Modules.Plejada
{
    public class ModuleDescription : IPlugin
    {
        public List<CommandHelpDescription> CommandHelpDescription
        {
            get
            {
                return new List<CommandHelpDescription>
                {
                    //new CommandHelpDescription("Pogoda", "  Komunikator wypisuje aktualne dane pogodowe dla miasta Siedlce."),
                    //new CommandHelpDescription("Pogoda miasto", "  Komunikator wypisuje aktualne dane pogodowe dla zadanego miasta.")
                };
            }
        }

        public void Register(IUnityContainer unityContainer)
        {
            unityContainer.RegisterSingleton(typeof(IActionHandler), typeof(MenuActionHandler), "MenuModule");
        }
    }
}
