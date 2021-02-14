using System.Dynamic;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace WarOfRightsWeb.Controllers
{
    public class CompanyController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _webHostEnv;

        public CompanyController(IConfiguration configuration, IWebHostEnvironment webHostEnv)
        {
            this._configuration = configuration;
            this._webHostEnv = webHostEnv;
        }

        public IActionResult Index()
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