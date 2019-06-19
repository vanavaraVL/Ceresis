using System;
using System.Collections.Generic;
using System.Text;

namespace Ceresis.Data.Core.Model.Paging
{
    public interface IPaging
    {
        int Length { get; set; }

        int Page { get; set; }

        int PageSize { get; set; }
    }
}
