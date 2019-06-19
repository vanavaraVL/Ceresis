using Ceresis.Data.Core.Model;
using Ceresis.Data.Core.Model.Paging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ceresis.Data.Core.Response
{
    public class ResponseGetWorkpriceCatalog: ResponseBase
    {
        public ResponseGetWorkpriceCatalog()
        {
            Paging = new Paging(0, 0, 10);

            Data = new List<WorkpriceDTO>();
        }

        public ResponseGetWorkpriceCatalog(IPaging paging) : this()
        {
            if (paging != null)
                Paging = paging;
        }

        public ICollection<WorkpriceDTO> Data { get; set; }
    }
}
