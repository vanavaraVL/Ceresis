using Ceresis.Data.Core.Model;
using Ceresis.Data.Core.Model.Paging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ceresis.Data.Core.Response
{
    public class ResponseGetWindowPlastics: ResponseBase
    {
        public ResponseGetWindowPlastics()
        {
            Paging = new Paging(0, 0, 10);

            Data = new List<WindowPlasticDTO>();
        }

        public ResponseGetWindowPlastics(IPaging paging): this()
        {
            if (paging != null)
                Paging = paging;
        }
        
        public ICollection<WindowPlasticDTO> Data { get; set; }
    }
}
