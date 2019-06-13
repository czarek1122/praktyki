using ConsoleApp3.Object;
using EastBot.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class OnTimeEvent : IOnTimeEventRepository
    {
        private List<DelegateOnTime> delegateOnTimeList;

        public OnTimeEvent()
        {
            delegateOnTimeList = new List<DelegateOnTime>();

            var run = Task.Run(() =>
            {
                while (true)
                {
                    Thread.Sleep(1000);
                    foreach (var item in delegateOnTimeList)
                    {
                        if (item.TimeSpan.TotalMinutes == (DateTime.Now.Minute + DateTime.Now.Hour * 60) && DateTime.Today > item.LastUse)
                        {
                            item.LastUse = DateTime.Today;
                            item.action.Invoke();
                        }
                    }
                }
            });
        }

        public void RegisterHandler(OnTimeEventDelegate delegateToRun, TimeSpan onTime)
        {
            delegateOnTimeList.Add(new DelegateOnTime(delegateToRun, onTime, DateTime.Today.AddDays(-1)));
        }
    }
}
