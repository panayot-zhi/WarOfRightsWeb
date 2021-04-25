using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IActionResult> Index(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var model = await GetRegimentAsync(id);
                if (model == null)
                {
                    return NotFound();
                }

                return View("Regiment", model);
            }

            return View();
        }

        public IActionResult USA()
        {
            return View();
        }

        public IActionResult CSA()
        {
            return View();
        }

        private async Task<Regiment> GetRegimentAsync(string id)
        {
            return await _db.Regiments.SingleOrDefaultAsync(x => x.ID == id);
        }
    }
}