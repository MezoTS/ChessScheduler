using ChessScheduler.Bot.Commands;
using ChessScheduler.Bot.Handlers;
using DSharpPlus.SlashCommands;

namespace ChessScheduler.Bot.Modules
{
    public class PodiumModule : ApplicationCommandModule
    {
        private readonly SendPodiumCommandHandler _handler;

        public PodiumModule(SendPodiumCommandHandler handler)
        {
            _handler = handler;
        }

        [SlashCommand("podio", "Posta o pódio de um torneio neste canal")]
        public async Task SendPodiumAsync(InteractionContext context, [Option("link", "Link do torneio")] string link)
        {
            var command = new SendPodiumCommand(link);
            await _handler.Handle(context, command);
        }
    }
}
