using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WarOfRightsWeb.Constants;

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

        public static string AreaFromMap(string mapId)
        {
            switch (mapId)
            {
                case Maps.EastWoodsSkirmish:
                case Maps.HookersPush:
                case Maps.HagerstownTurnpike:
                case Maps.MillersCornfield:
                case Maps.EastWoods:
                case Maps.NicodemusHill:
                case Maps.BloodyLane:
                case Maps.PryFord:
                case Maps.PryGristMill:
                case Maps.PryHouse:
                case Maps.WestWoods:
                case Maps.DunkerChurch:
                case Maps.BurnsideBridge:
                case Maps.CookesCountercharge:
                case Maps.OttoSherrickFarm:
                case Maps.RouletteLane:
                case Maps.PiperFarm:
                case Maps.HillsCounterattack:
                    return "Antietam";

                case Maps.MarylandHeights:
                case Maps.RiverCrossing:
                case Maps.Downtown:
                case Maps.SchoolHouseRidge:
                case Maps.HighStreet:
                case Maps.BolivarHeightsCamp:
                case Maps.ShenandoahStreet:
                case Maps.HarpersGraveyard:
                case Maps.BolivarHeightsRedoubt:
                case Maps.WashingtonStreet:
                    return "HarpersFerry";

                case Maps.GarlandsStand:
                case Maps.CoxsPush:
                case Maps.HatchsAttack:
                case Maps.AndersonsCounterattack:
                case Maps.RenosFall:
                case Maps.ColquittsDefence:
                    return "SouthMountain";

                case Maps.DrillCampCSA:
                case Maps.DrillCampUSA:
                case Maps.HarpersFerryUSA:
                    return "DrillCamps";

                case Maps.PicketPatrol:
                    return "PicketPatrol";

                default:
                    return mapId;
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
            var imagePath = System.IO.Path.Combine(_hostingEnvironment.WebRootPath, "img", type, $"{name}.jpg");
            var imageExists = System.IO.File.Exists(imagePath);
            if (imageExists)
            {
                return urlHelper.Content($"~/img/{type}/{name}.jpg");
            }

            imagePath = System.IO.Path.Combine(_hostingEnvironment.WebRootPath, "img", type, $"{name}.png");
            imageExists = System.IO.File.Exists(imagePath);
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

        public static string PathToUrl(string path)
        {
            return path.Replace('\\', '/');
        } 
    }
}
