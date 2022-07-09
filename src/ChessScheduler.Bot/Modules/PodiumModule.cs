using ChessScheduler.Bot.Commands;
using ChessScheduler.Bot.Handlers;
using DSharpPlus.Entities;
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
        public async Task SendPodiumAsync(
            InteractionContext context,
            [Option("torneio", "Link do torneio")] string tournamentLink,
            [Option("imagem", "Link da imagem")] string imageLink,
            [Option("canal", "Canal onde será postado o pódio")] DiscordChannel channel,
            [Option("campeao", "Campeão do torneio")] DiscordUser first,
            [Option("vice", "Vice-campeão do torneio")] DiscordUser second,
            [Option("terceiro", "Terceiro colocado do torneio")] DiscordUser third,
            [Option("cargo", "Cargo a ser recebido pelos campeões")] DiscordRole role)
        {
            var command = new SendPodiumCommand(tournamentLink, imageLink, channel, first, second, third, role);
            await _handler.Handle(context, command);
        }
    }
}
