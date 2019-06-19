using System;
using System.Collections.Generic;
using System.Text;

namespace Ceresis.Data.Core.Request
{
    public class RequestAddSplitHouse
    {
        public string Model { get; set; }

        public string Power { get; set; }

        public string PowerRealty { get; set; }

        public string EnergoEfficienty { get; set; }

        public string Noise { get; set; }

        public string SizeExternal { get; set; }

        public string SizeInternal { get; set; }

        public double Price { get; set; }

        public string FileName { get; set; }

        public string FileData { get; set; }

    }
}
