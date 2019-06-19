using Ceresis.Data.Core.Model.Paging;
using Ceresis.Data.Core.Model.Sorting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ceresis.Data.Core.Request
{
    public class RequestBase
    {
        public Paging Paging { get; set; }

        public Sorting Sorting { get; set; }
    }
}
