using System;
using System.Security.Policy;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using WarOfRightsWeb.Constants;

namespace WarOfRightsWeb.Common
{
    public static class Extensions
    {
        private static readonly Random Random = new();

        private static IWebHostEnvironment _hostingEnvironment;

        private static readonly object Initializator = new object();
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

        public static string Normalize(string mapName)
        {
            return mapName?
                .Replace("'", string.Empty)
                .Replace("&", string.Empty)
                .Replace(" ", string.Empty);
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

        public static string RegimentType(string regiment)
        {
            if (regiment.StartsWith(Labels.Battery) || regiment.StartsWith(Labels.HeavyArtillery))
            {
                return Labels.Artillery;
            }

            return Labels.Infantry;
        }

        public static string RegimentFaction(string regiment)
        {
            switch (regiment)
            {
                case Regiments.NewYork52nd:
                case Regiments.Pennsylvania6th:
                case Regiments.Pennsylvania4th:
                case Regiments.Minnesota1st:
                case Regiments.USSharpshooters1st:
                case Regiments.UnitedStates2nd:
                case Regiments.Wisconsin6th:
                case Regiments.Ohio8th:
                case Regiments.NewYork5th:
                case Regiments.NewYork9th:
                case Regiments.Brooklyn14th:
                case Regiments.Maine20th:
                case Regiments.Pennsylvania42nd:
                case Regiments.NewYork69th:
                case Regiments.Wisconsin2nd:
                case Regiments.UnitedStates10th:
                case Regiments.RhodeIsland4th:
                case Regiments.Pennsylvania72nd:
                case Regiments.Pennsylvania32nd:
                case Regiments.Pennsylvania28th:
                case Regiments.NewYork51st:
                case Regiments.NewYork20th:
                case Regiments.Michigan7th:
                case Regiments.Massachusetts28th:
                case Regiments.Massachusetts15th:
                case Regiments.Maryland2nd:
                case Regiments.Maine7th:
                case Regiments.Indiana14th:
                case Regiments.Delaware1st:
                case Regiments.Pennsylvania114th:
                case Regiments.Vermont9th:
                case Regiments.Michigan17th:
                case Regiments.Illinois65th:
                case Regiments.Mississippi18th:
                case Regiments.MarylandPHB1st:
                case Regiments.MarylandPHB3rd:
                case Regiments.NewYorkMilitia12th:
                case Regiments.Ohio87th:
                case Regiments.NewYork39th:
                case Regiments.Ohio32nd:
                case Regiments.NewYork126th:
                case Regiments.Ohio23rd:
                case Regiments.Ohio30th:
                case Regiments.Ohio12th:
                case Regiments.Ohio36th:
                case Regiments.Pennsylvania51st:
                case Regiments.NewYork89th:
                case Regiments.Indiana19th:
                case Regiments.USSharpshooters2nd:
                case Regiments.NewYork23rd:
                case Regiments.BatteryCampbell:
                case Regiments.BatteryClark:
                case Regiments.BatteryCook:
                case Regiments.BatteryCooper:
                case Regiments.BatteryCrome:
                case Regiments.BatteryEdgell:
                case Regiments.BatteryGlassie:
                case Regiments.BatteryGraham:
                case Regiments.HeavyArtilleryGraham:
                case Regiments.BatteryHexamer:
                case Regiments.BatteryLangner:
                case Regiments.BatteryMatthews:
                case Regiments.BatteryMcGilvery:
                case Regiments.BatteryOwen:
                case Regiments.BatteryPhillips:
                case Regiments.BatteryPotts:
                case Regiments.BatteryRansom:
                case Regiments.BatteryReynolds:
                case Regiments.BatteryRigby:
                case Regiments.BatteryStewart:
                case Regiments.BatteryThompson:
                case Regiments.BatteryTompkins:
                case Regiments.BatteryVonSehlen:
                case Regiments.BatteryWeaver:
                    return Labels.USA;
                case Regiments.LouisianaZouaves1st:
                case Regiments.NCSharpshooters1st:
                case Regiments.Texas1st:
                case Regiments.VirginiaBtl1st:
                case Regiments.Georgia2nd:
                case Regiments.Mississippi2nd:
                case Regiments.Arkansas3rd:
                case Regiments.Virginia5th:
                case Regiments.Alabama6th:
                case Regiments.SouthCarolina12th:
                case Regiments.NorthCarolina27th:
                case Regiments.Virginia33rd:
                case Regiments.Virginia30th:
                case Regiments.Virginia13th:
                case Regiments.VirginiaCavalry1st:
                case Regiments.Texas5th:
                case Regiments.Texas4th:
                case Regiments.PalmettoSharpshooters:
                case Regiments.HolcombeLegion:
                case Regiments.SouthCarolina17th:
                case Regiments.SouthCarolina3rd:
                case Regiments.SouthCarolina2nd:
                case Regiments.NorthCarolina14th:
                case Regiments.Louisiana6th:
                case Regiments.Georgia20th:
                case Regiments.Georgia18th:
                case Regiments.Georgia1st:
                case Regiments.Florida8th:
                case Regiments.Alabama8th:
                case Regiments.Alabama4th:
                case Regiments.Louisiana9th:
                case Regiments.Tennessee14th:
                case Regiments.NorthCarolina18th:
                case Regiments.AlabamaBtl5th:
                case Regiments.VirginiaBtl22nd:
                case Regiments.Georgia13th:
                case Regiments.HamptonLegion:
                case Regiments.NorthCarolina13th:
                case Regiments.NorthCarolina20th:
                case Regiments.NorthCarolina5th:
                case Regiments.NorthCarolina23rd:
                case Regiments.NorthCarolina4th:
                case Regiments.NorthCarolina2nd:
                case Regiments.Virginia56th:
                case Regiments.Alabama13th:
                case Regiments.Georgia6th:
                case Regiments.Virginia18th:
                case Regiments.BatteryBalthis:
                case Regiments.BatteryBlackshear:
                case Regiments.BatteryBondurant:
                case Regiments.BatteryBraxton:
                case Regiments.BatteryBrockenbrough:
                case Regiments.BatteryBrooks:
                case Regiments.BatteryBrown:
                case Regiments.BatteryCarlton:
                case Regiments.BatteryCarpenter:
                case Regiments.BatteryCourtney:
                case Regiments.BatteryDAquin:
                case Regiments.BatteryFrench:
                case Regiments.BatteryJordan:
                case Regiments.BatteryLane:
                case Regiments.BatteryManly:
                case Regiments.BatteryMaurin:
                case Regiments.BatteryMiller:
                case Regiments.BatteryPelham:
                case Regiments.BatteryPoague:
                case Regiments.BatteryRead:
                case Regiments.BatteryReily:
                case Regiments.BatteryRichardson:
                case Regiments.BatterySquires:
                case Regiments.BatteryWooding:
                case Regiments.BatteryBoyce:
                    return Labels.CSA;
            }

            throw new ArgumentException($"Unknown regiment '{regiment}'");
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
    }
}
