using ChessScheduler.Bot.Data.Clients.DTOs;
using Refit;

namespace ChessScheduler.Bot.Data.Clients
{
    [Headers("Authorization: Bearer")]
    public interface ILichessClient
    {
        [Get("/team/{team}/swiss?max=1")]
        Task<LichessSwissInfo> GetLastSwissTournamentAsync(string team);


        /// <summary>
        /// A swiss tournament with the first three players
        /// </summary>
        /// <param name="tournament">The tournament id</param>
        /// <returns>This endpoint returns a NDJSON raw string, and must be manually parsed</returns>
        [Get("/swiss/{tournament}/results?nb=3")]
        Task<string> GetSwissPodiumAsync(string tournament);
    }
}
