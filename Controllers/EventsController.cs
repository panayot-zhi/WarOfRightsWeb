using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Serilog;
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
            var dateNow = DateTime.Now.Date;
            var firstDayOfTheMonth = new DateTime(dateNow.Year, dateNow.Month, 1);

            var startDate = firstDayOfTheMonth.AddMonths(-1);
            var endDate = firstDayOfTheMonth.AddMonths(2).AddDays(-1);

            var scheduledEvents = new List<Event>();

            var eventTemplates = _configuration.GetEventTemplates();
            
            foreach (var currentDate in Extensions.EachDay(startDate, endDate))
            {
                scheduledEvents.AddRange(Extensions.GetEventsByDate(eventTemplates, currentDate));
            }

            scheduledEvents = scheduledEvents.OrderBy(x => x.Starting)
                .ThenByDescending(x => x.Occurring).ToList();

            // Filter weekly events within the range of 2 weeks from the current moment
            scheduledEvents.RemoveAll(x => x.Occurring == EventOccurrence.Weekly &&
                                           (x.Starting < DateTime.Now.AddDays(-7) ||
                                           x.Starting > DateTime.Now.AddDays(7)));

            var vModel = new EventsViewModel()
            {
                Current = scheduledEvents.GetNextEvent(),
                EventTemplates = eventTemplates,
                ScheduledEvents = scheduledEvents
            };

            return View(vModel);
        }

        public IActionResult EventsAt(long utcDate)
        {
            var eventTemplates = _configuration.GetEventTemplates();
            var currentDate = DateTimeOffset.FromUnixTimeSeconds(utcDate).ToLocalTime();
            var eventsOnThisDate = Extensions.GetEventsByDate(eventTemplates, currentDate.DateTime)
                .OrderByDescending(x => x.Occurring).ToList();

            if (eventsOnThisDate.Count == 0)
            {
                return NoContent();
            }

            if (eventsOnThisDate.Count > 1)
            {
                Log.Warning("More than one event found at this date which is not supported for preview!");
            }

            return PartialView("_Event", eventsOnThisDate.FirstOrDefault());
        }
    }
}
