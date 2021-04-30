using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WarOfRightsWeb.Common;
using WarOfRightsWeb.Models;

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
            var eventTemplates = new List<Event>();

            _configuration.GetSection("Events").Bind(eventTemplates);

            var dateNow = DateTimeOffset.Now.Date;
            var firstDayOfTheMonth = new DateTime(dateNow.Year, dateNow.Month, 1);

            var startDate = firstDayOfTheMonth.AddMonths(-1);
            var endDate = firstDayOfTheMonth.AddMonths(2).AddDays(-1);

            var scheduledEvents = new List<Event>();

            foreach (var currentDate in Extensions.EachDay(startDate, endDate))
            {
                scheduledEvents.AddRange(Extensions.GetEventsByDate(eventTemplates, currentDate));
            }

            scheduledEvents = scheduledEvents.OrderBy(x => x.Starting)
                .ThenByDescending(x => x.Occurring).ToList();

            var vModel = new EventsViewModel()
            {
                Current = scheduledEvents.GetNextEvent(),
                EventTemplates = eventTemplates,
                ScheduledEvents = scheduledEvents
            };

            return View(vModel);
        }

        public IActionResult Event(DateTimeOffset currentDate)
        {
            var eventTemplates = new List<Event>();

            _configuration.GetSection("Events").Bind(eventTemplates);

            var eventsOnThisDate = Extensions.GetEventsByDate(eventTemplates, currentDate.Date)
                .OrderByDescending(x => x.Occurring).ToList();

            return Json(eventsOnThisDate, new JsonSerializerOptions()
            {
                WriteIndented = true
            });
        }
    }
}
