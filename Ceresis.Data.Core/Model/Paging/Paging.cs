using System;
using System.Collections.Generic;
using System.Text;

namespace Ceresis.Data.Core.Model.Paging
{
    public class Paging: IPaging
    {
        public Paging(int length, int page, int pageSize)
        {
            Length = length;
            Page = page;
            PageSize = pageSize;
        }

        public int Length { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; }
    }
}
