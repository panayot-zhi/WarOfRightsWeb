﻿using System;
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
        Weekly,
        WeekDayMonthly,
        ExactDayYearly,
        OnlyOnce
    }
}
