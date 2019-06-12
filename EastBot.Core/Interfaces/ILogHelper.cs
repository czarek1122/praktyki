using System;
using System.Collections.Generic;
using System.Text;

namespace EastBot.Core.Interfaces
{
    public interface ILogHelper
    {
        void Info(string logMessage, Exception exc);
        void Error(Exception exc, string logMessage);
        void Debug();
    }
}
