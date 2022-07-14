
using Employee.DataAccessLayer.DBContexts;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Https;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Net;

namespace Employee.API
{
    public class Program
    {

        public static void Main(string[] args)
        {
            /* var builder = WebApplication.CreateBuilder(args);

            builder.WebHost.UseKestrel(options =>
            {
                var configuration = (IConfiguration)options.ApplicationServices.GetService(typeof(IConfiguration));
                var httpsPort = configuration.GetValue("ASPNETCORE_HTTPS_PORT", 443);
                var certPassword = configuration.GetValue<string>("Kestrel:Certificates:Development:Password");
                var certPath = configuration.GetValue<string>("Kestrel:Certificates:Development:Path");

                options.Listen(IPAddress.Any, httpsPort, listenOptions =>
                {
                    listenOptions.UseHttps(certPath, certPassword);
                });
            });
            var host = builder.Build().Migrate<EmployeeContext>();
            // migrate the database.  Best practice = in Main, using service scope
            using (var scope = host.Services.CreateScope())
            {
                try
                {
                    var context = scope.ServiceProvider.GetService<EmployeeContext>();
                    // for demo purposes, delete the database & migrate on startup so 
                    // we can start with a clean slate
                    context.Database.EnsureDeleted();
                    context.Database.Migrate();
                }
                catch (Exception ex)
                {
                    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while migrating the database.");
                }
            }
            host.Run(); */
           
           
            var host = CreateHostBuilder(args).Build().Migrate<EmployeeContext>();

            // migrate the database.  Best practice = in Main, using service scope
            using (var scope = host.Services.CreateScope())
            {
                try
                {
                    var context = scope.ServiceProvider.GetService<EmployeeContext>();
                    // for demo purposes, delete the database & migrate on startup so 
                    // we can start with a clean slate
                    context.Database.EnsureDeleted();
                    context.Database.Migrate();
                }
                catch (Exception ex)
                {
                    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while migrating the database.");
                }
            }

            // run the web app
            host.Run();
        }

        
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

    
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
             WebHost.CreateDefaultBuilder(args)
                .UseKestrel(options =>
                {
                var configuration = (IConfiguration)options.ApplicationServices.GetService(typeof(IConfiguration));
                var httpsPort = configuration.GetValue("ASPNETCORE_HTTPS_PORT", 443);
                var certPassword = configuration.GetValue<string>("Kestrel:Certificates:Development:Password");
                var certPath = configuration.GetValue<string>("Kestrel:Certificates:Development:Path");

                options.Listen(IPAddress.Any, httpsPort, listenOptions =>
                {
                    listenOptions.UseHttps(certPath, certPassword);
                });
                });
            
    }
}
