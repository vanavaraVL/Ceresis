using Ceresis.Data.Core.Exceptions;
using Ceresis.Service.Core.Ext;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Ceresis.Service.Core.Managers
{
    public class BaseManager
    {
        public int GetUserId(IHttpContextAccessor httpContext)
        {
            if (!httpContext.HttpContext.User.Identity.IsAuthenticated)
                throw new NotAuthorize();

            var id = httpContext.HttpContext.User.Claims.Single(x => x.Type == "Id").Value;

            return Convert.ToInt32(id);
        }

        public bool IsAdmin(IHttpContextAccessor httpContext)
        {
            if (!httpContext.HttpContext.User.Identity.IsAuthenticated)
                throw new NotAuthorize();

            var roles = httpContext.HttpContext.User.Claims.SingleOrDefault(x => x.Type == ClaimTypes.Role)?.Value ?? "";

            return roles.Contains("admin", StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
