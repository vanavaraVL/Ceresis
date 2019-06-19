using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Ceresis.Data.Core.Exceptions
{
    public class NotAuthorize : CeresisException
    {
        public NotAuthorize()
        {
            HttpStatus = HttpStatusCode.Unauthorized;
        }
    }
}
