using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Dynamic;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

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
    }
}
