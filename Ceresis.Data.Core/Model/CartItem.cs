using System;
using System.Collections.Generic;
using System.Text;

namespace Ceresis.Data.Core.Model
{
    public class CartItem
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int? Count { get; set; }

        public decimal? Price { get; set; }
    }
}
