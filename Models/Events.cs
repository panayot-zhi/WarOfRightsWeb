using System;
using System.Collections.Generic;
using WarOfRightsWeb.Common;

namespace WarOfRightsWeb.Models
{
    public class EventsViewModel
    {
        public Event Current { get; set; }

        public IList<Event> EventTemplates { get; set; }

        public IList<Event> ScheduledEvents { get; set; }
    }

    public class Event
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime Starting { get; set; }

        public DayOfWeek WeekDay => this.Starting.DayOfWeek;

        public TimeSpan Time => this.Starting.TimeOfDay;

        public EventOccurrence Occurring { get; set; }

        public TimeSpan Duration { get; set; }
    }
}
