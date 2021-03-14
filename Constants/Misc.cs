using System;

namespace WarOfRightsWeb.Constants
{
    public static class Misc
    {
        private static readonly Random Random = new();

        public static string[] Tips = new[]
        {
            "Listen to your officer!",
            "Left Shift makes you Charge. C toggles Double Quick, Quicktime.",
            "Press T to see the names of other players as well as other useful information.",
            "The flag can only be spawned at, if the flag bearer is either skirmishing or in formation.",
            "If an officer or flagbearer leave their men, they will be considered a deserter!",
            "The Drill Camp offers a safe place for regiments to hone their skills.",
            "Consider joining a company on the Company Tool on the War of Rights website at www.warofrights.com",
            "When wielding the Springfield M1842, switch to Buck and Ball by pressing 2.",
            "Toggle Melee Mode by pressing V",
            "Salute your officer by pressing F5",
            "Bring up the WoR default controls screen by pressing F1.",
            "Display a map and background information of the active skirmish area by pressing F2.",
            "You can mute the 3D voice and text chat of annoying players by pressing on the small speaker in the TAB menu.",
            "There are 4 morale states: Battle Ready, Engaged, Taking Losses and Breaking.",
            "The defending team wins the battle if they are still in possession of the point of contention when the timer runs out.",
            //"Adjust your range sights by pressing Z while aiming.",   // No, don't do that
            "Stray too far away from the battlefield and you will be considered a deserter.",
            "Officers, Flag Bearers and NCO's are all limited classes.",
            "Dismounted cavalry units are often equipped with swords, carbines and pistols but highly limited.",
            "As an officer, you can draw a line for your men to see by pressing Q once at the start point and once more to end the line.",
            "Being In Formation will help you shake off any suppression quicker and also improve your aim.",
            "Your stamina will be severely lowered if you are wounded.",
            "The smoke will be carried away by the direction of the wind. Use it to your advantage.",
            "A Skirmishing Flag Bearer will only bring up reinforcements at half the speed as that of an In Formation one.",
            "Officers can use their field glasses to get a clearer strategical view of the current situation.",
            "Right click to enter At The Ready. It is only possible to move in Quicktime while being At The Ready.",
            "A bayonet is deadlier than a rifle butt.",
            //"You will automatically speed up to catch the player straight in front of you when marching.", // What?! No, that ain't true!
            "Press Left Alt to enter freelook mode to get better situational awareness.",
            "Use the Mouse Wheel to adjust your focus when looking through the field glasses.",
            "Press X to toggle between Right Shoulder Shift and Shoulder Arms.",
            "Enter and exit the cinematic WoR Cam by pressing F9.",
            "Reloading while Kneeling is slower than when standing up.",
            "Open and close doors by pressing F.",
            "Press Left Control to Kneel. Kneeling will put you in the Skirmishing stance.",
            "Press B to attach and deattach your bayonet. Your aim sway will be increased with a bayonet attached.",
            "Remember to press R between each shot when using a revolver to cock the hammer and spin the cylinder.",
            "Take the time to learn the uniforms of the enemy on the different skirmish areas to avoid friendly fire.",
            "Enemy player names will not be shown when pressing T.",
            "Make use of the compass when pressing T.",
            "A rifled musket is more accurate than a smoothbore one.",
            "Sharpshooting US units often use the quick firing Sharps rifle but are highly limited in their numbers.",
            "Vault over fences by pressing the Spacebar.",
            "Hold N to speak using 3D Voice chat or press Enter to type in the text chat.",
            "The less stamina you have, the more rifle sway you will have when aiming.",
            "Take cover when being bombarded by the artillery to increase your chances of survival.",
        };

        public static string RandomTip()
        {
            return Tips[Random.Next(Tips.Length)];
        }
    }
}
