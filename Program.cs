using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;

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
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
