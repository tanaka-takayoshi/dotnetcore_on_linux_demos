using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using HelloReact.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace HelloReact
{
    public class Startup
    {
        public string App_Data { get; }
        public IConfigurationRoot Configuration { get; }
        private string environmentName;
        public Startup(IHostingEnvironment env)
        {

            App_Data = Path.Combine(env.ContentRootPath, "App_Data");
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            if (env.IsDevelopment())
            {
                
            }
            environmentName = env.EnvironmentName;
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            switch (environmentName)
            {
                case "Development":
                    services.AddDbContext<ToDoContext>(options => options.UseSqlite(Configuration["Connection"]));
                    break;
                case "Production":
                    var host = Configuration["POSTGRESQL_SERVICE_HOST"];
                    var port = Configuration["POSTGRESQL_SERVICE_PORT"];
                    services.AddDbContext<ToDoContext>(options => options.UseNpgsql($"User ID=user;Password=p@ssw0rd;Host={host};Port={port};Database=todo;Pooling=true;"));
                    break;
                default:
                    break;
            }
            
            services.AddMvc();

            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseDefaultFiles();            
            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseSwagger();
            app.UseSwaggerUi();
        }
    }
}
