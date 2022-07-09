using Newtonsoft.Json;

namespace ChessScheduler.Bot.Data.Clients.DTOs;

public class GetSwissInfoResponse
{
    [JsonProperty("startsAt")]
    public DateTime StartsAt { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; } = string.Empty;
}
