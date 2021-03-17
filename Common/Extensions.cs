using System;
using WarOfRightsWeb.Constants;

namespace WarOfRightsWeb.Common
{
    public static class Extensions
    {
        private static readonly Random Random = new();

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
                    return "DrillCamps";

                case Maps.PicketPatrol:
                    return "PicketPatrol";

                case Maps.HarpersFerryUSA:
                    return "BolivarHeightsCampUSA";

                default:
                    return mapId;
            }
        }

        public static string RandomTip()
        {
            return Misc.Tips[Random.Next(Misc.Tips.Length)];
        }
    }
}
