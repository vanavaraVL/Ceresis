using Ceresis.Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ceresis.Repository.Models
{
    public class LogoType: BaseIntEntity
    {
        public LogoSystemEnum Type { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }
    }
}
