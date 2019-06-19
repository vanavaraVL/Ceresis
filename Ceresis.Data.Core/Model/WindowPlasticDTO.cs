using System;
using System.Collections.Generic;
using System.Text;

namespace Ceresis.Data.Core.Model
{
    public class WindowPlasticDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Feature { get; set; }

        public string Size { get; set; }

        public string Total { get; set; }

        public string ImageUrl { get; set; }

        public double TotalValue { get; set; }

        public bool HasSetup { get; set; }
    }
}
