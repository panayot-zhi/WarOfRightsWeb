using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WarOfRightsWeb.Constants;
using WarOfRightsWeb.Models;

namespace WarOfRightsWeb.Common
{
    public static class Extensions
    {
        private static readonly Random Random = new();
        private static readonly object Initializator = new();
        private static IWebHostEnvironment _hostingEnvironment;
        private static bool _initialized;

        public static void Initialize(IWebHostEnvironment hostEnvironment)
        {
            lock (Initializator)
            {
                if (_initialized)
                {
                    return;
                }

                _hostingEnvironment = hostEnvironment;
                _initialized = true;
            }
        }

        public static string RandomTip()
        {
            return Misc.Tips[Random.Next(Misc.Tips.Length)];
        }

        public static string SecondsToMinutes(int? seconds)
        {
            return SecondsToMinutes(seconds.ToString());
        }

        public static string SecondsToMinutes(string seconds)
        {
            if (string.IsNullOrEmpty(seconds))
            {
                return seconds;
            }

            if (int.TryParse(seconds, out var result))
            {
                return $"{Math.Floor(result / 60d)}:{result % 60}";
            }

            return seconds;
        }

        public static string RegimentImageOrDefault(this IUrlHelper urlHelper, string faction, RegimentType type,
            string regiment, string character)
        {
            return RegimentImageOrDefault(urlHelper, faction, type.ToString(), regiment, character);
        }

        public static string RegimentImageOrDefault(this IUrlHelper urlHelper, string faction, string type, 
            string regiment, string character)
        {
            return urlHelper.RegimentImageIfExists($"{faction.ToLowerInvariant()}_{type.ToLowerInvariant()}_{regiment}_{character}") ??
                   urlHelper.RegimentImageIfExists($"{faction.ToLowerInvariant()}_{type.ToLowerInvariant()}_default_{character}");
        }

        private static string RegimentImageIfExists(this IUrlHelper urlHelper, string name)
        {
            return ImageIfExists(urlHelper, name, "regiments");
        }

        public static string WeaponImageIfExists(this IUrlHelper urlHelper, string name)
        {
            return ImageIfExists(urlHelper, name, "weapons");
        }

        public static string ImageIfExists(this IUrlHelper urlHelper, string name, string type)
        {
            var imagePath = Path.Combine(_hostingEnvironment.WebRootPath, "img", type, $"{name}.jpg");
            var imageExists = File.Exists(imagePath);
            if (imageExists)
            {
                return urlHelper.Content($"~/img/{type}/{name}.jpg");
            }

            imagePath = Path.Combine(_hostingEnvironment.WebRootPath, "img", type, $"{name}.png");
            imageExists = File.Exists(imagePath);
            if (imageExists)
            {
                return urlHelper.Content($"~/img/{type}/{name}.png");
            }

            return null;
        }

        public static string AudioIfExists(this IUrlHelper urlHelper, string name)
        {
            var audioPath = Path.Combine(_hostingEnvironment.WebRootPath, "audio", $"{name}.ogg");
            var audioExists = File.Exists(audioPath);
            if (audioExists)
            {
                return urlHelper.Content($"~/audio/{name}.ogg");
            }

            return null;
        }

        public static IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
            {
                yield return day;
            }
        }

        public static DateTime GetFirstDayOfTheMonth(int year, int month, DayOfWeek day)
        {
            var result = new DateTime(year, month, 1);
            while (result.DayOfWeek != day)
            {
                result = result.AddDays(1);
            }

            return result;
        }

