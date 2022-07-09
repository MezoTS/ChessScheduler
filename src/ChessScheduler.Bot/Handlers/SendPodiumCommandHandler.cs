using ChessScheduler.Bot.Builders;
using ChessScheduler.Bot.Data.Clients;
using ChessScheduler.Bot.Commands;
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
            var podiumEmbed = EmbedBuilder.FromSwissPodium(swissInfo, command);

            var podiumMessage = await command.Channel.SendMessageAsync(podiumEmbed);

            command.Champions.ForEach(champion =>
            {
                // TODO: Validate if role is not admin
                champion.GrantRoleAsync(command.Role);
            });

            var responseEmbed = EmbedBuilder.AfterPodiumMessage(podiumMessage);
            await context.EditResponseAsync(_webhook.AddEmbed(responseEmbed));
        }
    }
}
