using DSharpPlus.SlashCommands;

namespace ChessScheduler.Bot.Commands
{
    public class SendPodiumCommand
    {
        public SendPodiumCommand(string tournamentLink)
        {
            TournamentLink = tournamentLink;
        }

        public string TournamentLink { get; set; }
    }
}
