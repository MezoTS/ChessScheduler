namespace ChessScheduler.Core.Clients.ChessWebsite
{
    public interface IChessWebsiteClient
    {
        Task<GetTeamResponse?> GetTeamAsync(string name);
    }

    public class GetTeamResponse
    { }
}
