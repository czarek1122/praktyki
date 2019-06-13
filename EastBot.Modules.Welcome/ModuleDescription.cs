using EastBot.Core.Interfaces;
using EastBot.Core.Object;
using System;
using System.Collections.Generic;
using Unity;

namespace EastBot.Modules.Welcome
{
    public class ModuleDescription : IPlugin
    {
        public List<CommandHelpDescription> CommandHelpDescription
        {
            get
            {
                return new List<CommandHelpDescription>
                {
                    //new CommandHelpDescription("Translate", "  Komunikator wysyła w odpowiedzi przetłumaczony tekst z języka Polskiego na język Angielski."),
                    // new CommandHelpDescription("Translate ", "  Komunikator wysyła w odpowiedzi te")
                };
            }
        }

        public void Register(IUnityContainer unityContainer)
        {
            //Tak ma działać rejestracja eventów, tak zarejestrowany delegat wykona się codziennie o 8 (o ile będzie odpalona aplikacja)
            IOnTimeEventRepository registration = unityContainer.Resolve<IOnTimeEventRepository>();

            registration.RegisterHandler(MethodWillRunAtEight, new System.TimeSpan(8, 00, 00));
        }

        public void MethodWillRunAtEight()
        {
            Console.WriteLine("testy");
        }
    }
}
