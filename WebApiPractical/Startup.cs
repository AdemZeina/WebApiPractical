using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WebApiPractical.Infrastructure.Services;

namespace WebApiPractical
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IProjectsService, ProjectsService>();
            services.AddScoped<ICountriesService, CountriesService>();

            string securityKey = "493ab24b-0c99-3341-bf32-76037c2f36eb$localhost:52020";
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));


            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ////what to validate
                        //ValidateIssuer = true,
                        //ValidateAudience = true,
                        //ValidateIssuerSigningKey = true,
                        ////setup validate data
                        //ValidIssuer = "localhost:52020",
                        //ValidAudience = "readers",
                        //IssuerSigningKey = symmetricSecurityKey,
                        //RequireExpirationTime = true

                        // Clock skew compensates for server time drift.
                        // We recommend 5 minutes or less:
                        ClockSkew = TimeSpan.FromMinutes(5),
                        // Specify the key used to sign the token:
                        IssuerSigningKey = symmetricSecurityKey,
                        RequireSignedTokens = true,
                        // Ensure the token hasn't expired:
                        RequireExpirationTime = true,
                        ValidateLifetime = true,
                        // Ensure the token audience matches our audience value (default true):
                        ValidateAudience = true,
                        ValidAudience = "readers",
                        // Ensure the token was issued by a trusted authorization server (default true):
                        ValidateIssuer = true,
                        ValidIssuer = "localhost:52020"
                    };
                });
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllHeaders",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });



            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();
            app.UseCors("AllowAllHeaders");
            app.UseMvc();
        }
    }
}
