using System;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Discord;
using Discord.Commands;
using Discord.Interactions;
using Discord.WebSocket;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic;
using Serilog;
using Serilog.Core;
using WarOfRightsWeb.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using DiscordConfig = Discord.DiscordConfig;

namespace WarOfRightsWeb.Utility
{
    // DiscordConfig Gateway Thread

    public class DiscordBotService : IHostedService
    {
        private DiscordSocketClient _client;
        private InteractionService _interactionService;
        private readonly Models.DiscordConfig _discordConfig;

        private readonly ILogger<DiscordBotService> _logger;

        public DiscordBotService(ILogger<DiscordBotService> logger,
            IServiceProvider serviceProvider,
            IConfiguration configuration)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
            _discordConfig = configuration
                .GetSection("DiscordConfig")
                .Get<Models.DiscordConfig>();
        }

        private readonly IServiceProvider _serviceProvider;

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var config = new DiscordSocketConfig()
            {
                
            };

            _client = new DiscordSocketClient(config);

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
                    $"[Command/{message.Severity}] {cmdException.Command.Aliases.First()} failed to execute in {cmdException.Context.Channel}.");
            }
            else
            {
                _logger.LogInformation($"[General/{message.Severity}] {message}");
            }

            return Task.CompletedTask;
        }

        public async Task AnnounceEvent()
        {
            var id = _discordConfig.AnnouncementChannelId;
            if (_client.GetChannel(id) is IMessageChannel channel)
            {
                await channel.SendMessageAsync("Event!");
            }
        }

        public async Task CreateDiscordEvent()
        {
            var guild = _client.GetGuild(_discordConfig.GuildId);

            var guildEvent = await guild.CreateEventAsync(
                name: "Event!",
                type: GuildScheduledEventType.Voice,
                startTime: DateTimeOffset.UtcNow.AddMinutes(1),
                endTime: DateTimeOffset.UtcNow.AddMinutes(6), 
                channelId: _discordConfig.MusterVoiceChannelId);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await _client.StopAsync();
        }
    }
}
