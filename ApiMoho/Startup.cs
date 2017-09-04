using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ApiMoho.Commands;
using ApiMoho.Commands.Interfaces;
using ApiMoho.Context;
using ApiMoho.Models;
using ApiMoho.Repositories;
using ApiMoho.Repositories.interfaces;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.ExpressionVisitors.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace ApiMoho
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
            #region Config

            services.AddSingleton(Configuration);
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder => { builder.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin(); });
            });
            services.AddMvc();
            services.AddDbContext<SecurityContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("SecurityConnection"),
                    sqlOptions => sqlOptions.MigrationsAssembly("ApiMoho")));


            services.AddIdentity<UserModel, UserRole>().AddEntityFrameworkStores<SecurityContext>()
                .AddDefaultTokenProviders();


            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.ConfigureApplicationCookie(options =>
            {
                options.Events = new CookieAuthenticationEvents
                {
                    OnRedirectToLogin = ctx =>
                    {
                        if (ctx.Request.Path.StartsWithSegments("/api"))
                        {
                            ctx.Response.StatusCode = (int)System.Net.HttpStatusCode.Unauthorized;
                        }
                        return Task.FromResult(0);
                    }
                };
            });

            #endregion

            //Conmands Injections
            services.AddSingleton<IListingCommand, ListingCommand>();
            services.AddSingleton<IBrowseCommand, BrowseCommand>();
            services.AddSingleton<IUserCommand, UserCommand>();

            //Repository Injection
            services.AddSingleton<IListingRepository, ListingRepository>();
            services.AddSingleton<IUserRepository, UserRepository>();

            #region JWTSetup

            var audienceConfig = Configuration.GetSection("Tokens");
            var symmetricKeyAsBase64 = audienceConfig["Key"];
            var keyByteArray = Encoding.ASCII.GetBytes(symmetricKeyAsBase64);
            var signingKey = new SymmetricSecurityKey(keyByteArray);

            var tokenValidationParameters = new TokenValidationParameters
            {
                // The signing key must match!
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signingKey,

                // Validate the JWT Issuer (iss) claim
                ValidateIssuer = true,
                ValidIssuer = audienceConfig["Issuer"],

                // Validate the JWT Audience (aud) claim
                ValidateAudience = true,
                ValidAudience = audienceConfig["Audience"],

                // Validate the token expiry
                ValidateLifetime = true,

                ClockSkew = TimeSpan.Zero
            };

            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(o =>
                {
                    //o.Authority = "";
                    //o.Audience = "";
                    o.TokenValidationParameters = tokenValidationParameters;
                });

            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowAllOrigins");

            app.UseAuthentication();

            app.UseIdentity();
            app.UseMvc();
        }
    }
}