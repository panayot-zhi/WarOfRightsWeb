using Microsoft.AspNetCore.Mvc;

namespace WarOfRightsWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
