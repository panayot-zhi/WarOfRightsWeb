using Microsoft.AspNetCore.Mvc;

namespace WarOfRightsWeb.Controllers
{
    public class HelpController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
