using Microsoft.AspNetCore.Mvc;

namespace WarOfRightsWeb.Controllers
{
    public class MediaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
