using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Dynamic;
using System.IO;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
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

            var filePath = Path.Combine(_webHostEnv.WebRootPath, "html", $"{_configuration["CompanyID"]}.html");
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
    }
}
