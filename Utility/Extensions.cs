using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace WarOfRightsWeb.Utility
{
    public static class Extensions
    {
        public static string Normalize(string mapName)
        {
            return mapName?
                .Replace("'", string.Empty)
                .Replace("&", string.Empty)
                .Replace(" ", string.Empty);
        }
    }
}
