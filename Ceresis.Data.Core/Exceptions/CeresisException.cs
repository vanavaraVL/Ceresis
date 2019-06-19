using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Ceresis.Data.Core.Exceptions
{
    public class CeresisException : Exception
    {
        public CeresisException()
        {
            Errors = new List<string>();
            HttpStatus = HttpStatusCode.BadRequest;
        }

        public CeresisException(IEnumerable<string> errors) : base(errors?.ToList().First())
        {
            Errors = errors?.ToList() ?? new List<string>();
            HttpStatus = HttpStatusCode.BadRequest;
        }

        public CeresisException(string error) : base(error)
        {
            Errors = new List<string>
            {
                error
            };
            HttpStatus = HttpStatusCode.BadRequest;
        }

        public ICollection<string> Errors { get; set; }

        public HttpStatusCode HttpStatus { get; set; }
    }
}