﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ceresis.Data.Core.Request
{
    public class RequestAddWorkprice
    {
        public string Name { get; set; }

        public string Unity { get; set; }

        public bool ExactPrice { get; set; }

        public bool ContactPrice { get; set; }

        public double? Price { get; set; }
    }
}
