using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ceresis.Common;
using Ceresis.Repository.Implementation;
using Ceresis.Repository.Infrastructure;
using Ceresis.Repository.Models;
using Ceresis.Service.Core;
using Ceresis.Service.Core.Ext;
using Ceresis.Service.Core.Helpers;
using Ceresis.Service.Core.Managers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;

namespace Ceresis
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            CorsConfig(services);

            services.AddMvc().AddJsonOptions(options => options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver());
            services.AddApiVersioning(v =>
            {
                v.DefaultApiVersion = new ApiVersion(1, 0);
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Ceresis API", Version = "v1" });
            });

            services.AddEntityFrameworkNpgsql()
                .AddDbContext<DatabaseContext>(options =>
                {
                    options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"),
                        option => { option.MigrationsAssembly("Ceresis.Repository"); });
                });

            services.AddIdentity<User, Role>(options => { options.SignIn.RequireConfirmedEmail = true; })
                .AddEntityFrameworkStores<DatabaseContext>()
                .AddDefaultTokenProviders()
                .AddUserManager<CeresisUserManager>()
                .AddRoleManager<CeresisRoleManager>();

            services.AddDirectoryBrowser();

            Authentication(services);

            RegisterService(services);

            ConfigureSettings(services);
        }

        private void RegisterService(IServiceCollection services)
        {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<CeresisSignInManager>();
            services.AddScoped<IDatabaseContext, DatabaseContext>();
            services.AddScoped<IRepositoryFactory, RepositoryFactory>();

            services.AddScoped<IPathProvider, PathProvider>();

            services.AddScoped(typeof(LoggerManager));
            services.AddScoped(typeof(EmailServices));
            services.AddScoped(typeof(AccountManager));
            services.AddScoped(typeof(DBManager));
            services.AddScoped(typeof(AdminManager));
            services.AddScoped(typeof(CatalogManager));
        }

        private void ConfigureSettings(IServiceCollection services)
        {
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
        }

        private void Authentication(IServiceCollection services)
        {
            services.AddAuthentication(sharedOptions =>
            {
                sharedOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                sharedOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                sharedOptions.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = Configuration["JWT:Issuer"],

                        ValidateAudience = true,
                        ValidAudience = Configuration["JWT:Audience"],
                        ValidateLifetime = true,

                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Key"])),
                        ValidateIssuerSigningKey = true
                    };
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, DatabaseContext repositoryContext, CeresisUserManager userManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseForwardedHeaders(new ForwardedHeadersOptions() { ForwardedHeaders = Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders.All });

            if (!repositoryContext.Database.GetPendingMigrations().IsEmpty())
                repositoryContext.Database.Migrate();

            app.UseStaticFiles();

            if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "workplace")))
            {
                Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "workplace"));
            }

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "workplace")),
                RequestPath = "/workplace"
            });

            app.UseDirectoryBrowser(new DirectoryBrowserOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "workplace")),
                RequestPath = "/workplace"
            });

            if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "catalog")))
            {
                Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "catalog"));
            }

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "catalog")),
                RequestPath = "/catalog"
            });

            app.UseDirectoryBrowser(new DirectoryBrowserOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", "catalog")),
                RequestPath = "/catalog"
            });

            app.UseSwagger();

            SetDefaultUser(userManager);

            app.UseAuthentication();

            app.UseMiddleware<CustomExceptionHandler>();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private void CorsConfig(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowCors",
                    builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials());
            });

            services.Configure<MvcOptions>(options => { options.Filters.Add(new CorsAuthorizationFilterFactory("AllowCors")); });
        }

        private void SetDefaultUser(CeresisUserManager userManager)
        {
            var admin = userManager.FindByNameAsync("admin").Result;
            if (admin == null)
            {
                admin = new User
                {
                    UserName = "admin-kit-service",
                    Email = "kit-service-mail@yandex.ru"
                };
                var resultUser = userManager.CreateAsync(admin, "XS4wpBtUZj").Result;

                if (resultUser.Succeeded)
                {
                    var token = userManager.GenerateEmailConfirmationTokenAsync(admin).Result;
                    resultUser = userManager.ConfirmEmailAsync(admin, token).Result;
                    var resultRole = userManager.AddToRoleAsync(admin, "admin").Result;
                }
            }
        }
    }
}
