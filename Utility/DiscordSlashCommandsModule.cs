using System;
using Discord.Interactions;
using System.Threading.Tasks;

namespace WarOfRightsWeb.Utility
{
    public class DiscordSlashCommandsModule : InteractionModuleBase<SocketInteractionContext>
    {
        [SlashCommand("next-event", "When is the next event?")]
        public async Task NextEvent()
        {
            await RespondAsync(DateTime.Now.ToString("O"));
        }

        [SlashCommand("next-event-announcement", "When will be the next event announcement?")]
        public async Task NextEventAnnouncement()
        {
            await RespondAsync(DateTime.Now.AddHours(-1).ToString("O"));
        }
    }
}
