using Microsoft.AspNetCore.Mvc;

namespace WarOfRightsWeb.Controllers
{
    public class MapsController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}