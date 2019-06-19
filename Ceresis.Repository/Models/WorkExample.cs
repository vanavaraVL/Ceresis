using Ceresis.Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ceresis.Repository.Models
{
    public class WorkExample: BaseIntEntity
    {
        public string ImagePath { get; set; }

        public string ImageName { get; set; }

        public string Description { get; set; }
    }
}
