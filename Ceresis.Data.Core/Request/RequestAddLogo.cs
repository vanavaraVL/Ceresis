using Ceresis.Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ceresis.Data.Core.Request
{
    public class RequestAddLogo
    {
        public LogoSystemEnum TypeValue { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string FileName { get; set; }

        public string FileData { get; set; }
    }
}
