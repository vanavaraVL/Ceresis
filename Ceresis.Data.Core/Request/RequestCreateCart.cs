using Ceresis.Data.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ceresis.Data.Core.Request
{
    public class RequestCreateCart
    {
        public Cart Data { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
