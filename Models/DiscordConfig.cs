namespace WarOfRightsWeb.Models
{
    public class DiscordConfig
    {
        public ulong GuildId { get; set; }

        public string BotToken { get; set; }
        
        public ulong AnnouncementChannelId { get; set; }
    }
}
