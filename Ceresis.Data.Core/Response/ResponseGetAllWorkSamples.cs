using Ceresis.Data.Core.Model;
using Ceresis.Data.Core.Model.Paging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ceresis.Data.Core.Response
{
    public class ResponseGetAllWorkSamples: ResponseBase
    {
        public ResponseGetAllWorkSamples()
        {
            Paging = new Paging(0, 0, 10);
        }

        public ResponseGetAllWorkSamples(IPaging paging)
        {
            if (paging != null)
                Paging = paging;
        }

        public ICollection<WorkSample> Data { get; set; }
    }
}
