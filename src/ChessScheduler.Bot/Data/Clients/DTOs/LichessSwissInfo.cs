using Newtonsoft.Json;

namespace ChessScheduler.Bot.Data.Clients.DTOs
{
    public class LichessSwissInfo
    {
        [JsonProperty("id")]
        public string Id { get; set; } = string.Empty;

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("startsAt")]
        public DateTime StartsAt { get; set; }
    }
}
