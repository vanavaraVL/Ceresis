using Ceresis.Repository.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ceresis.Service.Core.Managers
{
    public class CeresisSignInManager : SignInManager<User>
    {
        public CeresisSignInManager(UserManager<User> userManager, IHttpContextAccessor contextAccessor,
            IUserClaimsPrincipalFactory<User> claimsFactory,
            IOptions<IdentityOptions> optionsAccessor, ILogger<SignInManager<User>> logger,
            IAuthenticationSchemeProvider schemes) : base(userManager,
            contextAccessor, claimsFactory, optionsAccessor, logger, schemes)
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
