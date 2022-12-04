using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MyProject.Mock;
using MyProject.Repositories.Interfaces;
using MyProject.Repositories.Repositories;
using MyProject.Services;
using MyProject.Services.Interfaces;
using MyProject.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Threading.Tasks;
using AutoMapper;
using MyProject.Context;

namespace MyProject.API
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
            services.AddCors(options =>
            {
                options.AddPolicy(name: "myOrigin",
                                  policy =>
                                  {
                                      policy.AllowAnyOrigin().AllowAnyMethod();
                                  });
            });
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MyProject.API", Version = "v1" });
            });
            services.AddAutoMapper(typeof(Mapping));
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IPermissionService,PermissionService>();
            services.AddScoped<IClaimService, ClaimService>(); 
            services.AddScoped<IPermissionRepository, PermissionRepository>();
            services.AddScoped<IClaimRepository, ClaimRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddDbContext<IContext, MyDbContext>();
         //   services.AddSingleton<IContext, MockContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyProject.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("myOrigin");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
