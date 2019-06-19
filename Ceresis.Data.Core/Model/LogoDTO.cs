using Ceresis.Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ceresis.Data.Core.Model
{
    public class LogoDTO
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public LogoSystemEnum TypeValue { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }
    }
}
