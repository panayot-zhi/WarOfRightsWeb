using Hangfire;
using WarOfRightsWeb.Common;
using WarOfRightsWeb.Utility.Discord;

namespace WarOfRightsWeb.Utility.Hangfire
{
    public class HangfireJobRegistry
    {
        public static void Register()
        {
            RecurringJob.AddOrUpdate<DiscordBotService>(
                "CheckForEventToday",
                (bot) => bot.CheckForEventToday(),
                cronExpression: Cron.Never, //Cron.Daily(9), 
                Extensions.GetCentralEuropeanTimeZoneInfo());

            RecurringJob.AddOrUpdate<DiscordBotService>(
                "Test",
                (bot) => bot.TestMessage(),
                cronExpression: Cron.Never, //Cron.Daily(9), 
                Extensions.GetCentralEuropeanTimeZoneInfo());
        }
    }
}
