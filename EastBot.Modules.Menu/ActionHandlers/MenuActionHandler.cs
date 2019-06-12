using Eastbot.Objects;
using EastBot.Core.Interfaces;
using EastBot.Modules.Menu.Object;
using EastBot.Modules.Plejada.Object;
using System;
using System.Collections.Generic;
using System.Text;
using XmlConfig;

namespace EastBot.Modules.Plejada.ActionHandlers
{
    public class MenuActionHandler : IActionHandler
    {
        private IConnection connection;
        private IJsonHelper jsonHelper;
        private ISettingsProvider settingsProvider;
        private string addressUrlJuicer;
        private string addressUrlCurator;

        public MenuActionHandler(IConnection connection, IJsonHelper jsonHelper, ISettingsProvider settingsProvider)
        {
            this.connection = connection;
            this.jsonHelper = jsonHelper;
            this.settingsProvider = settingsProvider;
            addressUrlJuicer = settingsProvider.GetString("Juicer", "APIUrl");
            addressUrlCurator = settingsProvider.GetString("Curator", "APIUrl");
        }

        public bool HandleRequest(Post message)
        {
            if (message.Message.StartsWith("menu", StringComparison.InvariantCultureIgnoreCase))
            {
                var splited = message.Message.Split(new char[] { ' ' }, 2);

                if (splited.Length <= 1 || string.IsNullOrWhiteSpace(splited[1]))
                {
                    return false;
                }


                //juicer
                //var response = jsonHelper.SendGetRequest<FPage>(addressUrlJuicer, null);   
                //foreach(var item in response.Posts.ItemsList)
                //{
                //    if (item.Source.Name.ToLowerInvariant() == splited[1].ToLowerInvariant())
                //    {
                //        connection.SendMessage(message.Channel, item.GetMessage());
                //        return true;
                //    }
                //}



                //curator
                var response = jsonHelper.SendGetRequest<CResult>(addressUrlCurator, null);

                foreach (var item in response.Posts)
                {
                    if (item.Name.ToLowerInvariant() == splited[1].ToLowerInvariant())
                    {
                        connection.SendMessage(message.Channel, $"**{item.Message}**");
                        return true;
                    }
                }
                return false;
            }
            return false;
        }
    }
}
