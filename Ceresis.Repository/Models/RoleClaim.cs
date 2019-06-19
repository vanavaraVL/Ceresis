using Ceresis.Repository.Infrastructure;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ceresis.Repository.Models
{
    public class RoleClaim : IdentityRoleClaim<int>, IEntity<int>
    {
    }
}
