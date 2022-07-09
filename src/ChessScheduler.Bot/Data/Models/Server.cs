namespace ChessScheduler.Bot.Data.Models
{
    public class Server
    {
        public ulong Id { get; set; }
        public ulong PodiumChannel { get; set; }
        public ulong ChampionRole { get; set; }
        public string LichessTeam { get; set; } = string.Empty;
    }
}
