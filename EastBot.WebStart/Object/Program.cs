using Eastbot.Objects;
using EastBot.Core.Interfaces;
using EastBot.Core.Object;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Unity;
using XmlConfig;

namespace ConsoleApp3
{
    public class Program
    {
        private static IUnityContainer container;
        private static IConnection connection;
        private static ModuleLoader loader;

        public void StartIt()
        {
            container = ConfigureUnity();

            //Ładowanie modułów

            loader = container.Resolve<ModuleLoader>();

            loader.LoadAndRegisterModules();

            //Koniec ładowania modułów


            //LINQ !!!!!!
            int newChannelsCheck = 0;
            connection = container.Resolve<IConnection>();

            connection.Login();
            connection.GetAllTeamsForUser();
            connection.GetAllChannels();

            while (true)
            {
                newChannelsCheck++;
                Thread.Sleep(200);
                connection.CountAllUnreadMessage();

                foreach (var item in connection.GetUnreadPosts())
                {
                    SendActionToAllHandlers(item);
                }

                if (newChannelsCheck == 1000)
                {
                    newChannelsCheck = 0;
                    connection.GetAllChannels();
                }
            }
        }

        #region Unity configuration
        private static IUnityContainer ConfigureUnity()
        {
            IUnityContainer unityContainer = new UnityContainer();
            unityContainer.RegisterSingleton(typeof(IConnection), typeof(Connection));
            unityContainer.RegisterSingleton(typeof(IJsonHelper), typeof(JsonHelper));
            unityContainer.RegisterSingleton(typeof(ISettingsProvider), typeof(XmlSettingsProvider));
            unityContainer.RegisterSingleton(typeof(IXmlReader), typeof(XmlReader));
            unityContainer.RegisterSingleton(typeof(IXmlWriter), typeof(XmlWriter));
            unityContainer.RegisterSingleton(typeof(ILogHelper), typeof(LogHelper));
            unityContainer.RegisterSingleton(typeof(IOnTimeEventRepository), typeof(OnTimeEvent));
            return unityContainer;
        }
        #endregion

        #region Helper methods
        private static void SendActionToAllHandlers(Post message)
        {
            bool responseTrue = false;

            if (connection.CheckIfPublic(message.Channel))
            {
                if (!message.Message.StartsWith("eastbot", StringComparison.InvariantCultureIgnoreCase))
                    return;
                var splited = message.Message.Split(new char[] { ' ' }, 2);
                if (splited.Length < 2)
                    return;
                message.Message = (splited[1]);
            }

            if (message.Message.StartsWith("help", StringComparison.OrdinalIgnoreCase))
            {
                List<CommandHelpDescription> allHelps = new List<CommandHelpDescription>();
                foreach (var item in loader.LoadedModules)
                {
                    allHelps.AddRange(item.CommandHelpDescription);
                }

                string temp = "";
                foreach (var item in allHelps)
                {
                    temp = temp + $"**{item.Command}**   {item.Description} \n";
                }

                connection.SendMessage(message.Channel, temp);
                return;
            }
            var handlers = container.ResolveAll<IActionHandler>();
            foreach (var item in handlers)
            {
                bool temp = item.HandleRequest(message);

                if (temp)
                {
                    responseTrue = true;
                }
            }

            if (!responseTrue)
            {
                connection.SendMessage(message.Channel, $"**Nie znaleziono komendy**");
            }
            //tu wiadomosc czy udalo
        }
        #endregion
    }
}

