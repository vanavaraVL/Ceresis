using System;
using System.Collections.Generic;
using System.Text;

namespace Ceresis.Data.Core.Response
{
    public class ResponseLogin: ResponseBase
    {
        public ICollection<string> Roles { get; set; }

        public int Id { get; set; }

        public string Token { get; set; }

        public string Email { get; set; }
    }
}
