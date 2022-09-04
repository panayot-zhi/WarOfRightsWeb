using System;
using System.Linq;
using Discord.Interactions;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using WarOfRightsWeb.Common;

namespace WarOfRightsWeb.Utility
{
    public class DiscordSlashCommandsModule : InteractionModuleBase<SocketInteractionContext>
    {
        private readonly IConfiguration _configuration;

        public DiscordSlashCommandsModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [SlashCommand("next-event", "When is the next event?")]
        public async Task NextEvent()
        {
            var eventTemplates = _configuration.GetEventTemplates();
            var events = Extensions.GetEventsByDate(eventTemplates, DateTime.Now.Date);
            if (!events.Any())
            {
                await RespondAsync("No events have been found. :(");
            }
            else
            {
                var nextEvent = events.First();
                var eventTime = TimeZoneInfo.ConvertTime(nextEvent.Starting, 
                    Extensions.GetCentralEuropeanTimeZoneInfo());

                await RespondAsync($"Next event will be at {eventTime.ToString("MMMM d, h tt")} CET.");
            }
        }
    }
}
