namespace ChessScheduler.Core.Setup.Commands
{
    public class SetTeamCommand
    {
        public string TeamName { get; set; } = string.Empty;
        public long ServerId { get; set; }
    }
}
