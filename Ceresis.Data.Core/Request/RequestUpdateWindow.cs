using System;
using System.Collections.Generic;
using System.Text;

namespace Ceresis.Data.Core.Request
{
    public class RequestUpdateWindow
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Feature { get; set; }

        public string Size { get; set; }

        public double Total { get; set; }

        public string FileName { get; set; }

        public string FileData { get; set; }

        public bool HasSetup { get; set; }
    }
}
