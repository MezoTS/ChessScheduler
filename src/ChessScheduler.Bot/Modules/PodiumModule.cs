using ChessScheduler.Bot.Commands;
using ChessScheduler.Bot.Handlers;
using ChessScheduler.Bot.Utils;
using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;

namespace ChessScheduler.Bot.Modules
{
    public class PodiumModule : ApplicationCommandModule
    {
        private readonly DiscordWebhookBuilder _webhook;
        private readonly SendPodiumCommandHandler _handler;

        public PodiumModule(DiscordWebhookBuilder webhook, SendPodiumCommandHandler handler)
        {
            _webhook = webhook;
            _handler = handler;
        }

        [SlashCommand("podio", "Posta o pódio de um torneio neste canal")]
        public async Task SendPodiumAsync(InteractionContext context, [Option("link", "Link do torneio")] string link)
        {
            await context.DeferAsync();

            var command = new SendPodiumCommand(link);
            var embed = await _handler.Handle(command);

            //await context.Channel.SendMessageAsync(embed);
            await context.EditResponseAsync(_webhook.AddEmbed(embed));
        }
    }
}
