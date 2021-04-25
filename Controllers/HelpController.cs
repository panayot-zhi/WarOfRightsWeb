using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WarOfRightsWeb.Constants;
using WarOfRightsWeb.Data;

namespace WarOfRightsWeb.Controllers
{
    public class HelpController : Controller
    {
        private readonly WarOfRightsDbContext _db;

        public HelpController(WarOfRightsDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            await GetWeaponsAsync();

            return View();
        }

        public async Task GetWeaponsAsync()
        {
            ViewBag.Swords = await _db.Weapons.Where(x => Weapons.Swords.Contains(x.ID)).ToListAsync();
            ViewBag.Revolvers = await _db.Weapons.Where(x => Weapons.Revolvers.Contains(x.ID)).ToListAsync();
            ViewBag.Rifles = await _db.Weapons.Where(x => Weapons.Rifles.Contains(x.ID)).ToListAsync();
            ViewBag.Artillery = await _db.Weapons.Where(x => Weapons.Artillery.Contains(x.ID)).ToListAsync();
            ViewBag.Misc = await _db.Weapons.Where(x => Weapons.Misc.Contains(x.ID)).ToListAsync();
        }
    }
}
