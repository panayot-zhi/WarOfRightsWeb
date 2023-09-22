using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Discord.Interactions;
using Discord.WebSocket;
using Discord.Commands;
using Discord;
using WarOfRightsWeb.Common;
using WarOfRightsWeb.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace WarOfRightsWeb.Utility.Discord
{
    // DiscordConfig Gateway Thread

    public class DiscordBotService : IHostedService
    {
        private DiscordSocketClient _client;
        private InteractionService _interactionService;
        private readonly Models.DiscordConfig _discordConfig;
        private static readonly object Initializator = new();
        private static bool _initialized;

        private readonly IConfiguration _configuration;
        private readonly IServiceProvider _serviceProvider;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly ILogger<DiscordBotService> _logger;

        public DiscordBotService(ILogger<DiscordBotService> logger,
            IServiceProvider serviceProvider,
            IConfiguration configuration,
            IWebHostEnvironment hostingEnvironment)
        {
            _logger = logger;
            _configuration = configuration;
            _serviceProvider = serviceProvider;
            _hostingEnvironment = hostingEnvironment;
            _discordConfig = configuration
                .GetSection("DiscordConfig")
                .Get<Models.DiscordConfig>();
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            if (!_discordConfig.Enabled)
            {
                _logger.LogWarning("Discord bot service has been disabled and will not run, Ed Weston is on vacation.");
                return;
            }

            // no re-init pls
            lock (Initializator)
            {
                if (_initialized)
                {
                    return;
                }

                var config = new DiscordSocketConfig()
                {
                    GatewayIntents = GatewayIntents.AllUnprivileged | GatewayIntents.GuildMembers
                };

                _client = new DiscordSocketClient(config);
                _initialized = true;
            }

            _client.Log += LogAsync;
            _client.Ready += ClientOnReady;

            var token = _discordConfig.BotToken;

            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();
        }

        private async Task ClientOnReady()
        {
            _interactionService = new InteractionService(_client);
            await _interactionService.AddModulesAsync(Assembly.GetEntryAssembly(), _serviceProvider);
            await _interactionService.RegisterCommandsToGuildAsync(_discordConfig.GuildId);

            _client.InteractionCreated += ClientOnInteraction;
        }

        private async Task ClientOnInteraction(SocketInteraction interaction)
        {
            var scope = _serviceProvider.CreateScope();
            var ctx = new SocketInteractionContext(_client, interaction);
            await _interactionService.ExecuteCommandAsync(ctx, scope.ServiceProvider);
        }

        private Task LogAsync(LogMessage message)
        {
            if (message.Exception is CommandException cmdException)
            {
                _logger.LogError(message.Exception,
                    $"[Command/{message.Severity}] {cmdException.Command.Aliases.First()} " +
                    $"failed to execute in {cmdException.Context.Channel}.");
            }
            else
            {
                _logger.LogInformation($"[General/{message.Severity}] {message}");
            }

            return Task.CompletedTask;
        }

        public async Task CheckForEventToday()
        {
            var eventTemplates = _configuration.GetEventTemplates();
            var events = Extensions.GetEventsByDate(eventTemplates, DateTime.Now.Date);
            if (events.Any())
            {
                var evt = events.First();
                await AnnounceEvent(evt);
            }
        }

        public async Task TestMessage()
        {
            var members = await GetAllMembers();
            if (members.Any())
            {
                Console.WriteLine($"Found {members.Count} guild members.");
            }

            var id = _discordConfig.AnnouncementChannelId;
            if (_client.GetChannel(id) is IMessageChannel channel)
            {
                // var imagePath = Path.Combine(_hostingEnvironment.WebRootPath, "img", "north_and_south_fighting.png");
                // var eventTime = TimeZoneInfo.ConvertTime(evt.Starting, Extensions.GetCentralEuropeanTimeZoneInfo());
                // var eventHour = eventTime.ToString("h tt");

                var embed = new EmbedBuilder()
                    .WithTitle("My Title")
                    .WithDescription("This is the description of my message.")
                    .WithColor(Color.Green)
                    .AddField("Field 1", "This is the value of field 1.")
                    .AddField("Field 2", "This is the value of field 2.")
                    .WithImageUrl("https://1usssf.eu/img/1ussscof_baner.png")
                    .WithFooter("My footer text")
                    .WithUrl("https://google.bg")
                    .Build();

                var builder = new ComponentBuilder()
                    .WithButton("label", "custom-id");

                _client.ButtonExecuted += MyButtonHandler;

                var result = await channel.SendMessageAsync(text: "TEST, WHERE DOES THIS GO?", embed: embed, components: builder.Build());
            }
        }

        public async Task MyButtonHandler(SocketMessageComponent component)
        {
            var embed = new EmbedBuilder()
                .WithTitle("My Title")
                .WithDescription("This is the description of my message.")
                .WithColor(Color.Red)
                .AddField("Field 1", $"This is the value of field {new Random().Next()}.")
                .AddField("Field 2", "This is the value of field 2.")
                .WithImageUrl("https://1usssf.eu/img/1ussscof_baner.png")
                .WithFooter("My footer text")
                .WithUrl("https://google.bg")
                .Build();

            // We can now check for our custom id
            switch (component.Data.CustomId)
            {
                // Since we set our buttons custom id as 'custom-id', we can check for it like this:
                case "custom-id":
                    // Lets respond by sending a message saying they clicked the button
                    await component.Channel.ModifyMessageAsync(component.Message.Id, m =>
                    {
                        m.Embed = embed;
                    });

                    await component.RespondAsync();
                    break;
            }
        }

        public async Task<List<SocketGuildUser>> GetAllMembers()
        {
            var guild = _client.GetGuild(_discordConfig.GuildId);
            if (guild == null)
            {
                Console.WriteLine($"Could not find guild with ID: {_discordConfig.GuildId}");
                return new List<SocketGuildUser>();
            }

            // DownloadUsersAsync makes sure that we have all the member info
            await guild.DownloadUsersAsync();

            return guild.Users.ToList();
        }

        public async Task AnnounceEvent(Event evt)
        {
            var id = _discordConfig.AnnouncementChannelId;
            if (_client.GetChannel(id) is IMessageChannel channel)
            {
                var imagePath = Path.Combine(_hostingEnvironment.WebRootPath, "img", "north_and_south_fighting.png");
                var eventTime = TimeZoneInfo.ConvertTime(evt.Starting, Extensions.GetCentralEuropeanTimeZoneInfo());
                var eventHour = eventTime.ToString("h tt");

                var yes = new Emoji("✅");
                var unsure = new Emoji("☑️");
                var no = new Emoji("❌");

                var message = await channel.SendFileAsync(imagePath, text: $"@everyone Come join the {evt.Name}. We start at **{eventHour} CET**.");

                await message.AddReactionAsync(yes);
                await message.AddReactionAsync(unsure);
                await message.AddReactionAsync(no);
            }
        }

        public async Task CreateDiscordEvent()
        {
            var guild = _client.GetGuild(_discordConfig.GuildId);

            var _ = await guild.CreateEventAsync(
                name: "Event!",
                type: GuildScheduledEventType.Voice,
                startTime: DateTimeOffset.UtcNow.AddMinutes(1),
                endTime: DateTimeOffset.UtcNow.AddMinutes(6),
                channelId: _discordConfig.MusterVoiceChannelId);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            if (_client is not null)
            {
                await _client.StopAsync();
            }
        }
    }
}
