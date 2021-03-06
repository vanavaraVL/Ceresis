﻿using Ceresis.Data.Core.Model;
using Ceresis.Data.Core.Model.Paging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ceresis.Data.Core.Response
{
    public class ResponseGetLogos: ResponseBase
    {
        public ResponseGetLogos()
        {
            Paging = new Paging(0, 0, 10);
        }

        public ResponseGetLogos(IPaging paging)
        {
            if (paging != null)
                Paging = paging;
        }

        public ICollection<LogoDTO> Data { get; set; }
    }
}
