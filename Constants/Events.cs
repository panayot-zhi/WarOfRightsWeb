using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarOfRightsWeb.Constants
{
    public class Event
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Starting { get; set; }

        public EventOccurrence Occurring { get; set; }

        public string Time { get; set; }

        public DateTimeOffset ExactDate { get; set; }
    }

    public enum EventOccurrence
    {
        Once,
        Daily,
        Weekly,
        Monthly
    }
}
