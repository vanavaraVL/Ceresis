using Ceresis.Data.Core.Model.Paging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ceresis.Data.Core.Response
{
    public class ResponseBase
    {
        public bool IsError { get; set; }

        public string Message { get; set; }

        public IPaging Paging { get; set; }
    }
}
