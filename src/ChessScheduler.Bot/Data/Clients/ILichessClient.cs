using ChessScheduler.Bot.Data.Clients.DTOs;
using Refit;

namespace ChessScheduler.Bot.Data.Clients
{
    [Headers("Authorization: Bearer")]
    public interface ILichessClient
    {
        [Get("/swiss/{id}")]
        Task<GetSwissInfoResponse> GetSwissInfoAsync(string id);
    }
}
