using ChessScheduler.Bot.Commands;
using ChessScheduler.Bot.Handlers;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;

namespace ChessScheduler.Bot.Modules
{
    [SlashCommandGroup("podio", "Comandos relacionados a pódios de torneios finalizados")]
    public class PodiumModule : ApplicationCommandModule
    {
        private readonly SendPodiumCommandHandler _sendHandler;
        private readonly SetupPodiumCommandHandler _setupHandler;

        public PodiumModule(SendPodiumCommandHandler sendHandler, SetupPodiumCommandHandler setupHandler)
        {
            _sendHandler = sendHandler;
            _setupHandler = setupHandler;
        }

        [SlashCommand("setup", "Configura as opções a serem usadas pelo comando `postar`")]
        public async Task SetupPodiumAsync(
            InteractionContext context,
            [Option("time", "Nome do time no Lichess pertencente a este servidor")] string team,
            [Option("canal", "Canal onde serão enviadas as mensagens de pódio")] DiscordChannel channel,
            [Option("cargo", "Cargo concedido aos três primeiros colocados de cada torneio")] DiscordRole role)
        {
            var command = new SetupCommand(team, role, channel, context);
            await _setupHandler.Handle(command);
        }

        [SlashCommand("postar", "Posta o pódio de um torneio em um canal, e concede o cargo selecionado aos campeões")]
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
            await _sendHandler.Handle(context, command);
        }
    }
}
