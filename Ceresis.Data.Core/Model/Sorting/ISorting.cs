using System;
using System.Collections.Generic;
using System.Text;

namespace Ceresis.Data.Core.Model.Sorting
{
    public interface ISorting
    {
        string Name { get; set; }

        string Direction { get; set; }
    }
}
