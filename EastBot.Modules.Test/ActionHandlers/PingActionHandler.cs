using Eastbot.Objects;
using EastBot.Core.Interfaces;

namespace EastBot.Modules.Test.ActionHandlers
{
    public class PingActionHandler : IActionHandler
    {
        private IConnection connection;

        public PingActionHandler(IConnection connection)
        {
            this.connection = connection;
        }

        public bool HandleRequest(Post message)
        {
            if (message.Message.ToLowerInvariant() == "ping")
            {
                connection.SendMessage(message.Channel, "pong");
                return true;
            }
            else if (message.Message.ToLowerInvariant() == "przedstaw się" && connection.CheckIfPublic(message.Channel))
            {
                connection.SendMessage(message.Channel, "**Witam wszystkich bardzo serdecznie!**");
                return true;
            }

            return false;
        }
    }
}
