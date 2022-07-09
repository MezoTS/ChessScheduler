using ChessScheduler.Bot.Builders;
using ChessScheduler.Bot.Commands;
using DSharpPlus.Entities;

namespace ChessScheduler.Bot.Handlers
{
    public class SetupPodiumCommandHandler
    {
        private readonly DiscordWebhookBuilder _webhook;

        public SetupPodiumCommandHandler(DiscordWebhookBuilder webhook)
        {
            _webhook = webhook;
        }

        public async Task Handle(SetupPodiumCommand command)
        {
            await command.Context.DeferAsync();

            // Save podium channel

            // Save role

            // Respond with embed
            var message = EmbedBuilder.AfterSuccessAction();
            await command.Context.EditResponseAsync(_webhook.AddEmbed(message));
        }
    }
}
