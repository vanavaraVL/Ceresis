using Ceresis.Repository.Infrastructure;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ceresis.Repository.Models
{
    public class User : IdentityUser<int>, IEntity<int>
    {
        public string Name { get; set; }

        public IEnumerable<UserRole> Roles { get; set; }
    }
}
