using EastBot.Core.Object;
using System.Collections.Generic;
using Unity;

namespace EastBot.Core.Interfaces
{
    public interface IPlugin
    {
        List<CommandHelpDescription> CommandHelpDescription { get; }
        void Register(IUnityContainer unityContainer);
    }
}
