using Eastbot.Objects;

namespace EastBot.Core.Interfaces
{
    public interface IActionHandler
    {
        bool HandleRequest(Post message);
    }
}
