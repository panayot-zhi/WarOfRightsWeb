using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WarOfRightsWeb.Constants;
using WarOfRightsWeb.Data;

namespace WarOfRightsWeb.Controllers
{
    public class MapsController : Controller
    {
        private WarOfRightsDbContext context;

        public MapsController(WarOfRightsDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index(string id)
        {
            return View();
        }

        public IActionResult Antietam(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                return View($"Antietam/{id}", model: GetMap(id));
            }

            return View("Antietam/Index");

        }

        public IActionResult HarpersFerry(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                return View($"HarpersFerry/{id}", model: GetMap(id));
            }

            return View("HarpersFerry/Index");
        }

        public IActionResult SouthMountain(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                return View($"SouthMountain/{id}", model: GetMap(id));
            }

            return View("SouthMountain/Index");
        }

        public IActionResult DrillCamps(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                return View($"DrillCamps/{id}", model: GetMap(id));
            }

            return View("DrillCamps/Index");
        }

        public IActionResult PicketPatrol()
        {
            return View(model: GetMap(Maps.PicketPatrol));
        }

        private Map GetMap(string id)
        {
            var map = context.Maps
                .Include(x => x.MapRegiments)
                    .ThenInclude(x => x.Regiment)
                .Include(x => x.MapRegiments)
                    .ThenInclude(x => x.MapRegimentWeapons)
                        .ThenInclude(x => x.Weapon)
                .Single(x => x.ID == id);

            /*Console.WriteLine($"Map: {map.Name}");
            foreach (var mapRegiment in map.MapRegiments)
            {
                Console.WriteLine($"MapRegiment: {mapRegiment.Regiment.Name}");
                foreach (var mapRegimentWeapon in mapRegiment.MapRegimentWeapons)
                {
                    Console.WriteLine($"\tWeapon: {mapRegimentWeapon.Weapon.Name}");
                }
            }*/

            return map;
        } 

    }
}