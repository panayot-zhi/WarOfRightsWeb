using System.IO;
using System.Linq;
using System.Text;
using System.Dynamic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using WarOfRightsWeb.Common;
using WarOfRightsWeb.Models;

namespace WarOfRightsWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _webHostEnv;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment webHostEnv, IConfiguration configuration)
        {
            _logger = logger;
            _webHostEnv = webHostEnv;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            dynamic vModel = new ExpandoObject();

            vModel.CompanyID = _configuration["CompanyID"];
            var filePath = Path.Combine(_webHostEnv.WebRootPath, "html", $"{vModel.CompanyID}.html");
            var roosterFile = System.IO.File.ReadAllText(filePath);
            var roosterFileInfo = new FileInfo(filePath);
            vModel.Retrieved = roosterFileInfo.LastWriteTime.ToString("f");
            vModel.Rooster = roosterFile;

            return View(vModel);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View(new Login());
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login loginInfo)
        {
            if (!ModelState.IsValid)
            {
                return View(loginInfo);
            }

            var admin = _configuration.GetSection("SiteUser").Get<Login>();

            if (!admin.UserName.Equals(loginInfo.UserName) || !admin.Password.Equals(loginInfo.Password))
            {
                return View(loginInfo);
            }

            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, "Administrator")
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            if (User.IsLoggedIn())
            {
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Route("/sitemap.xml")]
        public async Task SitemapXML()
        {
            var host = Request.Host;
            var headers = Request.Headers;
            if (headers.TryGetValue("X-Forwarded-For", out var forwardedForHeaders))
            {
                var forwardedFor = forwardedForHeaders.SingleOrDefault();
                if (forwardedFor is not null)
                {
                    host = new HostString(forwardedFor);
                }
            }

            var sitemapPath = Path.Combine(_webHostEnv.WebRootPath, "xml", "sitemap.xml");
            var sitemap = await System.IO.File.ReadAllTextAsync(sitemapPath);
            sitemap = sitemap.Replace("{{SiteURL}}", Request.Scheme + "://" + host);

            Response.ContentType = "application/xml";

            await Response.WriteAsync(sitemap, Encoding.UTF8);
        }
    }
}
