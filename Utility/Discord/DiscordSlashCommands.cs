using System;
using System.Collections.Generic;
using System.Linq;
using Discord.Interactions;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using WarOfRightsWeb.Common;
using WarOfRightsWeb.Models;

namespace WarOfRightsWeb.Utility.Discord
{
    public class DiscordSlashCommands : InteractionModuleBase<SocketInteractionContext>
    {
        private readonly IConfiguration _configuration;

        public DiscordSlashCommands(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [SlashCommand("next-event", "When is the next event?")]
        public async Task NextEvent()
        {
            var eventTemplates = _configuration.GetEventTemplates();

            var startDate = DateTime.Now.Date;
            var endDate = startDate.AddMonths(1);

            var scheduledEvents = new List<Event>();

            foreach (var currentDate in Extensions.EachDay(startDate, endDate))
            {
                scheduledEvents.AddRange(Extensions.GetEventsByDate(eventTemplates, currentDate));
            }

            // Return information only about scheduled future events
            scheduledEvents = scheduledEvents.Where(x => x.Starting > DateTime.Now).ToList();

            if (!scheduledEvents.Any())
            {
                await RespondAsync("No events have been found for the next month.");
            }
            else
            {
                var nextEvent = scheduledEvents.First();
                var eventTime = TimeZoneInfo.ConvertTime(nextEvent.Starting,
                    Extensions.GetCentralEuropeanTimeZoneInfo());

                await RespondAsync($"Next event will be at {eventTime.ToString("MMMM d, h tt")} CET.");
            }
        }
    }
}
