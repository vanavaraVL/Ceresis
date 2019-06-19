using System;
using System.Collections.Generic;
using System.Text;

namespace Ceresis.Data.Core.Model.Sorting
{
    public class Sorting: ISorting
    {
        public Sorting(string name, string direction)
        {
            Name = name;
            Direction = direction;
        }

        public string Name { get; set; }
        public string Direction { get; set; }
    }
}
