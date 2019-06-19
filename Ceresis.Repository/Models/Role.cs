using Ceresis.Repository.Infrastructure;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ceresis.Repository.Models
{
    public class Role : IdentityRole<int>, IEntity<int>
    {
        public IEnumerable<UserRole> Users { get; set; }
    }
}
