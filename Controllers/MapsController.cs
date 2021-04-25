using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            _db = db;
        }

        public IActionResult Index()
        {
            return View(GetMaps());
        }

        public async Task<IActionResult> Antietam(string id)
        {
            var area = Maps.Areas.Antietam;

            if (!string.IsNullOrEmpty(id))
            {
                var model = await GetMapAsync(id);
                if (model == null)
                {
                    return NotFound();
                }

                return View($"{area}/{id}", model);
            }

            return View($"{area}/Index", GetMaps(area));

        }

        public async Task<IActionResult> HarpersFerry(string id)
        {
            var area = Maps.Areas.HarpersFerry;

            if (!string.IsNullOrEmpty(id))
            {
                var model = await GetMapAsync(id);
                if (model == null)
                {
                    return NotFound();
                }

                return View($"{area}/{id}", model);
            }

            return View($"{area}/Index", GetMaps(area));
        }

        public async Task<IActionResult> SouthMountain(string id)
        {
            var area = Maps.Areas.SouthMountain;

            if (!string.IsNullOrEmpty(id))
            {
                var model = await GetMapAsync(id);
                if (model == null)
                {
                    return NotFound();
                }

                return View($"{area}/{id}", model);
            }

            return View($"{area}/Index", GetMaps(area));
        }

        public async Task<IActionResult> DrillCamps(string id)
        {
            var area = Maps.Areas.DrillCamps;

            if (!string.IsNullOrEmpty(id))
            {
                var model = await GetMapAsync(id);
                if (model == null)
                {
                    return NotFound();
                }

                return View($"{area}/{id}", model);
            }

            return View($"{area}/Index", GetMaps(area));
        }

        public async Task<IActionResult> PicketPatrol()
        {
            var model = await GetMapAsync(Maps.PicketPatrol);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        private async Task<Map> GetMapAsync(string id)
        {
            var map = await _db.Maps
                .AsNoTracking()
                .Include(x => x.MapRegiments)
                    .ThenInclude(x => x.Regiment)
                .Include(x => x.MapRegiments)
                    .ThenInclude(x => x.MapRegimentWeapons)
                        .ThenInclude(x => x.Weapon)
                .SingleOrDefaultAsync(x => x.ID == id);

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