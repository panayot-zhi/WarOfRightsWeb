using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarOfRightsWeb.Common
{
    public enum RegimentType
    {
        Infantry,
        Artillery
    }

    public enum EventOccurrence
    {
        /// <summary>
        /// Occurs every week at the week day of the
        /// starting property of the event.
        /// </summary>
        Weekly,

        /// <summary>
        /// Occurs on the first week day of every month
        /// according to the starting date.
        /// </summary>
        Monthly,

        /// <summary>
        /// Occurs yearly on a specific date.
        /// Like for example an anniversary.
        /// </summary>
        Yearly,

        /// <summary>
        /// For events that occur only once.
        /// Note that these events are automatically deleted
        /// 1 month after they have passed
        /// </summary>
        Once
    }
}
