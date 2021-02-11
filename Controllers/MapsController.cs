using Microsoft.AspNetCore.Mvc;
using WarOfRightsWeb.Utility;

namespace WarOfRightsWeb.Controllers
{
    public class MapsController : Controller
    {
        public IActionResult Index(string id)
        {
            return View();
        }

        public IActionResult Antietam(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                return View($"Antietam/{id}");
            }

            return View("Antietam/Index");

        }

        public IActionResult HarpersFerry(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                return View($"HarpersFerry/{id}");
            }

            return View("HarpersFerry/Index");
        }

        public IActionResult SouthMountain(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                return View($"SouthMountain/{id}");
            }

            return View("SouthMountain/Index");
        }

        public IActionResult BolivarHeightsCamp(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                return View($"BolivarHeightsCamp/{id}");
            }

            return View("BolivarHeightsCamp/Index");
        }

        public IActionResult DrillCamps(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                return View($"DrillCamps/{id}");
            }

            return View("DrillCamps/Index");
        }

        public IActionResult PicketPatrol()
        {
            return View();
        }

    }
}