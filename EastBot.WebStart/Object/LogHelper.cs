using EastBot.Core.Interfaces;
using NLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    public class LogHelper : ILogHelper
    {
        private static NLog.Logger logger;

        public LogHelper()
        {
            logger = NLog.LogManager.GetCurrentClassLogger();
        }

        public void Info(string logMessage, Exception exc = null)
        {
            logger.Info(logMessage);
        }

        public void Error(Exception exc, string logMessage = null)
        {
            logger.Error(exc, logMessage);
        }


        //na przyszłość
        public void Debug()
        {
            throw new NotImplementedException();
        }
    }
}
