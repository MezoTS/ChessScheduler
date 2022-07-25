using System.ComponentModel.DataAnnotations.Schema;

namespace ChessScheduler.Bot.Data.Models
{
    public class Server
    {
        public ulong Id { get; set; }
        public ulong PodiumChannel { get; set; }
        public ulong ChampionRole { get; set; }
        public string TeamName { get; set; } = string.Empty;

        public void UpdateWith(Server other)
        {
            if (other.Id != Id)
                return;

            if (other.PodiumChannel != PodiumChannel)
                PodiumChannel = other.PodiumChannel;

            if (other.ChampionRole != ChampionRole)
                ChampionRole = other.ChampionRole;

            if (other.TeamName != TeamName)
                TeamName = other.TeamName;
        }

        [NotMapped]
        public bool IsSettedUp => 
            Id != default &&
            PodiumChannel != default &&
            ChampionRole != default &&
            TeamName != string.Empty;
    }
}
