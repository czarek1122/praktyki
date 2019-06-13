using Eastbot.Objects;
using EastBot.Core.Interfaces;
using System;

namespace EastBot.Modules.Translator.ActionHandlers
{
    public class TranslateActionHandlers : IActionHandler
    {
        private IConnection connection;
        private Services.Translator translatorService;

        public TranslateActionHandlers(IConnection connection)
        {
            this.connection = connection;
            translatorService = new Services.Translator();
        }

        public bool HandleRequest(Post message)
        {
            if (message.Message.StartsWith("translate", StringComparison.InvariantCultureIgnoreCase))
            {
                if (message.Message.ToLowerInvariant() == "translate języki")
                {
                    var temp = translatorService.GetAllLanguage();
                    string response = "";
                    foreach (var item in temp)
                    {
                        response += $"{item.Key} - '{item.Value}' \n";
                    }
                    connection.SendMessage(message.Channel, $"**Dostępne języki tłumaczenia:** \n{response}");
                    return true;
                }
                var splited = message.Message.Split(new char[] { ' ' }, 4);

                if (splited.Length <= 1 || string.IsNullOrWhiteSpace(splited[1]))
                {
                    connection.SendMessage(message.Channel, "Nieprawidłowe użycie komendy, napisz help aby uzyskać pomoc");
                    return true;
                }

                if (splited.Length >= 4)
                {
                    if (translatorService.IfExist(splited[1]) && translatorService.IfExist(splited[2]))
                    {
                        var resp = translatorService.Translate(splited[3], splited[1], splited[2]);
                        connection.SendMessage(message.Channel, $"**Tłumaczenie:** {resp}");
                        return true;
                    }
                }
                
                splited = message.Message.Split(new char[] { ' ' }, 2);
                var res = translatorService.Translate(splited[1], "pl", "en");
                connection.SendMessage(message.Channel, $"**Tłumaczenie:** {res}");

                return true;
            }

            return false;
        }
    }
}
