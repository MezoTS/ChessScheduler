using ChessScheduler.Bot.Builders;
using ChessScheduler.Bot.Commands;
using ChessScheduler.Bot.Data.Repositories;
using DSharpPlus.Entities;

namespace ChessScheduler.Bot.Handlers
{
    public class SetupPodiumCommandHandler
    {
        private readonly DiscordWebhookBuilder _webhook;
        private readonly IServerRepository _serverRepository;

        public SetupPodiumCommandHandler(
            DiscordWebhookBuilder webhook,
            IServerRepository serverRepository)
        {
            _webhook = webhook;
            _serverRepository = serverRepository;
        }

        public async Task Handle(SetupCommand command)
        {
            await command.Context.DeferAsync();

            DiscordEmbed message;
            // Save role
            try
            {
                await _serverRepository.AddOptionsAsync(command.Server);
                message = EmbedBuilder.AfterSuccessAction();
            }
            catch (Exception ex)
            {
                message = EmbedBuilder.AfterFailedAction(ex);
            }

            // Respond with embed
            await command.Context.EditResponseAsync(_webhook.AddEmbed(message));
        }
    }
}
