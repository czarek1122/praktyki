using EastBot.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3.Object
{
    public class DelegateOnTime
    {
        public OnTimeEventDelegate action { get; set; }
        public TimeSpan TimeSpan { get; set; }
        public DateTime LastUse { get; set; }

        public DelegateOnTime(OnTimeEventDelegate action, TimeSpan timeSpan, DateTime lastUse)
        {
            this.action = action;
            TimeSpan = timeSpan;
            LastUse = lastUse;
        }
    }
}
