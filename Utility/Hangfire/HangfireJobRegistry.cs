using Hangfire;
using WarOfRightsWeb.Common;
using WarOfRightsWeb.Utility.Discord;

namespace WarOfRightsWeb.Utility.Hangfire
{
    public class HangfireJobRegistry
    {
        public static void Register()
        {
            // CHECK FOR EVENT TODAY
            RecurringJob.AddOrUpdate<DiscordBotService>(
                nameof(DiscordBotService.CheckForEventToday),
                (bot) => bot.CheckForEventToday(),
                cronExpression: Cron.Never, //Cron.Daily(9), 
                Extensions.GetCentralEuropeanTimeZoneInfo());

            // RETRIEVE DISCORD COMPANY MEMBERS
            RecurringJob.AddOrUpdate<DiscordBotService>(
                nameof(DiscordBotService.UpdateCompanyDiscordMembers),
                (bot) => bot.UpdateCompanyDiscordMembers(),
                cronExpression: Cron.Never, //Cron.Daily(9), 
                Extensions.GetCentralEuropeanTimeZoneInfo());

            // SEND TEST MESSAGE TO ANNOUNCEMENT CHANNEL
            RecurringJob.AddOrUpdate<DiscordBotService>(
                nameof(DiscordBotService.TestMessage),
                (bot) => bot.TestMessage(),
                cronExpression: Cron.Never, //Cron.Daily(9), 
                Extensions.GetCentralEuropeanTimeZoneInfo());
        }
    }
}
