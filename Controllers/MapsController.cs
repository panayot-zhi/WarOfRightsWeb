using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WarOfRightsWeb.Constants;
using WarOfRightsWeb.Data;

namespace WarOfRightsWeb.Controllers
{
    public class MapsController : Controller
    {
        private readonly WarOfRightsDbContext _db;

        public MapsController(WarOfRightsDbContext db)
        {
            this._db = db;
        }

        public IActionResult Index()
        {
            return View(model: GetMaps());
        }

        public IActionResult Antietam(string id)
        {
            var area = Maps.Areas.Antietam;

            if (!string.IsNullOrEmpty(id))
            {
                return View($"{area}/{id}", model: GetMap(id));
            }

            return View($"{area}/Index", GetMaps(area));

        }

        public IActionResult HarpersFerry(string id)
        {
            var area = Maps.Areas.HarpersFerry;

            if (!string.IsNullOrEmpty(id))
            {
                return View($"{area}/{id}", model: GetMap(id));
            }

            return View($"{area}/Index", GetMaps(area));
        }

        public IActionResult SouthMountain(string id)
        {
            var area = Maps.Areas.SouthMountain;

            if (!string.IsNullOrEmpty(id))
            {
                return View($"{area}/{id}", model: GetMap(id));
            }

            return View($"{area}/Index", GetMaps(area));
        }

        public IActionResult DrillCamps(string id)
        {
            var area = Maps.Areas.DrillCamps;

            if (!string.IsNullOrEmpty(id))
            {
                return View($"{area}/{id}", model: GetMap(id));
            }

            return View($"{area}/Index", GetMaps(area));
        }

        public IActionResult PicketPatrol()
        {
            return View(model: GetMap(Maps.PicketPatrol));
        }

        private Map GetMap(string id)
        {
            var map = _db.Maps
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

        private IEnumerable<Map> GetMaps(string area = null)
        {
            if (Maps.Areas.DrillCamps.Equals(area))
            {
                return _db.Maps
                    .AsNoTracking()
                    .Where(x => Maps.DrillCampMaps.Contains(x.ID))
                    .OrderBy(x => x.Order)
                    .Select(x => new Map()
                    {
                        ID = x.ID,
                        Name = x.Name,
                        AreaName = x.AreaName,
                        DateTimeDescription = x.DateTimeDescription,
                        DefendingTeam = x.DefendingTeam,
                        Description = x.Description,
                        SkirmishImagePath = x.SkirmishImagePath,
                    });
            }

            if (Maps.Areas.Antietam.Equals(area) ||
                Maps.Areas.SouthMountain.Equals(area) ||
                Maps.Areas.HarpersFerry.Equals(area))
            {
                return _db.Maps
                    .AsNoTracking()
                    .Where(x => x.AreaName == area)
                    .OrderBy(x => x.Order)
                    .Select(x => new Map()
                    {
                        ID = x.ID,
                        Name = x.Name,
                        AreaName = x.AreaName,
                        DateTimeDescription = x.DateTimeDescription,
                        DefendingTeam = x.DefendingTeam,
                        Description = x.Description,
                        SkirmishImagePath = x.SkirmishImagePath,
                    });
            }

            // else return all 
            // maps ordered by name
            return _db.Maps
                .AsNoTracking()
                .OrderBy(x => x.Name)
                .Select(x => new Map()
                {
                    ID = x.ID,
                    Name = x.Name,
                    AreaName = x.AreaName,
                    DateTimeDescription = x.DateTimeDescription,
                    DefendingTeam = x.DefendingTeam,
                    Description = x.Description,
                    SkirmishImagePath = x.SkirmishImagePath
                });
        }

    }
}