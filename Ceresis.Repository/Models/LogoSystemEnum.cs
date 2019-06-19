using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Ceresis.Repository.Models
{
    public enum LogoSystemEnum: int
    {
        [Description("Бытовые сплит-системы")]
        Common = 10,

        [Description("Полупромышленные и промышленные сплит-системы")]
        Industrial = 20
    }
}
