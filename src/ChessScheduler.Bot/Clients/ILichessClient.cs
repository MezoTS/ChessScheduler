using ChessScheduler.Bot.DTOs;
using Refit;

namespace ChessScheduler.Bot.Clients
{
    [Headers("Authorization: Bearer")]
    public interface ILichessClient
    {
        [Get("/swiss/{id}")]
        Task<GetSwissInfoResponse> GetSwissInfoAsync(string id);
    }
}
