using System;
using System.Globalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using WarOfRightsWeb.Common;
using WarOfRightsWeb.Data;
using WarOfRightsWeb.Utility;

namespace WarOfRightsWeb
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public IWebHostEnvironment WebHostEnvironment { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            Configuration = configuration;
            WebHostEnvironment = webHostEnvironment;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(Configuration);
            services.AddTransient<DiscordSlashCommandsModule>();
            services.AddWrappedHostedService<DiscordBotService>();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(cookieOptions => {
                        cookieOptions.LoginPath = "/";
                    });

            if (WebHostEnvironment.IsDevelopment())
            {
                services.AddControllersWithViews()
                    .AddRazorRuntimeCompilation();
            }
            else
            {
                services.AddControllersWithViews();
            }

            services.AddDbContext<WarOfRightsDbContext>(
                contextLifetime: ServiceLifetime.Transient, optionsAction: options =>
                {
                    var connectionString = Configuration.GetConnectionString("DefaultConnection");
                    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
                        .UseSnakeCaseNamingConvention();
                }
            );

            Console.WriteLine("<<<< SERVICES CONFIGURED");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var cultureInfo = new CultureInfo("en-US");

            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            Console.WriteLine($"Thread culture information has been set to en-US; TimeZone: {TimeZoneInfo.Local}");

            Extensions.Initialize(env);

            // apply any pending migrations to the database if necessary
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<WarOfRightsDbContext>();
                context.Database.Migrate();
            }

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            app.UseDeveloperExceptionPage();
            app.UseAuthentication();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "sitemapxml",
                    pattern: "/sitemap.xml",
                    defaults: new { controller = "Home", action = "SitemapXML" }
                );
            });

            Console.WriteLine("<<<< APPLICATION STARTED");
        }
    }
}
