using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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

            var scheduledEvents = CalculateEventDates(eventTemplates, out var nextEventInLine);
            
            var vModel = new EventsViewModel()
            {
                Current = nextEventInLine,
                EventTemplates = scheduledEvents
            };

            return View(vModel);
        }

        private static IList<Event> CalculateEventDates(IReadOnlyCollection<Event> eventTemplates, out Event next)
        {
            // TODO: Abstract that away
            var now = DateTime.Now.Date;
            // var now = new DateTime(2021, 1, 7).Date;
            var start = now.AddDays(-7);
            var end = now.AddDays(7);
            next = null;
            var day = 0;
            var result = new List<Event>();
            while (day < (end - start).TotalDays)
            {
                var current = start.AddDays(day++);

                var eventTemplate = ResolveEventTemplate(eventTemplates, current);
                if (eventTemplate == null)
                {
                    continue;
                }

                var scheduledEvent = new Event()
                {
                    Name = eventTemplate.Name,
                    ShortDescription = eventTemplate.ShortDescription,
                    Description = eventTemplate.Description,
                    Starting = eventTemplate.Starting,
                    Occurring = eventTemplate.Occurring,
                    Duration = eventTemplate.Duration,

                    ExactDate = current.Add(eventTemplate.Time)
                };

                if (next == null && scheduledEvent.ExactDate >= now)
                {
                    next = scheduledEvent;
                }

                result.Add(scheduledEvent);
            }

            return result;

        }

        private static Event ResolveEventTemplate(IEnumerable<Event> eventTemplates, DateTime current)
        {
            var candidates = eventTemplates.Where(x => x.WeekDay == current.DayOfWeek)
                .OrderByDescending(x => x.Occurring).ToList();

            if (!candidates.Any())
            {
                return null;
            }

            foreach (var eventTemplate in candidates)
            {
                if (eventTemplate.Occurring == EventOccurrence.Once)
                {
                    if (eventTemplate.Starting.Date == current.Date)
                    {
                        return eventTemplate;
                    }

                    continue;
                }

                if (eventTemplate.Occurring == EventOccurrence.Monthly)
                {
                    var difference = current.Month - eventTemplate.Starting.Month;
                    if (current.AddMonths(-difference) == eventTemplate.Starting.Date)
                    {
                        return eventTemplate;
                    }

                    continue;
                }

                if (eventTemplate.Occurring == EventOccurrence.Weekly)
                {
                    return eventTemplate;
                }
            }

            return null;
        }
    }
}
