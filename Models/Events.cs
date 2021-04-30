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

        public string At { get; set; }

        public EventOccurrence Occurring { get; set; }

        public TimeSpan Duration { get; set; }


        private DateTimeOffset? _starting;

        public DateTimeOffset? Starting
        {
            get
            {
                if (this.Occurring == EventOccurrence.Weekly)
                {
                    // NOTE: No exact starting date should exists for that event type
                    return null;
                }

                if (!_starting.HasValue)
                {
                    _starting = DateTimeOffset.Parse(this.At);
                }

                return _starting;
            }
        }

        private DayOfWeek? _weekDay;

        public DayOfWeek WeekDay 
        {
            get
            {
                if (_weekDay.HasValue)
                {
                    return _weekDay.Value;
                }

                if (_starting.HasValue)
                {
                    _weekDay = _starting.Value.DayOfWeek;
                }
                else
                {
                    if (!Enum.TryParse(this.At, out DayOfWeek candidate))
                    {
                        throw new ArgumentException($"The value of the event '{nameof(At)}' property is not known and cannot be elaborated.", nameof(At));
                    }

                    _weekDay = candidate;

                }

                return _weekDay.Value;
            }
        
        }

        /// <summary>
        /// This date gets calculated when events are resolved from the controller.
        /// It is supposed to represent the real date of an scheduled event resolved from an event template.
        /// </summary>
        public DateTimeOffset ExactDate { get; set; }
    }


}
