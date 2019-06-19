using Ceresis.Data.Core.Model;
using Ceresis.Data.Core.Model.Paging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ceresis.Data.Core.Response
{
    public class ResponseGetSplitHouseCatalog: ResponseBase
    {
        public ResponseGetSplitHouseCatalog()
        {
            Paging = new Paging(0, 0, 10);

            Data = new List<SplitHouseDTO>();
        }

        public ResponseGetSplitHouseCatalog(IPaging paging) : this()
        {
            if (paging != null)
                Paging = paging;
        }

        public ICollection<SplitHouseDTO> Data { get; set; }
    }
}
