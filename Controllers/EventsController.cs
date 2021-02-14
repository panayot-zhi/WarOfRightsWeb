using Microsoft.AspNetCore.Mvc;

namespace WarOfRightsWeb.Controllers
{
    public class EventsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
