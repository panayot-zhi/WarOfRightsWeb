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

    public static class Regiments
    {
        /*public const string Brooklyn14th = "5th Connecticut";
        public const string Brooklyn14th = "16th Connecticut";

        public const string Brooklyn14th = "1st Delaware Company A";
        public const string Brooklyn14th = "2nd Delaware Company A";

        public const string Brooklyn14th = "8th Illinois Company A";
        public const string Brooklyn14th = "65th Illinois Company B";
        public const string Brooklyn14th = "2nd Delaware Company A";
        public const string Brooklyn14th = "2nd Delaware Company A";*/

        /*public const string Brooklyn14th = "14th Brooklyn";
        public const string Delaware1st = "1st Delaware";
        public const string Illinois65th = "65th Illinois";
        public const string Indiana14th = "14th Indiana";
        public const string Indiana19th = "19th Indiana";
        public const string Maine20th = "20th Maine";
        public const string Maine7th = "7th Maine";
        public const string Maryland1st = "1st Maryland";
        public const string Maryland3rd = "3rd Maryland";
        public const string Maryland2nd = "2nd Maryland";
        public const string Massachusetts15th = "15th Massachusetts";
        public const string Massachusetts28th = "28th Massachusetts";
        public const string Michigan17th = "17th Michigan";
        public const string Michigan7th = "7th Michigan";
        public const string Minnesota1st = "1st Minnesota";
        public const string NewYork126th = "126th New York";
        public const string NewYork20th = "20th New York";
        public const string NewYork23rd = "23rd New York";
        public const string NewYork39th = "39th New York";
        public const string NewYork51st = "51st New York";
        public const string NewYork52nd = "52nd New York";
        public const string NewYork5th = "5th New York";
        public const string NewYork69th = "69th New York";
        public const string NewYork89th = "89th New York";
        public const string NewYork9th = "9th New York";
        public const string NewYorkMilitia12th = "12th New York Militia";
        public const string Ohio12th = "12th Ohio";
        public const string Ohio23rd = "23rd Ohio";
        public const string Ohio30th = "30th Ohio";
        public const string Ohio32nd = "32nd Ohio";
        public const string Ohio36th = "36th Ohio";
        public const string Ohio87th = "87th Ohio";
        public const string Ohio8th = "8th Ohio";
        public const string Pennsylvania114th = "114th Pennsylvania";
        public const string Pennsylvania28th = "28th Pennsylvania";
        public const string Pennsylvania32nd = "32nd Pennsylvania";
        public const string Pennsylvania42nd = "42nd Pennsylvania";
        public const string Pennsylvania4th = "4th Pennsylvania";
        public const string Pennsylvania51st = "51st Pennsylvania";
        public const string Pennsylvania6th = "6th Pennsylvania";
        public const string Pennsylvania72nd = "72nd Pennsylvania";
        public const string USSharpshooters1st = "1st US Sharpshooters";
        public const string USSharpshooters2nd = "2nd US Sharpshooters";
        public const string UnitedStates10th = "10th United States";
        public const string UnitedStates2nd = "2nd United States";
        public const string Vermont9th = "9th Vermont";
        public const string Wisconsin2nd = "2nd Wisconsin";
        public const string Wisconsin6th = "6th Wisconsin";*/
    }

    public static class Weapons
    {
        public const string SpringfieldM18642 = "Springfield M1842";
        public const string SpringfieldM18655 = "Springfield M1855";
        public const string SpringfieldM18661 = "Springfield M1861";
        public const string PatternEnfieldM1853 = "Pattern Enfield M1853";
        public const string LorenzM1854 = "Lorenz M1854";
        public const string MississippiM1841 = "Mississippi M1841";
        public const string SharpsRifleM1859 = "Sharps Rifle M1859";
        public const string WhitworthRifle = "Whitworth Rifle";
    }
}
