using System;
using AppStoreAPI.Data;
using AppStoreAPI.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;
using Microsoft.OpenApi.Models;
using System.IO;
using Microsoft.Extensions.FileProviders;

namespace AppStoreAPI
{
    public class Startup
    {
        private IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<AppStoreDbContext>(opt => 
                opt.UseSqlServer(Configuration.GetConnectionString("DevConnectionString")));

            services.AddTransient<IAgeClassificationRepo, AgeClassificationRepo>();
            services.AddTransient<IAppRepo, AppRepo>();
            services.AddTransient<IDeveloperRepo, DeveloperRepo>();
            services.AddTransient<IPlatformRepo, PlatformRepo>();
            services.AddTransient<IUserRepo, UserRepo>();

            services.AddCors();

            services.AddControllers().AddNewtonsoftJson(s => {
                s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                s.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(options =>
            options.WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader());

            app.UseRouting();

            app.UseStaticFiles();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            
        }
    }
}
