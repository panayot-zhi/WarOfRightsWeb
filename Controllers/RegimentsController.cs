using System.Dynamic;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace WarOfRightsWeb.Controllers
{
    public class RegimentsController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _webHostEnv;

        public RegimentsController(IConfiguration configuration, IWebHostEnvironment webHostEnv)
        {
            this._configuration = configuration;
            this._webHostEnv = webHostEnv;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Regiment(string id)
        {
            return View("Regiment", model: id);
        }

        public IActionResult USA()
        {
            return View();
        }

        public IActionResult CSA()
        {
            return View();
        }
    }
}