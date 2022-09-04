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

namespace WarOfRightsWeb.Utility
{
    // DiscordConfig Gateway Thread

    public class DiscordBotService : IHostedService
    {
        private DiscordSocketClient _client;
        private InteractionService _interactionService;
        private readonly Models.DiscordConfig _discordConfigOptions;

        private readonly IConfiguration _configuration;
        private readonly ILogger<DiscordBotService> _logger;
        private readonly IServiceProvider _serviceProvider;

        public DiscordBotService(ILogger<DiscordBotService> logger,
            IConfiguration configuration,
            IServiceProvider serviceProvider,
            IOptionsMonitor<Models.DiscordConfig> discordOptions)
        {
            _logger = logger;
            _configuration = configuration;
            _serviceProvider = serviceProvider;
            _discordConfigOptions = discordOptions.CurrentValue;
            discordOptions.OnChange(Listener);
        }

        private void Listener(Models.DiscordConfig discordConfigOptions)
        {
            
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var config = new DiscordSocketConfig()
            {
                
            };

            _client = new DiscordSocketClient(config);

            _client.Log += LogAsync;
            _client.Ready += ClientOnReady;
            // _command.Log += LogAsync;

            var token = _configuration.GetValue<string>("DiscordBotToken");

            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();
        }

        private async Task ClientOnReady()
        {
            _interactionService = new InteractionService(_client);
            await _interactionService.AddModulesAsync(Assembly.GetEntryAssembly(), _serviceProvider);
            await _interactionService.RegisterCommandsToGuildAsync(_discordConfigOptions.GuildId);

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
            var id = _discordConfigOptions.AnnouncementChannelId;
            if (_client.GetChannel(id) is IMessageChannel channel)
            {
                await channel.SendMessageAsync("Event!");
            }
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await _client.StopAsync();
        }
    }
}
