﻿using System.Collections.Generic;

namespace WarOfRightsWeb.Constants
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

        public const string HarpersFerryBolivarHeightsCampUSA = "Harpers Ferry Bolivar Heights Camp USA";

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

                case HarpersFerryBolivarHeightsCampUSA:
                    return "BolivarHeightsCampUSA";

                default: 
                    return mapName;
            }
        }

        public static Dictionary<string, string> DateTimes = new Dictionary<string, string>()
        {
            { Normalize(EastWoodsSkirmish), "September 16th - 20:00" },
            { Normalize(HookersPush), "September 17th - 06:00" },
            { Normalize(HagerstownTurnpike), "September 17th - 06:30" },
            { Normalize(MillersCornfield), "September 17th - 07:00" },
            { Normalize(EastWoods), "September 17th - 07:20" },
            { Normalize(NicodemusHill), "September 17th - 08:45" },
            { Normalize(BloodyLane), "September 17th - 09:00" },
            { Normalize(PryFord), "September 17th - 09:30" },
            { Normalize(PryGristMill), "September 17th - 10:00" },
            { Normalize(PryHouse), "September 17th - 10:00" },
            { Normalize(WestWoods), "September 17th - 10:00" },
            { Normalize(DunkerChurch), "September 17th - 10:30" },
            { Normalize(BurnsideBridge), "September 17th - 11:30" },
            { Normalize(CookesCountercharge), "September 17th - 12:00" },
            { Normalize(OttoSherrickFarm), "September 17th - 12:30" },
            { Normalize(RouletteLane), "September 17th - 12:45" },
            { Normalize(PiperFarm), "September 17th - 16:30" },
            { Normalize(HillsCounterattack), "September 17th - 17:00" },

            { Normalize(MarylandHeights), "September 13th - 09:30" },
            { Normalize(RiverCrossing), "September 15th - 09:30" },
            { Normalize(Downtown), "September 15th - 10:00" },
            { Normalize(SchoolHouseRidge), "September 15th - 06:30" },
            { Normalize(HighStreet), "September 15th - 11:00" },
            { Normalize(BolivarHeightsCamp), "September 15th - 09:00" },
            { Normalize(ShenandoahStreet), "September 15th - 12:00" },
            { Normalize(HarpersGraveyard), "September 15th - 14:30" },
            { Normalize(BolivarHeightsRedoubt), "September 15th - 10:00" },
            { Normalize(WashingtonStreet), "September 15th - 15:30" },

            { Normalize(GarlandsStand), "September 14th - 10:00 close to Fox's Gap" },
            { Normalize(CoxsPush), "September 14th - 11:00 Fox's Gap" },
            { Normalize(HatchsAttack), "September 14th - 18:30 close to Turner's Gap" },
            { Normalize(AndersonsCounterattack), "September 14th - 18:00 Fox's Gap" },
            { Normalize(RenosFall), "September 14th - 18:00 close to Fox's Gap" },
            { Normalize(ColquittsDefence), "September 14th - 19:00 Turner's Gap" },

            { Normalize(DrillCampUSA), "September, 1862" },
            { Normalize(DrillCampCSA), "September, 1862" },

            { Normalize(HarpersFerryBolivarHeightsCampUSA), "September, 1862" },

            { Normalize(PicketPatrol), "September, 1862" },
        };


        public static Dictionary<string, string> Descriptions = new Dictionary<string, string>()
        {
            { Normalize(EastWoodsSkirmish), "During the late afternoon of September 16th, General Hooker takes his Corps across Antietam creek at the upper bridge in order to locate the rebel flank. In the waning light, the 42nd PA and 3rd PA reserves are sent out in a skirmish formation to probe the East Woods for rebels." },
            { Normalize(HookersPush), "In the early fog of dawn, Union General Joseph Hooker pushes southwards with his I Corps, starting from the edge of North Woods, past the R. Miller Farm and through the Miller Cornfield only to be engaged south of it by defending Confederate General Ewell's Division at about 7 AM." },
            { Normalize(HagerstownTurnpike), "Upon leaving Miller’s Cornfield, the Union attacks the Confederates who are defending the Hagerstown Turnpike, a road running next to the cornfield. Its fenced in sides and the road itself functions as a clear line between Jackson’s forces in the West Woods and Hooker’s south of the cornfield." },
            { Normalize(MillersCornfield), "An hour after the early morning actions of General Hooker and his Corps near the Miller farmstead, the damaged cornfield is subjected to a new infusion of blood, this time from the men of Hood's division. A withering fire from several sides mean that terrible casualties are wrought." },
            { Normalize(EastWoods), "As Confederate General Hood attempts to push the advancing Union General Hooker’s I Corps back into the Cornfield, some of his forces also push against the Union holding in the East Woods directly adjacent to Miller’s Cornfield." },
            { Normalize(NicodemusHill), "Confederates are defending Jackson's artillery positioned on Nicodemus Hill from the Union attacking from the direction of Miller farm. The commanding viewpoint offered by Nicodemus Hill offers Washington’s, Chew’s, and Pelham’s batteries devastating fire down the Union lines." },
            { Normalize(BloodyLane), "A sunken road often used by farmers becomes a natural fort against a Union onslaught of Rebel lines as Union General French pushes forward with his 3rd Division and becomes engaged with elements of Confederate General D.H. Hill’s Division entrenched in the road." },
            { Normalize(PryFord), "In this alternate scenario, grey-clad soldiers hold an important point near a ford on the Antietam Creek, and are attacked by dismounted Union cavalry under Pleasanton used by Union Commander General McClellan as skirmishers probing for the enemy throughout the day of fighting." },
            { Normalize(PryGristMill), "In this alternate scenario, Hooker's forces must contend with Confederate skirmishers holding an important crossing point of the Little Antietam creek. Pry’s Grist Mill is situated near the confluence of Little Antietam and Antietam Creek and is a major supplier of flour in the region." },
            { Normalize(PryHouse), "In this alternative scenario pockets of Confederate forces have managed to sneak by the Union line and are attacking Pry House, headquarter of commanding Union General George B. McClellan." },
            { Normalize(WestWoods), "General Edwin Sumner's Union Second Corps advances into the West Woods where they are met by Confederate Wing Commander Jackson’s men. Union General John Sedgwick's division is performing a series of reckless charges into the Confederates at very high costs to break the Confederate line." },
            { Normalize(DunkerChurch), "Union General Greene pushes his Division towards the rebel-held whitewashed church on the outskirts of the West Woods from the direction of the burning Mumma Farm. The church is a focal point of several Union attacks as it sits elevated on a small plateau." },
            { Normalize(BurnsideBridge), "After several hours of preparation, Union General Burnside is ready to advance the IX Corps against Confederate General Toombs’ Brigade of skirmishers whom, while being vastly outnumbered, holds the heights overlooking the Lower Bridge crossing Antietam Creek." },
            { Normalize(CookesCountercharge), "After several hours with no reinforcements, Union General Greene is forced to withdraw from his salient in the West Woods. Confederate Colonel Cooke orders a countercharge towards Mumma Farm in response to the fleeing Federals." },
            { Normalize(OttoSherrickFarm), "The idyllic farms of the Otto and Sherrick families becomes a heavily contested area as the two forces clash. The farms are situated in close proximity to the Lower Bridge and moving towards the town of Sharpsburg dictates passing their grounds." },
            { Normalize(RouletteLane), "The 3rd Arkansas and 27th North Carolina under Colonel Cooke find themselves on the flank of the Federals now in possession of the Sunken Road. The 1st Delaware and 14th Indiana are tasked with holding the rebels back at Roulette Lane." },
            { Normalize(PiperFarm), "The 7th Maine is ordered by Colonel Irwin to push past the bodies at the Bloody Lane, the Piper Cornfield, the apple orchard and attack the Piper farm buildings themselves, which act as headquarters for Confederate Wing Commander General Longstreet. 4 Confederate brigades await them." },
            { Normalize(HillsCounterattack), "Confederate General Hill arrives from Harper's Ferry late in the day with his Light Division partially wearing captured Federal uniforms. The Division smashes into the flank of the advancing Burnside's Corps which has been delayed heavily earlier in the day at the Lower Bridge." },

            { Normalize(MarylandHeights), "Early on the morning of the 13th, Kershaw’s and Barksdale’s Brigades of Confederates attack the Maryland Heights while the 32nd Ohio and 126th New York try to guard the approach to Harper’s Ferry." },
            { Normalize(RiverCrossing), "In this fictitious scenario, Confederates under General McLaws desperately attempt to cross the Potomac River to assault the town of Harper’s Ferry from both sides." },
            { Normalize(Downtown), "In this fictitious scenario, the Confederates have breached Camp Hill, and are now assaulting the downtown area of Harper’s Ferry where the last defenders doggedly try to hold out against them." },
            { Normalize(SchoolHouseRidge), "During the siege of Harper's Ferry, General Stonewall Jackson had lined a large portion of his force along Schoolhouse Ridge, which sat opposite a valley overlooked by the Bolivar Heights, which the Union had hastily fortified. In this fictitious scenario, the Confederates attempt to make a frontal charge against the strong defenses of the Union!" },
            { Normalize(HighStreet), "In this fictitious scenario, the Union garrison under General Miles attempt to defend the north side of Camp Hill against Confederate assaults after their taking of the Bolivar Heights." },
            { Normalize(BolivarHeightsCamp), "The Bolivar Heights was an important and strategic position for Union forces during their garrison of the town, the ridge also serving as a partial campsite to the 15,000 stationed in the beautiful valley. In this fictitious scenario, Confederate forces have breached the hastily-made defences, while Union forces desperately try to muster a counterattack." },
            { Normalize(ShenandoahStreet), "In this semi-fictitious scenario, AP Hill has broken past the southern defenses of Bolivar Heights, and is now threatening to take the downtown region of Harper’s Ferry as blue-clad defenders scramble to stop the Confederates." },
            { Normalize(HarpersGraveyard), "In this fictitious scenario, following the taking of Bolivar Heights, the Confederates are launching an assault on the last holdouts of the garrison via the historic Harper’s Graveyard." },
            { Normalize(BolivarHeightsRedoubt), "The Bolivar Heights was an important and strategic position for Union forces during their garrison of the town, the ridge also serving as a partial campsite to the 15,000 stationed in the beautiful valley. In this fictitious scenario, Confederate forces are attacking the artillery redoubt of the entrenched Union forces." },
            { Normalize(WashingtonStreet), "In this fictitious scenario, the Union garrison attempt to defend against Confederates now streaming down Camp Hill by way of the main thoroughfare to Harper’s Ferry from Bolivar – Washington Street." },

            { Normalize(GarlandsStand), "CSA Brig. General Samuel Garland having been ordered by Maj. Gen. D.H. Hill to defend Fox's Gap and its road - directly exposing the wagon trains of the Confederate army should it fall, is now deploying his brigade next to the Wise Farm. To his immediate front Union Colonel Scammon's brigade consisting of the 30th and 12th Ohio is advancing and engaging with the 13th and 20th North Carolina while the 23rd Ohio is putting pressure on his far too drawn-out line's right flank." },
            { Normalize(CoxsPush), "As the 30th and 12th Ohio attack the left flank of Garland's Brigade, Union Division Commander Jacob Cox pushes forward the 36th and 23rd Ohio to engage the Confederate 5th North Carolina as well as the 23rd North Carolina, having just reinforced the stretched out and besieged Confederate line. Between the two lines is Fox's Gap, a windswept, valley-like gap covered in stonewalls, fencing in the numerous fields covering the area." },
            { Normalize(HatchsAttack), "In an effort to secure the southern part of South Mountain itself and thus open up the flank of Confederate Major General D.H. Hill situated at the strong defensive positions at Mountain House and on the Dahlgren Road at Turner's Gap, Union Brig. Gen. John Hatch's 3500-man division pushes onwards and upwards through some of the most difficult and rocky terrain of the battlefield. On top of the crest CSA General Garnett's 400-man division is rushing forwards to safeguard the flank of the mountain gap." },
            { Normalize(AndersonsCounterattack), "With but a few hours of daylight left the 9th and 89th New York along with Clark's Battery take up a defensive position on the northern side of Fox's Gap, defended by Garland's, now broken, Brigade earlier in the day. CSA Gen. G.B. Anderson, arriving with badly needed reinforcements to the remnants of the Confederate force, targets Clark's Battery and the two New York regiments for his counterattack." },
            { Normalize(RenosFall), "After the Confederate collapse at Fox's Gap earlier in the day due to the attacks by Union Maj. Gen. Reno's IX Corps, CSA Brig. Gen. Hood now orders his division south to relieve the battered Confederate lines in an effort to regain a foothold at the gap. To deny the Confederates the chance of doing so, the 51st New York and Pennsylvania are sent forward with the Corps commander in close proximity in order to inspire his troops and inspect the lines." },
            { Normalize(ColquittsDefence), "Positioned behind a stonewall at the base of Turner's Gap and on the fenced-in Dahlgren Road running above the gap, overlooking the National Road headed into Turner's Gap, CSA Colonel Colquitt's brigade readies itself for the attack it knows is coming after having witnessed Union Gen. Hatch's attack on Garnett to the left of Colquitt's brigade an hour earlier. On the National Road in front of them, Union Gen. Gibbon's brigade begins its slow but steady push with an iron-like determination." },

            { Normalize(DrillCampUSA), "Nestled in the lush and gently rolling hills of central Maryland, a regiment-sized camp has been set up among various farmsteads in 1862." },
            { Normalize(DrillCampCSA), "Having crossed the Potomac earlier in the week, Confederate forces have carved out space among the ample farmland of central Maryland for a regiment-sized encampment during the Maryland Campaign of 1862." },

            { Normalize(HarpersFerryBolivarHeightsCampUSA), "Situated in the beautiful Shenandoah Valley, Bolivar Heights is one of three the commands an overlook of the town of Harper's Ferry below. Camp Hill and the Bolivar Heights were taken over by those garrisoning this strategically important confluence of rail and water." },

            { Normalize(PicketPatrol), "Eliminate enemy picket force.<br>One life per round.<br>Random team spawn points.<br>Strict formation rules." },
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
