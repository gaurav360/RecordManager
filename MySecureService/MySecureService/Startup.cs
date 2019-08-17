using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using MySecureService.Models;
using MySecureService.Repository;
using MySecureService.Service;
using System;
using System.Text;

namespace MySecureService
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            TokenValidation(Configuration, services);
            var connectionString = Configuration.GetConnectionString("DBConn");

            services
                .AddDbContext<MyServiceContext>(o => o.UseSqlServer(connectionString))
                .AddScoped<IMyServiceContext, MyServiceContext>()
                .AddScoped<IMyServiceRepository, MyServiceRepository>()
                .AddScoped<IMyService, MyService>();

            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseCors(op => op.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            app.UseAuthentication();

            app.UseHttpsRedirection();
            app.UseMvc();
        }

        private void TokenValidation(IConfiguration configuration, IServiceCollection services)
        {
            var validationInfo = configuration.GetSection("AuthValidate");
            var keyByte = Encoding.UTF8.GetBytes(validationInfo["Key"]);
            var issuer = validationInfo["Iss"];
            var audience = validationInfo["Aud"];
            var signinigKey = new SymmetricSecurityKey(keyByte);

            var validationParams = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = signinigKey,

                ValidateAudience = true,
                ValidAudience = audience,

                ValidateIssuer = true,
                ValidIssuer = issuer,

                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };

            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o => o.TokenValidationParameters = validationParams);
        }

    }
}
