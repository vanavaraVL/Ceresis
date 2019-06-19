using Ceresis.Data.Model.Logger;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceresis.Services
{
    public class LoggerManager
    {
        private readonly Logger _logger;

        public LoggerManager()
        {
            _logger = LogManager.GetCurrentClassLogger();
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
            _logger.Error(log);
        }

        private void LogInfoToFile(Log log)
        {
            _logger.Info(log);
        }
    }
}
