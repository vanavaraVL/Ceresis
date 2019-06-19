using Ceresis.Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ceresis.Repository.Models
{
    public class WorkPrice: BaseIntEntity
    {
        public string Name { get; set; }

        public string Unity { get; set; }

        public bool ExactPrice { get; set; }

        public bool ContactPrice { get; set; }

        public double? Price { get; set; }
    }
}
