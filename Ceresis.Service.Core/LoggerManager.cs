using Ceresis.Data.Core.Model.Logger;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Web;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Ceresis.Service.Core
{
    public class LoggerManager
    {
        private readonly Logger _logger;

        public LoggerManager(IHostingEnvironment environment)
        {
            _logger = NLogBuilder.ConfigureNLog(Path.Combine(environment.ContentRootPath, "nlog.config")).GetCurrentClassLogger();
        }

        public void LogError(Exception exception, string operationName)
        {
            var log = new Log(exception, operationName);

            LogErrorToFile(log);
        }

        public void LogInfo(string message)
        {
            var log = new Log(message);

            LogErrorToFile(log);
        }

        private void LogErrorToFile(Log log)
        {
            var theEvent = new LogEventInfo(NLog.LogLevel.Error, "", "Ошибка выполнения");

            theEvent.Properties["OperationName"] = log.OperationName;
            theEvent.Properties["StackTrace"] = log.StackTrace;
            theEvent.Properties["Message"] = log.Message;
            theEvent.Properties["CreateDate"] = log.CreateDate;
            theEvent.Properties["InnerException"] = log.InnerException;

            _logger.Log(theEvent);
        }

        private void LogInfoToFile(Log log)
        {
            var theEvent = new LogEventInfo(NLog.LogLevel.Info, "", "Информация");

            theEvent.Properties["OperationName"] = log.OperationName;
            theEvent.Properties["StackTrace"] = log.StackTrace;
            theEvent.Properties["Message"] = log.Message;
            theEvent.Properties["CreateDate"] = log.CreateDate;
            theEvent.Properties["InnerException"] = log.InnerException;

            _logger.Log(theEvent);
        }
    }
}
