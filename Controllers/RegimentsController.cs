﻿using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WarOfRightsWeb.Constants;
using WarOfRightsWeb.Data;

namespace WarOfRightsWeb.Controllers
{
    public class RegimentsController : Controller
    {
        private readonly WarOfRightsDbContext _db;

        public RegimentsController(WarOfRightsDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var allRegiments = _db.Regiments
                //.OrderByDescending(x => x.Type)
                .OrderBy(x => x.ID)
                .AsEnumerable();

            return View(allRegiments);
        }

        public IActionResult USA()
        {
            ViewBag.Faction = Labels.USA;
            var allUSARegiments = _db.Regiments
                .Where(x => x.Faction.Equals(Labels.USA))
                .OrderByDescending(x => x.Type)
                    .ThenBy(x => x.ID)
                .AsEnumerable();

            return View("Index", allUSARegiments);
        }

        public IActionResult CSA()
        {
            ViewBag.Faction = Labels.CSA;
            var allCSARegiments = _db.Regiments
                .Where(x => x.Faction.Equals(Labels.CSA))
                .OrderByDescending(x => x.Type)
                    .ThenBy(x => x.ID)
                .AsEnumerable();

            return View("Index", allCSARegiments);
        }

        public IActionResult Get(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            var model = _db.Regiments
                .Include(x => x.MapRegiments)
                    .ThenInclude(x => x.Map)
                .Include(x => x.MapRegiments)
                    .ThenInclude(x => x.MapRegimentWeapons)
                        .ThenInclude(x => x.Weapon)
                .SingleOrDefault(x => x.ID == id);

            if (model == null)
            {
                return NotFound();
            }

            return View("Regiment", model);

        }
    }
}