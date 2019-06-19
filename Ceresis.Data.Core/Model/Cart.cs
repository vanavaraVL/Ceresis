using System;
using System.Collections.Generic;
using System.Text;

namespace Ceresis.Data.Core.Model
{
    public class Cart
    {
        public Cart()
        {
            Items = new List<CartItem>();
        }

        public ICollection<CartItem> Items { get; set; }
    }
}
