using System;
using System.Collections.Generic;
using System.Text;

namespace Ceresis.Service.Core
{
    public class AppSettings
    {
        public string SMTPHost { get; set; }

        public int SMTPPort { get; set; }

        public string NoReplayMail { get; set; }

        public string NoReplayPassword { get; set; }
    }
}
