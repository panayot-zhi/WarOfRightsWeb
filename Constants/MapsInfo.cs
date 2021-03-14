﻿using System.Collections.Generic;
using WarOfRightsWeb.Constants;

namespace WarOfRightsTools.Generated
{
    // NOTE: Generated by WarOfRightsTools from all Areas_Skirmish.json files

    public static class MapsInfo
    {
        public class SkirmishInfo
        {
            public string DefendingTeam { get; set; }

            public string TimeOfDay { get; set; }

            public string RoundTime { get; set; }

            public string WaveTime { get; set; }

            public string CaptureSpeed { get; set; }

            public string NeutralizeSpeed { get; set; }

            public string TicketsUSA { get; set; }

            public string TicketsCSA { get; set; }

            public string FinalPushTime { get; set; }

            public string[] RegimentsUSA { get; set; }

            public string[] RegimentsCSA { get; set; }
        }

        public static Dictionary<string, SkirmishInfo> Parameters = new()
        {
            {
                Maps.EastWoodsSkirmish,
                new SkirmishInfo()
                {
                    DefendingTeam = "CSA",
                    TimeOfDay = "17",
                    RoundTime = "2700",
                    WaveTime = "30",
                    CaptureSpeed = "0.007",
                    NeutralizeSpeed = "0.007",
                    TicketsUSA = "137",
                    TicketsCSA = "115",
                    FinalPushTime = "204",
                    RegimentsUSA = new[] { Regiments.Pennsylvania42nd, Regiments.Pennsylvania32nd, Regiments.BatteryCooper },
                    RegimentsCSA = new[] { Regiments.Georgia18th, Regiments.HamptonLegion },
                }
            },
            {
                Maps.HookersPush,
                new SkirmishInfo()
                {
                    DefendingTeam = "CSA",
                    TimeOfDay = "6.4",
                    RoundTime = "2700",
                    WaveTime = "30",
                    CaptureSpeed = "0.007",
                    NeutralizeSpeed = "0.007",
                    TicketsUSA = "137",
                    TicketsCSA = "115",
                    FinalPushTime = "390",
                    RegimentsUSA = new[] { Regiments.Wisconsin2nd, Regiments.USSharpshooters1st, Regiments.BatteryMatthews, Regiments.BatteryThompson },
                    RegimentsCSA = new[] { Regiments.Georgia13th, Regiments.Louisiana6th, Regiments.BatteryBrockenbrough, Regiments.BatteryJordan, Regiments.BatteryPoague },
                }
            },
            {
                Maps.HagerstownTurnpike,
                new SkirmishInfo()
                {
                    DefendingTeam = "CSA",
                    TimeOfDay = "6.5",
                    RoundTime = "2700",
                    WaveTime = "30",
                    CaptureSpeed = "0.007",
                    NeutralizeSpeed = "0.007",
                    TicketsUSA = "124",
                    TicketsCSA = "100",
                    FinalPushTime = "130",
                    RegimentsUSA = new[] { Regiments.Brooklyn14th, Regiments.Wisconsin6th, Regiments.BatteryCampbell },
                    RegimentsCSA = new[] { Regiments.Louisiana9th, Regiments.LouisianaZouaves1st, Regiments.BatteryBrockenbrough, Regiments.BatteryPoague },
                }
            },
            {
                Maps.MillersCornfield,
                new SkirmishInfo()
                {
                    DefendingTeam = "USA",
                    TimeOfDay = "6.8",
                    RoundTime = "2700",
                    WaveTime = "30",
                    CaptureSpeed = "0.007",
                    NeutralizeSpeed = "0.007",
                    TicketsUSA = "110",
                    TicketsCSA = "124",
                    FinalPushTime = "142",
                    RegimentsUSA = new[] { Regiments.Brooklyn14th, Regiments.Wisconsin6th, Regiments.BatteryMatthews, Regiments.BatteryRansom },
                    RegimentsCSA = new[] { Regiments.HamptonLegion, Regiments.Texas1st, Regiments.BatteryBlackshear },
                }
            },
            {
                Maps.EastWoods,
                new SkirmishInfo()
                {
                    DefendingTeam = "USA",
                    TimeOfDay = "7.2",
                    RoundTime = "2700",
                    WaveTime = "30",
                    CaptureSpeed = "0.007",
                    NeutralizeSpeed = "0.007",
                    TicketsUSA = "100",
                    TicketsCSA = "124",
                    FinalPushTime = "218",
                    RegimentsUSA = new[] { Regiments.Pennsylvania114th, Regiments.Pennsylvania42nd },
                    RegimentsCSA = new[] { Regiments.Texas5th, Regiments.Alabama4th },
                }
            },
            {
                Maps.NicodemusHill,
                new SkirmishInfo()
                {
                    DefendingTeam = "CSA",
                    TimeOfDay = "8.75",
                    RoundTime = "2700",
                    WaveTime = "30",
                    CaptureSpeed = "0.007",
                    NeutralizeSpeed = "0.007",
                    TicketsUSA = "147",
                    TicketsCSA = "95",
                    FinalPushTime = "146",
                    RegimentsUSA = new[] { Regiments.Minnesota1st, Regiments.Massachusetts15th, Regiments.BatteryCampbell, Regiments.BatteryReynolds },
                    RegimentsCSA = new[] { Regiments.Virginia13th, Regiments.VirginiaCavalry1st, Regiments.BatteryWooding, Regiments.BatteryBalthis, Regiments.BatteryPelham, Regiments.BatteryCarpenter },
                }
            },
            {
                Maps.BloodyLane,
                new SkirmishInfo()
                {
                    DefendingTeam = "CSA",
                    TimeOfDay = "9",
                    RoundTime = "2700",
                    WaveTime = "30",
                    CaptureSpeed = "0.007",
                    NeutralizeSpeed = "0.007",
                    TicketsUSA = "137",
                    TicketsCSA = "90",
                    FinalPushTime = "196",
                    RegimentsUSA = new[] { Regiments.Ohio8th, Regiments.NewYork69th },
                    RegimentsCSA = new[] { Regiments.Alabama6th, Regiments.NorthCarolina14th, Regiments.BatteryMiller },
                }
            },
            {
                Maps.PryFord,
                new SkirmishInfo()
                {
                    DefendingTeam = "CSA",
                    TimeOfDay = "9.5",
                    RoundTime = "2700",
                    WaveTime = "30",
                    CaptureSpeed = "0.007",
                    NeutralizeSpeed = "0.007",
                    TicketsUSA = "124",
                    TicketsCSA = "105",
                    FinalPushTime = "208",
                    RegimentsUSA = new[] { Regiments.Pennsylvania4th, Regiments.UnitedStates2nd, Regiments.BatteryMcGilvery },
                    RegimentsCSA = new[] { Regiments.HolcombeLegion, Regiments.SouthCarolina17th, Regiments.BatteryDAquin },
                }
            },
            {
                Maps.PryGristMill,
                new SkirmishInfo()
                {
                    DefendingTeam = "CSA",
                    TimeOfDay = "10",
                    RoundTime = "2700",
                    WaveTime = "30",
                    CaptureSpeed = "0.007",
                    NeutralizeSpeed = "0.007",
                    TicketsUSA = "124",
                    TicketsCSA = "105",
                    FinalPushTime = "164",
                    RegimentsUSA = new[] { Regiments.Pennsylvania6th, Regiments.UnitedStates10th },
                    RegimentsCSA = new[] { Regiments.HolcombeLegion, Regiments.Georgia1st },
                }
            },
            {
                Maps.PryHouse,
                new SkirmishInfo()
                {
                    DefendingTeam = "USA",
                    TimeOfDay = "10",
                    RoundTime = "2700",
                    WaveTime = "30",
                    CaptureSpeed = "0.007",
                    NeutralizeSpeed = "0.007",
                    TicketsUSA = "115",
                    TicketsCSA = "134",
                    FinalPushTime = "144",
                    RegimentsUSA = new[] { Regiments.NewYork5th, Regiments.Maine20th, Regiments.BatteryWeaver },
                    RegimentsCSA = new[] { Regiments.Alabama8th, Regiments.Florida8th, Regiments.BatterySquires },
                }
            },
            {
                Maps.WestWoods,
                new SkirmishInfo()
                {
                    DefendingTeam = "CSA",
                    TimeOfDay = "9.5",
                    RoundTime = "2700",
                    WaveTime = "30",
                    CaptureSpeed = "0.007",
                    NeutralizeSpeed = "0.007",
                    TicketsUSA = "137",
                    TicketsCSA = "110",
                    FinalPushTime = "152",
                    RegimentsUSA = new[] { Regiments.Michigan7th, Regiments.Pennsylvania72nd },
                    RegimentsCSA = new[] { Regiments.NCSharpshooters1st, Regiments.SouthCarolina3rd },
                }
            },
            {
                Maps.DunkerChurch,
                new SkirmishInfo()
                {
                    DefendingTeam = "CSA",
                    TimeOfDay = "10.5",
                    RoundTime = "2700",
                    WaveTime = "30",
                    CaptureSpeed = "0.007",
                    NeutralizeSpeed = "0.007",
                    TicketsUSA = "137",
                    TicketsCSA = "90",
                    FinalPushTime = "244",
                    RegimentsUSA = new[] { Regiments.Pennsylvania72nd, Regiments.Pennsylvania28th, Regiments.BatteryEdgell, Regiments.BatteryTompkins },
                    RegimentsCSA = new[] { Regiments.SouthCarolina2nd, Regiments.Virginia30th, Regiments.BatteryCarlton },
                }
            },
            {
                Maps.BurnsideBridge,
                new SkirmishInfo()
                {
                    DefendingTeam = "CSA",
                    TimeOfDay = "11.5",
                    RoundTime = "2700",
                    WaveTime = "30",
                    CaptureSpeed = "0.007",
                    NeutralizeSpeed = "0.007",
                    TicketsUSA = "137",
                    TicketsCSA = "88",
                    FinalPushTime = "264",
                    RegimentsUSA = new[] { Regiments.NewYork51st, Regiments.Maryland2nd, Regiments.BatteryClark },
                    RegimentsCSA = new[] { Regiments.Georgia2nd, Regiments.Georgia20th, Regiments.BatteryRichardson, Regiments.BatteryBrown },
                }
            },
            {
                Maps.CookesCountercharge,
                new SkirmishInfo()
                {
                    DefendingTeam = "USA",
                    TimeOfDay = "12",
                    RoundTime = "2700",
                    WaveTime = "30",
                    CaptureSpeed = "0.007",
                    NeutralizeSpeed = "0.007",
                    TicketsUSA = "100",
                    TicketsCSA = "137",
                    FinalPushTime = "188",
                    RegimentsUSA = new[] { Regiments.Pennsylvania28th, Regiments.NewYork52nd, Regiments.BatteryOwen },
                    RegimentsCSA = new[] { Regiments.Arkansas3rd, Regiments.NorthCarolina27th },
                }
            },
            {
                Maps.OttoSherrickFarm,
                new SkirmishInfo()
                {
                    DefendingTeam = "CSA",
                    TimeOfDay = "12.5",
                    RoundTime = "2700",
                    WaveTime = "30",
                    CaptureSpeed = "0.007",
                    NeutralizeSpeed = "0.007",
                    TicketsUSA = "137",
                    TicketsCSA = "90",
                    FinalPushTime = "136",
                    RegimentsUSA = new[] { Regiments.Massachusetts28th, Regiments.Michigan17th, Regiments.BatteryCook },
                    RegimentsCSA = new[] { Regiments.Georgia1st, Regiments.PalmettoSharpshooters, Regiments.BatteryMaurin },
                }
            },
            {
                Maps.RouletteLane,
                new SkirmishInfo()
                {
                    DefendingTeam = "USA",
                    TimeOfDay = "12.75",
                    RoundTime = "2700",
                    WaveTime = "30",
                    CaptureSpeed = "0.007",
                    NeutralizeSpeed = "0.007",
                    TicketsUSA = "95",
                    TicketsCSA = "137",
                    FinalPushTime = "156",
                    RegimentsUSA = new[] { Regiments.Delaware1st, Regiments.Indiana14th, Regiments.BatteryGraham },
                    RegimentsCSA = new[] { Regiments.Arkansas3rd, Regiments.NorthCarolina27th },
                }
            },
            {
                Maps.PiperFarm,
                new SkirmishInfo()
                {
                    DefendingTeam = "CSA",
                    TimeOfDay = "15.5",
                    RoundTime = "2700",
                    WaveTime = "30",
                    CaptureSpeed = "0.007",
                    NeutralizeSpeed = "0.007",
                    TicketsUSA = "124",
                    TicketsCSA = "90",
                    FinalPushTime = "132",
                    RegimentsUSA = new[] { Regiments.Maine7th, Regiments.NewYork20th, Regiments.BatteryOwen, Regiments.BatteryHexamer },
                    RegimentsCSA = new[] { Regiments.Alabama8th, Regiments.Florida8th, Regiments.BatteryBrooks, Regiments.BatteryBoyce },
                }
            },
            {
                Maps.HillsCounterattack,
                new SkirmishInfo()
                {
                    DefendingTeam = "USA",
                    TimeOfDay = "16",
                    RoundTime = "2700",
                    WaveTime = "30",
                    CaptureSpeed = "0.007",
                    NeutralizeSpeed = "0.007",
                    TicketsUSA = "115",
                    TicketsCSA = "124",
                    FinalPushTime = "178",
                    RegimentsUSA = new[] { Regiments.RhodeIsland4th, Regiments.NewYork9th },
                    RegimentsCSA = new[] { Regiments.SouthCarolina12th, Regiments.PalmettoSharpshooters, Regiments.BatteryBrown, Regiments.BatteryReily },
                }
            },
            {
                Maps.MarylandHeights,
                new SkirmishInfo()
                {
                    DefendingTeam = "USA",
                    TimeOfDay = "9.5",
                    RoundTime = "2700",
                    WaveTime = "30",
                    CaptureSpeed = "0.007",
                    NeutralizeSpeed = "0.007",
                    TicketsUSA = "190",
                    TicketsCSA = "190",
                    FinalPushTime = "174",
                    RegimentsUSA = new[] { Regiments.Ohio32nd, Regiments.NewYork126th },
                    RegimentsCSA = new[] { Regiments.Mississippi18th, Regiments.SouthCarolina3rd },
                }
            },
            {
                Maps.RiverCrossing,
                new SkirmishInfo()
                {
                    DefendingTeam = "USA",
                    TimeOfDay = "9.5",
                    RoundTime = "2700",
                    WaveTime = "30",
                    CaptureSpeed = "0.007",
                    NeutralizeSpeed = "0.007",
                    TicketsUSA = "120",
                    TicketsCSA = "199",
                    FinalPushTime = "262",
                    RegimentsUSA = new[] { Regiments.MarylandPHB1st, Regiments.NewYorkMilitia12th, Regiments.BatteryPotts },
                    RegimentsCSA = new[] { Regiments.Mississippi18th, Regiments.SouthCarolina3rd, Regiments.BatteryRead, Regiments.BatteryManly, Regiments.BatteryFrench, Regiments.BatteryCarlton },
                }
            },
            {
                Maps.Downtown,
                new SkirmishInfo()
                {
                    DefendingTeam = "USA",
                    TimeOfDay = "10",
                    RoundTime = "2700",
                    WaveTime = "30",
                    CaptureSpeed = "0.007",
                    NeutralizeSpeed = "0.007",
                    TicketsUSA = "100",
                    TicketsCSA = "124",
                    FinalPushTime = "152",
                    RegimentsUSA = new[] { Regiments.NewYork39th, Regiments.NewYorkMilitia12th },
                    RegimentsCSA = new[] { Regiments.SouthCarolina2nd, Regiments.Mississippi18th, Regiments.BatteryManly, Regiments.BatteryFrench },
                }
            },
            {
                Maps.SchoolHouseRidge,
                new SkirmishInfo()
                {
                    DefendingTeam = "USA",
                    TimeOfDay = "6.5",
                    RoundTime = "2700",
                    WaveTime = "30",
                    CaptureSpeed = "0.007",
                    NeutralizeSpeed = "0.007",
                    TicketsUSA = "100",
                    TicketsCSA = "124",
                    FinalPushTime = "188",
                    RegimentsUSA = new[] { Regiments.NewYork39th, Regiments.NewYork126th, Regiments.BatteryVonSehlen, Regiments.BatteryPhillips, Regiments.BatteryGraham },
                    RegimentsCSA = new[] { Regiments.Louisiana6th, Regiments.Virginia13th, Regiments.BatteryCourtney, Regiments.BatteryBrockenbrough },
                }
            },
            {
                Maps.HighStreet,
                new SkirmishInfo()
                {
                    DefendingTeam = "USA",
                    TimeOfDay = "11",
                    RoundTime = "2700",
                    WaveTime = "30",
                    CaptureSpeed = "0.007",
                    NeutralizeSpeed = "0.007",
                    TicketsUSA = "110",
                    TicketsCSA = "124",
                    FinalPushTime = "142",
                    RegimentsUSA = new[] { Regiments.Vermont9th, Regiments.Illinois65th },
                    RegimentsCSA = new[] { Regiments.Tennessee14th, Regiments.Mississippi18th, Regiments.BatteryManly, Regiments.BatteryFrench },
                }
            },
            {
                Maps.BolivarHeightsCamp,
                new SkirmishInfo()
                {
                    DefendingTeam = "USA",
                    TimeOfDay = "9",
                    RoundTime = "2700",
                    WaveTime = "30",
                    CaptureSpeed = "0.007",
                    NeutralizeSpeed = "0.007",
                    TicketsUSA = "100",
                    TicketsCSA = "124",
                    FinalPushTime = "218",
                    RegimentsUSA = new[] { Regiments.NewYork39th, Regiments.Illinois65th, Regiments.BatteryVonSehlen, Regiments.BatteryGraham, Regiments.BatteryPhillips },
                    RegimentsCSA = new[] { Regiments.LouisianaZouaves1st, Regiments.Louisiana9th, Regiments.BatteryBrockenbrough },
                }
            },
            {
                Maps.ShenandoahStreet,
                new SkirmishInfo()
                {
                    DefendingTeam = "USA",
                    TimeOfDay = "13.5",
                    RoundTime = "2700",
                    WaveTime = "30",
                    CaptureSpeed = "0.007",
                    NeutralizeSpeed = "0.007",
                    TicketsUSA = "110",
                    TicketsCSA = "124",
                    FinalPushTime = "104",
                    RegimentsUSA = new[] { Regiments.Ohio87th, Regiments.Illinois65th },
                    RegimentsCSA = new[] { Regiments.AlabamaBtl5th, Regiments.NorthCarolina18th, Regiments.BatteryManly, Regiments.BatteryFrench },
                }
            },
            {
                Maps.HarpersGraveyard,
                new SkirmishInfo()
                {
                    DefendingTeam = "USA",
                    TimeOfDay = "14.5",
                    RoundTime = "2700",
                    WaveTime = "30",
                    CaptureSpeed = "0.007",
                    NeutralizeSpeed = "0.007",
                    TicketsUSA = "115",
                    TicketsCSA = "124",
                    FinalPushTime = "134",
                    RegimentsUSA = new[] { Regiments.MarylandPHB3rd, Regiments.Vermont9th, Regiments.BatteryGraham },
                    RegimentsCSA = new[] { Regiments.AlabamaBtl5th, Regiments.NorthCarolina18th, Regiments.BatteryManly, Regiments.BatteryFrench },
                }
            },
            {
                Maps.BolivarHeightsRedoubt,
                new SkirmishInfo()
                {
                    DefendingTeam = "USA",
                    TimeOfDay = "10",
                    RoundTime = "2700",
                    WaveTime = "30",
                    CaptureSpeed = "0.007",
                    NeutralizeSpeed = "0.007",
                    TicketsUSA = "100",
                    TicketsCSA = "134",
                    FinalPushTime = "224",
                    RegimentsUSA = new[] { Regiments.NewYork39th, Regiments.Illinois65th, Regiments.BatteryRigby, Regiments.BatteryPotts },
                    RegimentsCSA = new[] { Regiments.LouisianaZouaves1st, Regiments.Louisiana9th, Regiments.BatteryBraxton },
                }
            },
            {
                Maps.WashingtonStreet,
                new SkirmishInfo()
                {
                    DefendingTeam = "USA",
                    TimeOfDay = "15.5",
                    RoundTime = "2700",
                    WaveTime = "30",
                    CaptureSpeed = "0.007",
                    NeutralizeSpeed = "0.007",
                    TicketsUSA = "115",
                    TicketsCSA = "124",
                    FinalPushTime = "136",
                    RegimentsUSA = new[] { Regiments.MarylandPHB3rd, Regiments.NewYork39th },
                    RegimentsCSA = new[] { Regiments.VirginiaBtl22nd, Regiments.NorthCarolina18th, Regiments.BatteryManly, Regiments.BatteryFrench },
                }
            },
            {
                Maps.GarlandsStand,
                new SkirmishInfo()
                {
                    DefendingTeam = "CSA",
                    TimeOfDay = "10",
                    RoundTime = "2700",
                    WaveTime = "30",
                    CaptureSpeed = "0.007",
                    NeutralizeSpeed = "0.007",
                    TicketsUSA = "137",
                    TicketsCSA = "115",
                    FinalPushTime = "256",
                    RegimentsUSA = new[] { Regiments.Ohio30th, Regiments.Ohio12th, Regiments.BatteryCrome },
                    RegimentsCSA = new[] { Regiments.NorthCarolina13th, Regiments.NorthCarolina20th, Regiments.BatteryBondurant },
                }
            },
            {
                Maps.CoxsPush,
                new SkirmishInfo()
                {
                    DefendingTeam = "CSA",
                    TimeOfDay = "10",
                    RoundTime = "2700",
                    WaveTime = "30",
                    CaptureSpeed = "0.007",
                    NeutralizeSpeed = "0.007",
                    TicketsUSA = "127",
                    TicketsCSA = "115",
                    FinalPushTime = "200",
                    RegimentsUSA = new[] { Regiments.Ohio23rd, Regiments.Ohio36th },
                    RegimentsCSA = new[] { Regiments.NorthCarolina5th, Regiments.NorthCarolina23rd, Regiments.BatteryPelham },
                }
            },
            {
                Maps.HatchsAttack,
                new SkirmishInfo()
                {
                    DefendingTeam = "CSA",
                    TimeOfDay = "16",
                    RoundTime = "2700",
                    WaveTime = "30",
                    CaptureSpeed = "0.007",
                    NeutralizeSpeed = "0.007",
                    TicketsUSA = "127",
                    TicketsCSA = "115",
                    FinalPushTime = "218",
                    RegimentsUSA = new[] { Regiments.USSharpshooters2nd, Regiments.NewYork23rd },
                    RegimentsCSA = new[] { Regiments.Virginia18th, Regiments.Virginia56th },
                }
            },
            {
                Maps.AndersonsCounterattack,
                new SkirmishInfo()
                {
                    DefendingTeam = "USA",
                    TimeOfDay = "16",
                    RoundTime = "2700",
                    WaveTime = "30",
                    CaptureSpeed = "0.007",
                    NeutralizeSpeed = "0.007",
                    TicketsUSA = "115",
                    TicketsCSA = "127",
                    FinalPushTime = "200",
                    RegimentsUSA = new[] { Regiments.NewYork9th, Regiments.NewYork89th, Regiments.BatteryClark },
                    RegimentsCSA = new[] { Regiments.NorthCarolina2nd, Regiments.NorthCarolina4th },
                }
            },
            {
                Maps.RenosFall,
                new SkirmishInfo()
                {
                    DefendingTeam = "USA",
                    TimeOfDay = "16",
                    RoundTime = "2700",
                    WaveTime = "30",
                    CaptureSpeed = "0.007",
                    NeutralizeSpeed = "0.007",
                    TicketsUSA = "115",
                    TicketsCSA = "127",
                    FinalPushTime = "221",
                    RegimentsUSA = new[] { Regiments.NewYork51st, Regiments.Pennsylvania51st, Regiments.BatteryGlassie },
                    RegimentsCSA = new[] { Regiments.Georgia18th, Regiments.Mississippi2nd },
                }
            },
            {
                Maps.ColquittsDefence,
                new SkirmishInfo()
                {
                    DefendingTeam = "CSA",
                    TimeOfDay = "16.5",
                    RoundTime = "2700",
                    WaveTime = "30",
                    CaptureSpeed = "0.007",
                    NeutralizeSpeed = "0.007",
                    TicketsUSA = "145",
                    TicketsCSA = "115",
                    FinalPushTime = "242",
                    RegimentsUSA = new[] { Regiments.Wisconsin2nd, Regiments.Indiana19th, Regiments.BatteryStewart },
                    RegimentsCSA = new[] { Regiments.Alabama13th, Regiments.Georgia6th, Regiments.BatteryLane },
                }
            },
        };
    }
}
