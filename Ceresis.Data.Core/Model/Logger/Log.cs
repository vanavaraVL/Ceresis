using System;
using System.Collections.Generic;
using System.Text;

namespace Ceresis.Data.Core.Model.Logger
{
    public class Log
    {
        public string Message { get; private set; }

        public string StackTrace { get; private set; }

        public DateTime CreateDate { get; private set; }

        public string OperationName { get; set; }

        public string InnerException { get; private set; }

        public Log(Exception ex, string operationName)
        {
            Message = ex.Message;
            StackTrace = ex.StackTrace;
            CreateDate = DateTime.Now;
            OperationName = operationName;
            InnerException = ex.InnerException?.Message;
        }

        public Log(string message)
        {
            Message = message;
            CreateDate = DateTime.Now;
        }
    }
}
