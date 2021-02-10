using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarOfRightsWeb.Utility
{
    public static class Maps
    {
        public const string EastWoodsSkirmish = "East Woods Skirmish";
        public const string HookersPush = "Hooker's Push";
        public const string HagerstownTurnpike = "Hagerstown Turnpike";
        public const string MillersCornfield = "Miller's Cornfield";
        public const string EastWoods = "East Woods";
        public const string NicodemusHill = "Nicodemus Hill";
        public const string BloodyLane = "Bloody Lane";
        public const string PryFord = "Pry Ford";
        public const string PryGristMill = "Pry Grist Mill";
        public const string PryHouse = "Pry House";
        public const string WestWoods = "West Woods";
        public const string DunkerChurch = "Dunker Church";
        public const string BurnsideBridge = "Burnside Bridge";
        public const string CookesCountercharge = "Cooke's Countercharge";
        public const string OttoSherrickFarm = "Otto & Sherrick Farm";
        public const string RouletteLane = "Roulette Lane";
        public const string PiperFarm = "Piper Farm";
        public const string HillsCounterattack = "Hill's Counterattack";

        public const string MarylandHeights = "Maryland Heights";
        public const string RiverCrossing = "River Crossing";
        public const string Downtown = "Downtown";
        public const string SchoolHouseRidge = "School House Ridge";
        public const string HighStreet = "High Street";
        public const string BolivarHeightsCamp = "Bolivar Heights Camp";
        public const string ShenandoahStreet = "Shenandoah Street";
        public const string HarpersGraveyard = "Harpers Graveyard";
        public const string BolivarHeightsRedoubt = "Bolivar Heights Redoubt";
        public const string WashingtonStreet = "Washington Street";

        public const string GarlandsStand = "Garland's Stand";
        public const string CoxsPush = "Cox's Push";
        public const string HatchsAttack = "Hatch's Attack";
        public const string AndersonsCounterattack = "Anderson's Counterattack";
        public const string RenosFall = "Reno's Fall";
        public const string ColquittsDefence = "Colquitt's Defence";

        public const string DrillCampUSA = "Drill Camp USA";
        public const string DrillCampCSA = "Drill Camp CSA";

        public const string HarpersFerryBolivarHeightsCamp = "Harpers Ferry Bolivar Heights Camp USA";

        public const string PicketPatrol = "Picket Patrol";

        public static string Normalize(string mapName)
        {
            return mapName?
                .Replace("'", string.Empty)
                .Replace("&", string.Empty)
                .Replace(" ", string.Empty);
        }

        public static string AreaFromMapName(string mapName)
        {
            switch (mapName)
            {
                case EastWoodsSkirmish:
                case HookersPush:
                case HagerstownTurnpike:
                case MillersCornfield:
                case EastWoods:
                case NicodemusHill:
                case BloodyLane:
                case PryFord:
                case PryGristMill:
                case PryHouse:
                case WestWoods:
                case DunkerChurch:
                case BurnsideBridge:
                case CookesCountercharge:
                case OttoSherrickFarm:
                case RouletteLane:
                case PiperFarm:
                case HillsCounterattack:
                    return "Antietam";

                case MarylandHeights:
                case RiverCrossing:
                case Downtown:
                case SchoolHouseRidge:
                case HighStreet:
                case BolivarHeightsCamp:
                case ShenandoahStreet:
                case HarpersGraveyard:
                case BolivarHeightsRedoubt:
                case WashingtonStreet:
                    return "HarpersFerry";

                case GarlandsStand:
                case CoxsPush:
                case HatchsAttack:
                case AndersonsCounterattack:
                case RenosFall:
                case ColquittsDefence:
                    return "SouthMountain";

                case DrillCampCSA:
                case DrillCampUSA:
                    return "DrillCamps";

                default: 
                    return mapName;
            }
        }

        public static Dictionary<string, string> Descriptions = new Dictionary<string, string>()
        {
            { Normalize(EastWoodsSkirmish), "TODO" },
            { Normalize(HookersPush), "TODO" },
            { Normalize(HagerstownTurnpike), "TODO" },
            { Normalize(MillersCornfield), "TODO" },
            { Normalize(EastWoods), "TODO" },
            { Normalize(NicodemusHill), "TODO" },
            { Normalize(BloodyLane), "TODO" },
            { Normalize(PryFord), "TODO" },
            { Normalize(PryGristMill), "TODO" },
            { Normalize(PryHouse), "TODO" },
            { Normalize(WestWoods), "TODO" },
            { Normalize(DunkerChurch), "TODO" },
            { Normalize(BurnsideBridge), "TODO" },
            { Normalize(CookesCountercharge), "TODO" },
            { Normalize(OttoSherrickFarm), "TODO" },
            { Normalize(RouletteLane), "TODO" },
            { Normalize(PiperFarm), "TODO" },
            { Normalize(HillsCounterattack), "TODO" },

            { Normalize(MarylandHeights), "TODO" },
            { Normalize(RiverCrossing), "TODO" },
            { Normalize(Downtown), "TODO" },
            { Normalize(SchoolHouseRidge), "TODO" },
            { Normalize(HighStreet), "TODO" },
            { Normalize(BolivarHeightsCamp), "TODO" },
            { Normalize(ShenandoahStreet), "TODO" },
            { Normalize(HarpersGraveyard), "TODO" },
            { Normalize(BolivarHeightsRedoubt), "TODO" },
            { Normalize(WashingtonStreet), "TODO" },

            { Normalize(GarlandsStand), "TODO" },
            { Normalize(CoxsPush), "TODO" },
            { Normalize(HatchsAttack), "TODO" },
            { Normalize(AndersonsCounterattack), "TODO" },
            { Normalize(RenosFall), "TODO" },
            { Normalize(ColquittsDefence), "TODO" },

            { Normalize(DrillCampUSA), "TODO" },
            { Normalize(DrillCampCSA), "TODO" },

            { Normalize(HarpersFerryBolivarHeightsCamp), "TODO" },

            { Normalize(PicketPatrol), "TODO" },
        };
    }
}
