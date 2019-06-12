using System;

namespace EastBot.Core.Interfaces
{
    public interface IOnTimeEventRepository
    {
        void RegisterHandler(OnTimeEventDelegate delegateToRun, TimeSpan onTime);
    }

    public delegate void OnTimeEventDelegate();
}
