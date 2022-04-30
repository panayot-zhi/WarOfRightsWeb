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

        public IActionResult Index(string mode)
        {
            return View(GetMaps(area: null, mode: mode));
        }

        public async Task<IActionResult> Antietam(string id, string mode)
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

            return View($"{area}/Index", GetMaps(area, mode));

        }

        public async Task<IActionResult> HarpersFerry(string id, string mode)
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

            return View($"{area}/Index", GetMaps(area, mode));
        }

        public async Task<IActionResult> SouthMountain(string id, string mode)
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

            return View($"{area}/Index", GetMaps(area, mode));
        }

        public async Task<IActionResult> DrillCamps(string id, string mode)
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

            return View($"{area}/Index", GetMaps(area, mode));
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

        private IEnumerable<Map> GetMaps(string area, string mode)
        {
            var maps = _db.Maps
                .AsNoTracking();

            if (!string.IsNullOrEmpty(mode))
            {
                maps = maps.Where(x => x.MapType == mode);
            }
            
            if (Maps.Areas.DrillCamps.Equals(area))
            {
                return maps.Where(x => Maps.DrillCampMaps.Contains(x.ID))
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
                return maps.Where(x => x.AreaName == area)
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
            return maps
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