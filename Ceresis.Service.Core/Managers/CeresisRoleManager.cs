using Ceresis.Repository.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ceresis.Service.Core.Managers
{
    public class CeresisRoleManager : RoleManager<Role>
    {
        public CeresisRoleManager(IRoleStore<Role> store, IEnumerable<IRoleValidator<Role>> roleValidators,
            ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errors, ILogger<RoleManager<Role>> logger) : base(store, roleValidators,
            keyNormalizer, errors, logger)
        {
        }
    }
}
