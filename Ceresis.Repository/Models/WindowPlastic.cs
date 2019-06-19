using Ceresis.Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ceresis.Repository.Models
{
    public class WindowPlastic: BaseIntEntity
    {
        public string Name { get; set; }

        public string Feature { get; set; }

        public string Size { get; set; }

        public double Total { get; set; }

        public bool HasSetup { get; set; }

        public string ImageUrl { get; set; }
    }
}
