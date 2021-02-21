using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Dynamic;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult About()
        {
            dynamic vModel = new ExpandoObject();

            var filePath = Path.Combine(_webHostEnv.WebRootPath, "html", $"{_configuration["CompanyID"]}.html");
            var content = System.IO.File.ReadAllText(filePath);
            var roosterFile = new FileInfo(filePath);
            vModel.Retrieved = roosterFile.LastWriteTime.ToString("f");
            vModel.Content = content;

            return View(vModel);
        }
    }
}
