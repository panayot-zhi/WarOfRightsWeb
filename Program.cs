using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace WarOfRightsWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("IN MAIN >>>>");

            try
            {
                Console.WriteLine("STARTING APPLICATION >>>>");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Console.WriteLine("APPLICATION FAILED TO START >>>>");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex);
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    var contentRootPath = hostingContext.HostingEnvironment.ContentRootPath;
                    var path = Path.Combine(contentRootPath, "wwwroot", "json", "events.json");

                    config.AddJsonFile(path,
                        optional: false,
                        reloadOnChange: true);
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
