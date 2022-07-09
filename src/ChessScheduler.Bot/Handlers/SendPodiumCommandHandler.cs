using ChessScheduler.Bot.Clients;
using ChessScheduler.Bot.Commands;
using ChessScheduler.Bot.Utils;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;

namespace ChessScheduler.Bot.Handlers
{
    public class SendPodiumCommandHandler
    {
        private readonly DiscordWebhookBuilder _webhook;
        private readonly ILichessClient _lichessClient;

        public SendPodiumCommandHandler(DiscordWebhookBuilder webhook, ILichessClient lichessClient)
        {
            _webhook = webhook;
            _lichessClient = lichessClient;
        }

        public async Task Handle(InteractionContext context, SendPodiumCommand command)
        {
            await context.DeferAsync();

            var tournamentId = command.TournamentLink.Split('/').Last();
            var swissInfo = await _lichessClient.GetSwissInfoAsync(tournamentId);
            var embed = swissInfo.ToDiscordEmbed();

            await context.EditResponseAsync(_webhook.AddEmbed(embed));
        }
    }
}
