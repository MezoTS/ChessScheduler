using ChessScheduler.Bot.Builders;
using ChessScheduler.Bot.Data.Clients;
using ChessScheduler.Bot.Commands;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using ChessScheduler.Bot.Data.Repositories;
using ChessScheduler.Bot.Data.Clients.DTOs;
using ChessScheduler.Bot.Data.Models;

namespace ChessScheduler.Bot.Handlers
{
    public class SendPodiumCommandHandler
    {
        private readonly DiscordWebhookBuilder _webhook;
        private readonly ILichessClient _lichessClient;
        private readonly IServerRepository _serverRepository;

        public SendPodiumCommandHandler(
            DiscordWebhookBuilder webhook,
            ILichessClient lichessClient,
            IServerRepository serverRepository)
        {
            _webhook = webhook;
            _lichessClient = lichessClient;
            _serverRepository = serverRepository;
        }

        public async Task Handle(InteractionContext context, SendPodiumCommand command)
        {
            await context.DeferAsync();

            // Get server
            var server = await _serverRepository.GetServerAsync(context.Guild.Id);
            if (server == null || !server.IsSettedUp)
            {
                throw new ArgumentException(
                    $"Server não configurado. Use `/podio setup` para configurar.");
            }

            // Get podium channel
            DiscordChannel channel;
            try
            {
                channel = context.Guild.Channels[server.PodiumChannel];
            }
            catch
            {
                throw new ArgumentException($"Canal {server.PodiumChannel} não encontrado neste servidor.");
            }

            // Get champion role
            DiscordRole role;
            try
            {
                role = context.Guild.Roles[server.ChampionRole];
            }
            catch
            {
                throw new ArgumentException($"Cargo {server.ChampionRole} não encontrado neste servidor.");
            }

            // Get last swiss tournament
            LichessSwissInfo lichessSwiss;
            try
            {
                lichessSwiss = await _lichessClient.GetLastSwissTournamentAsync(server.TeamName);
            }
            catch
            {
                throw new ArgumentException($"Erro ao buscar último torneio suíço.");
            }

            // Get tournament podium
            var lichessResult = await _lichessClient.GetSwissPodiumAsync(lichessSwiss.Id);

            // Build own model
            var swissResult = SwissResult.FromLichess(lichessSwiss, lichessResult, command.ImageLink);

            // Build embed
            var podiumEmbed = EmbedBuilder.FromSwissResult(swissResult);

            // Send embed and give roles
            var podiumMessage = await channel.SendMessageAsync(podiumEmbed);
            command.Champions.ForEach(async champion => 
            {
                await champion.GrantRoleAsync(role);
            });

            // Send success message
            var responseEmbed = EmbedBuilder.AfterPodiumMessage(podiumMessage);
            _webhook.AddEmbed(responseEmbed);
            await context.EditResponseAsync(_webhook);
        }
    }
}
