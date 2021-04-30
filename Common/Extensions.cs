﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
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
            return urlHelper.RegimentImageIfExists($"{faction}_{type}_{regiment}_{character}") ??
                   urlHelper.RegimentImageIfExists($"{faction}_{type}_default_{character}");
        }

        public static string RegimentImageOrDefault(this IUrlHelper urlHelper, string faction, string type, string regiment, string character)
        {
            return urlHelper.RegimentImageIfExists($"{faction}_{type}_{regiment}_{character}") ??
                   urlHelper.RegimentImageIfExists($"{faction}_{type}_default_{character}");
        }

        public static string RegimentImageIfExists(this IUrlHelper urlHelper, string name)
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
            var oneTimeEvents = eventTemplates.GetOccurringEventTemplates(EventOccurrence.OnlyOnce, currentDate).ToList();
            if (oneTimeEvents.Any())
            {
                result.AddRange(oneTimeEvents);
            }

            var yearlyEvents = eventTemplates.GetOccurringEventTemplates(EventOccurrence.ExactDayYearly, currentDate).ToList();
            if (yearlyEvents.Any())
            {
                result.AddRange(yearlyEvents);
            }

            var weekDayMonthlyEvents = eventTemplates.GetOccurringEventTemplates(EventOccurrence.FirstWeekDayMonthly, currentDate).ToList();
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

                    // construct a GMT date
                    Starting = new DateTimeOffset(
                        day.Year, 
                        day.Month, 
                        day.Day, 
                        eventTemplate.Starting.Hour,
                        eventTemplate.Starting.Minute,
                        eventTemplate.Starting.Second,
                        TimeSpan.Zero
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

                case EventOccurrence.FirstWeekDayMonthly:

                    // With events that occur on a first week day of the month we have to resolve the day first and then compare

                    return eventTemplates
                        .Where(eventTemplate => eventTemplate.Occurring == EventOccurrence.FirstWeekDayMonthly &&
                                                GetFirstDayOfTheMonth(day.Year, day.Month, eventTemplate.WeekDay) == day)
                        .Select(ConstructEvent);

                case EventOccurrence.ExactDayYearly:

                    // With exact yearly events only the month and the day should match

                    return eventTemplates
                        .Where(eventTemplate => eventTemplate.Occurring == EventOccurrence.ExactDayYearly &&
                                         eventTemplate.Starting.Date.Day == day.Day &&
                                         eventTemplate.Starting.Date.Month == day.Month)
                        .Select(ConstructEvent);

                case EventOccurrence.OnlyOnce:

                    // With one time event types we just check the start date

                    return eventTemplates
                        .Where(eventTemplate => eventTemplate.Occurring == EventOccurrence.OnlyOnce &&
                                         eventTemplate.Starting.Date == day)
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
                .FirstOrDefault(x => x.Starting > DateTimeOffset.Now);
        }

        public static string PathToUrl(string path)
        {
            return path.Replace('\\', '/');
        } 
    }
}