        public static IEnumerable<Event> GetEventsByDate(IReadOnlyCollection<Event> eventTemplates, DateTime currentDate)
        {
            var result = new List<Event>();
            var oneTimeEvents = eventTemplates.GetOccurringEventTemplates(EventOccurrence.Once, currentDate).ToList();
            if (oneTimeEvents.Any())
            {
                result.AddRange(oneTimeEvents);
            }

            var yearlyEvents = eventTemplates.GetOccurringEventTemplates(EventOccurrence.Yearly, currentDate).ToList();
            if (yearlyEvents.Any())
            {
                result.AddRange(yearlyEvents);
            }

            var weekDayMonthlyEvents = eventTemplates.GetOccurringEventTemplates(EventOccurrence.Monthly, currentDate).ToList();
            if (weekDayMonthlyEvents.Any())
            {
                result.AddRange(weekDayMonthlyEvents);
            }

            var weeklyEvents = eventTemplates.GetOccurringEventTemplates(EventOccurrence.Weekly, currentDate).ToList();
            if (weeklyEvents.Any())
            {
                result.AddRange(weeklyEvents);
            }

            return result;
        }

        public static IEnumerable<Event> GetOccurringEventTemplates(this IEnumerable<Event> eventTemplates,
            EventOccurrence occurrence, DateTime day)
        {
            Event ConstructEvent(Event eventTemplate) =>
                new()
                {
                    Name = eventTemplate.Name,
                    Description = eventTemplate.Description,
                    Occurring = eventTemplate.Occurring,
                    Duration = eventTemplate.Duration,

                    // construct a local date
                    Starting = new DateTime(
                        day.Year, 
                        day.Month, 
                        day.Day, 
                        eventTemplate.Starting.Hour,
                        eventTemplate.Starting.Minute,
                        eventTemplate.Starting.Second,
                        DateTimeKind.Local
                    )
                };

            switch (occurrence)
            {
                case EventOccurrence.Weekly:

                    // With weekly events we just compare the week date of the event template

                    return eventTemplates
                        .Where(eventTemplate => eventTemplate.Occurring == EventOccurrence.Weekly &&
                                                eventTemplate.WeekDay == day.DayOfWeek)
                        .Select(ConstructEvent);

                case EventOccurrence.Monthly:

                    // With events that occur on a first week day of the month we have to resolve the day first and then compare

                    return eventTemplates
                        .Where(eventTemplate => eventTemplate.Occurring == EventOccurrence.Monthly &&
                                                GetFirstDayOfTheMonth(day.Year, day.Month, eventTemplate.WeekDay) == day)
                        .Select(ConstructEvent);

                case EventOccurrence.Yearly:

                    // With exact yearly events only the month and the day should match

                    return eventTemplates
                        .Where(eventTemplate => eventTemplate.Occurring == EventOccurrence.Yearly &&
                                         eventTemplate.Starting.Date.Day == day.Day &&
                                         eventTemplate.Starting.Date.Month == day.Month)
                        .Select(ConstructEvent);

                case EventOccurrence.Once:

                    // With one time event types we just check if it is on this day or hour

                    return eventTemplates
                        .Where(eventTemplate => eventTemplate.Occurring == EventOccurrence.Once &&
                                         (eventTemplate.Starting.Date == day || eventTemplate.Starting == day))
                        .Select(ConstructEvent);

                default:
                    throw new ArgumentOutOfRangeException(nameof(occurrence), occurrence, 
                        $"This event occurrence type ('{occurrence}') is not supported.");
            }
        }

        public static Event GetNextEvent(this IEnumerable<Event> scheduledEvents)
        {
            return scheduledEvents.OrderBy(x => x.Starting)
                .ThenByDescending(x => x.Occurring)
                .FirstOrDefault(x => x.Starting.Add(x.Duration) > DateTime.Now);
        }

        public static string PathToUrl(string path)
        {
            if (path == null)
            {
                return null;
            }

            return path.Replace('\\', '/');
        }

        public static bool IsLoggedIn(this ClaimsPrincipal user)
        {
            if (user == null)
            {
                return false;
            }

            if (user.Identity == null)
            {
                return false;
            }

            return user.Identity.IsAuthenticated;
        }

        public static List<Event> GetEventTemplates(this IConfiguration configuration)
        {
            var eventTemplates = new List<Event>();

            configuration.GetSection("Events").Bind(eventTemplates);

            eventTemplates.ForEach(x => x.Starting = DateTime.SpecifyKind(x.Starting, DateTimeKind.Local));

            return eventTemplates;
        }
    }
}
