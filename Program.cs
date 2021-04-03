using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;

namespace WarOfRightsWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();

            try
            {
                Log.Information("Application starting web host...");
                CreateHostBuilder(args).Build().Run();
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

        protected static void ConfigureLogger(WebHostBuilderContext webHostBuilderContext,
            LoggerConfiguration loggerConfiguration)
        {
            // NOTE: Read configuration from appsettings.json
            loggerConfiguration.ReadFrom.Configuration(webHostBuilderContext.Configuration);
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    var contentRootPath = hostingContext.HostingEnvironment.ContentRootPath;
                    var path = Path.Combine(contentRootPath, "wwwroot", "json", "events.json");

                    config.AddJsonFile(path,
                        false,
                        true);
                })
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
        }
    }
}