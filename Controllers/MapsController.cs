using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.EntityFrameworkCore;
using WarOfRightsWeb.Constants;
using WarOfRightsWeb.Data;

namespace WarOfRightsWeb.Controllers
{
    public class MapsController : Controller
    {
        private readonly WarOfRightsDbContext _db;
        private readonly ICompositeViewEngine _viewEngine;

        public MapsController(WarOfRightsDbContext db, ICompositeViewEngine viewEngine)
        {
            _db = db;
            _viewEngine = viewEngine;
        }

        public IActionResult Index(string mode)
        {
            return View(GetMaps(area: null, mode: mode));
        }

        public async Task<IActionResult> Antietam(string id, string mode)
        {
            const string area = Labels.Antietam;

            if (!string.IsNullOrEmpty(id))
            {
                var model = await GetMapAsync(id);
                if (model == null)
                {
                    return NotFound();
                }
                
                return View(GetMapView(model, area), model);
            }

            return View($"{area}/Index", GetMaps(area, mode));

        }

        public async Task<IActionResult> HarpersFerry(string id, string mode)
        {
            const string area = Labels.HarpersFerry;

            if (!string.IsNullOrEmpty(id))
            {
                var model = await GetMapAsync(id);
                if (model == null)
                {
                    return NotFound();
                }

                return View(GetMapView(model, area), model);
            }

            return View($"{area}/Index", GetMaps(area, mode));
        }

        public async Task<IActionResult> SouthMountain(string id, string mode)
        {
            const string area = Labels.SouthMountain;

            if (!string.IsNullOrEmpty(id))
            {
                var model = await GetMapAsync(id);
                if (model == null)
                {
                    return NotFound();
                }

                return View(GetMapView(model, area), model);
            }

            return View($"{area}/Index", GetMaps(area, mode));
        }

        public async Task<IActionResult> DrillCamps(string id, string mode)
        {
            const string area = Labels.DrillCamps;

            if (!string.IsNullOrEmpty(id))
            {
                var model = await GetMapAsync(id);
                if (model == null)
                {
                    return NotFound();
                }

                return View(GetMapView(model, area), model);
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

            if (Labels.DrillCamps.Equals(area))
            {
                if (mode == Labels.DrillCamp)
                {
                    return maps.Where(x => Maps.DrillCampMaps.Contains(x.ID))
                        .OrderBy(x => x.Order)
                        .AsEnumerable()
                        .Select(x =>
                        {
                            // NOTE: This is needed, because the actual
                            // area name of the drill camps is HarperFerry
                            x.AreaName = Labels.DrillCamps;
                            return SelectMap(x);

                        });
                }

                if (mode == Labels.Conquest)
                {
                    return maps.Where(x => x.MapType == Labels.Conquest 
                            && x.AreaName == Labels.DrillCamp)
                        .OrderBy(x => x.Order)
                        .AsEnumerable()
                        .Select(x =>
                        {
                            // NOTE: This is needed, because the actual
                            // area name of these maps is DrillCamp (not plural)
                            x.AreaName = Labels.DrillCamps;
                            return SelectMap(x);

                        });
                }

                // else --> return all drill camp maps
                return maps.Where(x => Maps.DrillCampMaps.Contains(x.ID) || 
                            x.MapType == Labels.Conquest && x.AreaName == Labels.DrillCamp)
                    .OrderBy(x => x.Name)
                    .AsEnumerable()
                    .Select(x =>
                    {
                        // NOTE: This is needed, because the actual
                        // area name of the drill camps is HarperFerry
                        x.AreaName = Labels.DrillCamps;
                        return SelectMap(x);

                    });
            }

            if (!string.IsNullOrEmpty(mode))
            {
                maps = maps.Where(x => x.MapType == mode);
            }

            if (Labels.Antietam.Equals(area) ||
                Labels.SouthMountain.Equals(area) ||
                Labels.HarpersFerry.Equals(area))
            {
                return maps.Where(x => x.AreaName == area)
                    .OrderBy(x => x.Order)
                    .Select(x => SelectMap(x));
            }

            // else return all 
            // maps ordered by name
            return maps
                .OrderBy(x => x.Name)
                .AsEnumerable()
                .Select(x =>
                {
                    if (x.AreaName == Labels.DrillCamp)
                    {
                        // NOTE: This is needed, because the actual
                        // area name of these maps is DrillCamp (not plural)
                        x.AreaName = Labels.DrillCamps;
                    }

                    return SelectMap(x);
                });
        }

        private string GetMapView(Map map, string area)
        {
            var viewName = $"{area}/{map.ID}";
            var result = _viewEngine.FindView(ControllerContext, viewName, false);

            if (!result.Success)
            {
                return Labels.GenericMapViewName;
            }

            return viewName;
        }

        private static Map SelectMap(Map x)
        {
            return new Map()
            {
                ID = x.ID,
                Name = x.Name,
                AreaName = x.AreaName,
                DateTimeDescription = x.DateTimeDescription,
                DefendingTeam = x.DefendingTeam,
                Description = x.Description,
                SkirmishImagePath = x.SkirmishImagePath,
            };
        }
    }
}