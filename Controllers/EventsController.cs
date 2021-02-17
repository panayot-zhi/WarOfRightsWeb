using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WarOfRightsWeb.Constants;

namespace WarOfRightsWeb.Controllers
{
    public class EventsController : Controller
    {
        private readonly IConfiguration _configuration;

        public EventsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            var events = new List<Event>();
            _configuration.GetSection("Events").Bind(events);

            return View(events);
        }
    }
}
