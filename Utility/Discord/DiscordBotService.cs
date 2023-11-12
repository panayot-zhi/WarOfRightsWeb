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
using AutoMapper;
using Newtonsoft.Json;
using WarOfRightsWeb.Utility.Configuration;

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

        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IServiceProvider _serviceProvider;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly ILogger<DiscordBotService> _logger;
        private readonly ConfigurationHelper _configHelper;

        public DiscordBotService(ILogger<DiscordBotService> logger,
            IServiceProvider serviceProvider,
            IConfiguration configuration,
            IWebHostEnvironment hostingEnvironment,
            ConfigurationHelper configHelper,
            IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _configHelper = configHelper;
            _configuration = configuration;
            _serviceProvider = serviceProvider;
            _hostingEnvironment = hostingEnvironment;
            _discordConfig = configuration
                .GetSection(nameof(Models.DiscordConfig))
                .Get<Models.DiscordConfig>();
        }

        #region LowLevel

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
            _client.UserJoined += UserJoinedAsync;
            _client.MessageReceived += MessageReceivedAsync;
            _client.ButtonExecuted += InteractionButtonExecuted;

            var token = _discordConfig.BotToken;

            await _client.LoginAsync(TokenType.Bot, token);
            await _client.StartAsync();
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            if (_client is not null)
            {
                await _client.StopAsync();
            }
        }

        private async Task<List<SocketGuildUser>> GetGuildMembers()
        {
            var guild = _client.GetGuild(_discordConfig.GuildId);
            if (guild == null)
            {
                _logger.LogWarning($"Could not find guild with ID: {_discordConfig.GuildId}");
                return new List<SocketGuildUser>();
            }

            // DownloadUsersAsync makes sure
            // that we have all the member info
            await guild.DownloadUsersAsync();

            var members = guild.Users;
            return members.ToList();
        }

        private async Task ClientOnInteraction(SocketInteraction interaction)
        {
            var scope = _serviceProvider.CreateScope();
            var ctx = new SocketInteractionContext(_client, interaction);
            await _interactionService.ExecuteCommandAsync(ctx, scope.ServiceProvider);
        }

        private async Task UserJoinedAsync(SocketGuildUser user)
        {
            // Send the user a direct message
            await UpdateCompanyDiscordMembers();
            await user.SendMessageAsync("Welcome to the server! Let us know if you have any questions.");
        }

        public const string EventInteractionIdPrefix = "event_";
        public const string AttendInteractionIdLabel = "Attend";
        public const string DenyInteractionIdLabel = "Deny";
        public const string MaybeInteractionIdLabel = "Maybe";

        public async Task InteractionButtonExecuted(SocketMessageComponent component)
        {
            var companyMember = _configHelper.GetCompanyDiscordMember(component.User.Id);

            // if the component id begins with EventInteractionIdPrefix
            if (component.Data.CustomId.StartsWith(EventInteractionIdPrefix))
            {
                await EventInteractionAcknowledge(component);
            }

            // respond to request for sure
            if (!component.HasResponded)
            {
                await component.DeferAsync(ephemeral: true);
            }
        }

        private async Task MessageReceivedAsync(SocketMessage message)
        {
            var companyMember = _configHelper.GetCompanyDiscordMember(message.Author.Id);
            if (message.Channel is IDMChannel && companyMember is not null && !companyMember.IsBot)
            {
                // if the message is from a DM channel
                // if the author is the user we're interested in
                // if the user sending the message is not a bot
                // then respond to a private message
                await RespondToPrivateMessage(message);
            }
        }

        private async Task ClientOnReady()
        {
            _interactionService = new InteractionService(_client);
            await _interactionService.AddModulesAsync(Assembly.GetEntryAssembly(), _serviceProvider);
            await _interactionService.RegisterCommandsToGuildAsync(_discordConfig.GuildId);

            _client.InteractionCreated += ClientOnInteraction;
        }

        #endregion LowLevel

        #region HighLevel

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

        public async Task UpdateCompanyDiscordMembers()
        {
            var guild = _client.GetGuild(_discordConfig.GuildId);
            if (guild == null)
            {
                _logger.LogWarning($"Could not find guild with ID: {_discordConfig.GuildId}");
                return;
            }

            // DownloadUsersAsync makes sure
            // that we have all the member info
            await guild.DownloadUsersAsync();

            var members = guild.Users;

            if (!members.Any())
            {
                _logger.LogWarning("No members found in guild!");
            }

            var companyMembers = new CompanyMembers()
            {
                Members = members
                    .Where(x => !x.IsBot)
                    .Select(x => _mapper.Map<CompanyMember>(x))
                    .ToList()
            };

            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "json", "discordMembers.json");
            var jsonContent = JsonConvert.SerializeObject(companyMembers, Formatting.Indented);

            await File.WriteAllTextAsync(filePath, jsonContent);
        }

        private async Task RespondToPrivateMessage(SocketMessage message)
        {
            await message.Channel.SendMessageAsync("Thanks for reaching out! How can I assist you?");
        }

        public async Task ModifyMemberNickname(ulong id, string nickname)
        {
            var users = await GetGuildMembers();
            var user = users.SingleOrDefault(x => x.Id == id);
            if (user is null)
            {
                _logger.LogWarning("Could not find user with id {UserId} in guild.", id);
                return;
            }

            await user.ModifyAsync(properties => properties.Nickname = nickname);
        }

        public async Task AnnounceEvent(Event evt)
        {
            var id = _discordConfig.AnnouncementChannelId;
            if (_client.GetChannel(id) is IMessageChannel channel)
            {
                var eventEmbedData = new EventEmbedData()
                {
                    EventData = evt
                };

                var embed = GenerateEmbed(eventEmbedData);

                var builder = new ComponentBuilder()
                    .WithButton(AttendInteractionIdLabel, EventInteractionIdPrefix + AttendInteractionIdLabel, style: ButtonStyle.Success)
                    .WithButton(MaybeInteractionIdLabel, EventInteractionIdPrefix + MaybeInteractionIdLabel, style: ButtonStyle.Secondary)
                    .WithButton(DenyInteractionIdLabel, EventInteractionIdPrefix + DenyInteractionIdLabel, style: ButtonStyle.Danger);

                await channel.SendMessageAsync(text: "@everyone", embed: embed, components: builder.Build());
            }
        }

        private async Task EventInteractionAcknowledge(SocketMessageComponent component)
        {
            var eventEmbedData = GetEventEmbedData(component.Message.Embeds.Single());
            UpdateEventEmbedData(eventEmbedData, component);
            var embed = GenerateEmbed(eventEmbedData);
            await component.Channel.ModifyMessageAsync(component.Message.Id, m =>
            {
                m.Embed = embed;
            });
        }

        private void UpdateEventEmbedData(EventEmbedData eventEmbedData, SocketMessageComponent component)
        {
            var userIdentifier = component.User.Username;
            var componentId = component.Data.CustomId;

            if (componentId.EndsWith(AttendInteractionIdLabel))
            {
                // remove from current list if present and break execution
                if (eventEmbedData.AcceptedAttendees.Contains(userIdentifier))
                {
                    eventEmbedData.AcceptedAttendees.Remove(userIdentifier);
                    return;
                }

                // remove from other lists if present
                if (eventEmbedData.DeclinedAttendees.Contains(userIdentifier))
                {
                    eventEmbedData.DeclinedAttendees.Remove(userIdentifier);
                }
                else if (eventEmbedData.TentativeAttendees.Contains(userIdentifier))
                {
                    eventEmbedData.TentativeAttendees.Remove(userIdentifier);
                }

                // add to current list
                eventEmbedData.AcceptedAttendees.Add(userIdentifier);
            }
            else if (componentId.EndsWith(DenyInteractionIdLabel))
            {
                // remove from current list if present and break execution
                if (eventEmbedData.DeclinedAttendees.Contains(userIdentifier))
                {
                    eventEmbedData.DeclinedAttendees.Remove(userIdentifier);
                    return;
                }

                // remove from other lists if present
                if (eventEmbedData.AcceptedAttendees.Contains(userIdentifier))
                {
                    eventEmbedData.AcceptedAttendees.Remove(userIdentifier);
                }
                else if (eventEmbedData.TentativeAttendees.Contains(userIdentifier))
                {
                    eventEmbedData.TentativeAttendees.Remove(userIdentifier);
                }

                // add to current list
                eventEmbedData.DeclinedAttendees.Add(userIdentifier);
            }
            else if (componentId.EndsWith(MaybeInteractionIdLabel))
            {
                // remove from current list if present and break execution
                if (eventEmbedData.TentativeAttendees.Contains(userIdentifier))
                {
                    eventEmbedData.TentativeAttendees.Remove(userIdentifier);
                    return;
                }

                // remove from other lists if present
                if (eventEmbedData.DeclinedAttendees.Contains(userIdentifier))
                {
                    eventEmbedData.DeclinedAttendees.Remove(userIdentifier);
                }
                else if (eventEmbedData.AcceptedAttendees.Contains(userIdentifier))
                {
                    eventEmbedData.AcceptedAttendees.Remove(userIdentifier);
                }

                // add to current list
                eventEmbedData.TentativeAttendees.Add(userIdentifier);
            }
            else
            {
                throw new ArgumentException($"Cannot recognize interaction from component with id '{componentId}'.");
            }
        }

        private EventEmbedData GetEventEmbedData(Embed message)
        {
            // can we resolve event by timestamp?
            return new EventEmbedData()
            {
            };
        }

        #endregion HighLevel

        private static Embed GenerateEmbed(EventEmbedData eventEmbedData)
        {
            string FormatList(IReadOnlyCollection<string> attendees)
            {
                if (!attendees.Any())
                {
                    return "-";
                }

                return string.Join("\n> ", attendees);
            }

            var evt = eventEmbedData.EventData;
            var embed = new EmbedBuilder()
                .WithTitle(evt.Name)
                .WithTimestamp(evt.Starting)
                .WithUrl("https://1usssf.eu/Events")
                .WithDescription(evt.Description)
                .WithColor(Color.Orange)
                .AddField("Time",
                    $"<t:{((DateTimeOffset)evt.Starting).ToUnixTimeSeconds()}:F>{Environment.NewLine}🕐 <t:{((DateTimeOffset)evt.Starting).ToUnixTimeSeconds()}:R>")
                .AddField("Accepted (" + eventEmbedData.AcceptedAttendees.Count + ")", FormatList(eventEmbedData.AcceptedAttendees))
                .AddField("Declined (" + eventEmbedData.DeclinedAttendees.Count + ")", FormatList(eventEmbedData.DeclinedAttendees))
                .AddField("Tentative (" + eventEmbedData.TentativeAttendees.Count + ")", FormatList(eventEmbedData.TentativeAttendees))
                .WithImageUrl("https://1usssf.eu/img/1ussscof_baner.png")
                .WithFooter($"Created by [1.USSS.F] Cpt. John Brown • Repeats {evt.Occurring}")
                .Build();

            return embed;
        }


        public async Task TestAnnounce()
        {
            var eventTemplates = _configuration.GetEventTemplates();
            var events = Extensions.GetEventsByDate(eventTemplates, DateTime.Now.Date);
            var evt = events.First();
            await AnnounceEvent(evt);
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
    }
}
