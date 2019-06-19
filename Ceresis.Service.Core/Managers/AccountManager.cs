using Ceresis.Data.Core.Exceptions;
using Ceresis.Data.Core.Request;
using Ceresis.Data.Core.Response;
using Ceresis.Service.Core.Ext;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Ceresis.Service.Core.Managers
{
    public class AccountManager
    {
        private readonly CeresisUserManager userManager;
        private readonly CeresisSignInManager signInManager;
        private readonly IConfiguration configuration;

        public AccountManager(CeresisUserManager userManager, CeresisSignInManager signInManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
        }

        public async Task<ResponseLogin> CreateToken(RequestLogin model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);

            if (user == null)
                throw new NotAuthorize();

            if (!user.EmailConfirmed)
                throw new CeresisException("Email не верифицирован");

            var roles = await userManager.GetRolesAsync(user);

            var result = await signInManager.CheckPasswordSignInAsync(user, model.Password, false);

            if (result.Succeeded)
            {
                var claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim("Id", user.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };

                if (!roles.IsEmpty())
                    claims.AddRange(roles.Select(x => new Claim(ClaimsIdentity.DefaultRoleClaimType, x)));

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(configuration["JWT:Issuer"], configuration["JWT:Audience"],
                    claims, expires: DateTime.Now.AddHours(int.Parse(configuration["JWT:LifeTimeH"])),
                    signingCredentials: creds);

                return new ResponseLogin()
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Id = user.Id,
                    Roles = roles,
                    Email = user.Email
                };
            }

            throw new NotAuthorize();
        }
    }
}
