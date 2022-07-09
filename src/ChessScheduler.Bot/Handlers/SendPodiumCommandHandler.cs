using ChessScheduler.Bot.Clients;
using ChessScheduler.Bot.Commands;
using ChessScheduler.Bot.Utils;
using DSharpPlus.Entities;

namespace ChessScheduler.Bot.Handlers
{
    public class SendPodiumCommandHandler
    {
        private readonly ILichessClient _lichessClient;

        public SendPodiumCommandHandler(ILichessClient lichessClient)
        {
            _lichessClient = lichessClient;
        }

        public async Task<DiscordEmbed> Handle(SendPodiumCommand command)
        {
            // Get tournament id
            var tournamentId = command.TournamentLink.Split('/').Last();

            // Get tournament data
            var swissInfo = await _lichessClient.GetSwissInfoAsync(tournamentId);

            // Build embed
            var embed = swissInfo.ToDiscordEmbed();
            return embed;
        }
    }
}
