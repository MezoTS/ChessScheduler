using ChessScheduler.Bot.Data.Clients.DTOs;
using Refit;

namespace ChessScheduler.Bot.Data.Clients
{
    [Headers("Authorization: Bearer")]
    public interface ILichessClient
    {
        [Get("/team/{team}/swiss?max=1")]
        Task<LichessSwissInfo> GetLastSwissTournamentAsync(string team);

        [Get("/swiss/{tournament}/results?nb=3")]
        Task<LichessSwissResult> GetSwissPodiumAsync(string tournament);
    }
}
