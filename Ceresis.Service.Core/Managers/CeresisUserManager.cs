using Ceresis.Repository.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ceresis.Service.Core.Managers
{
    public class CeresisUserManager : UserManager<User>
    {
        public CeresisUserManager(IUserStore<User> store, IOptions<IdentityOptions> optionsAccessor,
            IPasswordHasher<User> passwordHasher,
            IEnumerable<IUserValidator<User>> userValidators, IEnumerable<IPasswordValidator<User>> passwordValidators,
            ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, IServiceProvider services,
            ILogger<UserManager<User>> logger) : base(
            store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services,
            logger)
        {
            Options.Password = new PasswordOptions
            {
                RequireDigit = false,
                RequireLowercase = false,
                RequiredLength = 6,
                RequireUppercase = false,
                RequireNonAlphanumeric = false
            };
        }
    }
}
