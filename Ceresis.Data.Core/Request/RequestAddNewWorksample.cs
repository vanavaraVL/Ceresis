using System;
using System.Collections.Generic;
using System.Text;

namespace Ceresis.Data.Core.Request
{
    public class RequestAddNewWorksample
    {
        public string Name { get; set; }

        public string FileName { get; set; }

        public string FileData { get; set; }

        public string Description { get; set; }
    }
}
