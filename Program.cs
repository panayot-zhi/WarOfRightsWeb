using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace WarOfRightsWeb
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();

            try
            {
                Log.Information("Application starting web host...");
                var builder = CreateHostBuilder(args);
                var host = builder.Build();
                host.Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application start-up failed.");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static void ConfigureLogger(HostBuilderContext webHostBuilderContext,
            LoggerConfiguration loggerConfiguration)
        {
            // NOTE: Read configuration from appsettings.json
            loggerConfiguration.ReadFrom.Configuration(webHostBuilderContext.Configuration);
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .UseSerilog(ConfigureLogger)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    var contentRootPath = hostingContext.HostingEnvironment.ContentRootPath;
                    var path = Path.Combine(contentRootPath, "wwwroot", "json", "events.json");

                    config.AddJsonFile(path,
                        false,
                        true);
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        }
    }
}