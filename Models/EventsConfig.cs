using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using WarOfRightsWeb.Common;

namespace WarOfRightsWeb.Models
{
    public class EventsViewModel
    {
        public Event Current { get; set; }

        public IList<Event> EventTemplates { get; set; }

        public IList<Event> ScheduledEvents { get; set; }
    }

    public class EventEmbedData
    {
        public List<string> AcceptedAttendees { get; set; } = new();

        public List<string> DeclinedAttendees { get; set; } = new();

        public List<string> TentativeAttendees { get; set; } = new();

        public Event EventData { get; set; }
    }

    public class Event
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime Starting { get; set; }

        [JsonIgnore]
        public DayOfWeek WeekDay => this.Starting.DayOfWeek;

        [JsonIgnore]
        public TimeSpan Time => this.Starting.TimeOfDay;

        public EventOccurrence Occurring { get; set; }

        public TimeSpan Duration { get; set; }

        public bool Enabled { get; set; }
    }
}
