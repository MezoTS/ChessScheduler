using Newtonsoft.Json;

namespace ChessScheduler.Bot.Data.Clients.DTOs
{
    public class LichessSwissResult
    {
        public List<LichessSwissPlayer> Players { get; set; } = new();

        [JsonIgnore]
        public LichessSwissPlayer? First => Players.ElementAtOrDefault(0);

        [JsonIgnore]
        public LichessSwissPlayer? Second => Players.ElementAtOrDefault(1);

        [JsonIgnore]
        public LichessSwissPlayer? Third => Players.ElementAtOrDefault(2);
    }

    public class LichessSwissPlayer
    {
        [JsonProperty("rank")]
        public int Rank { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; } = string.Empty;
    }
}
