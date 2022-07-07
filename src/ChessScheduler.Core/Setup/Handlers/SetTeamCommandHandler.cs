using ChessScheduler.Core.Clients.ChessWebsite;
using ChessScheduler.Core.Setup.Commands;

namespace ChessScheduler.Core.Setup.Handlers
{
    public class SetTeamCommandHandler
    {
        private readonly IChessWebsiteClient _client;

        public SetTeamCommandHandler(IChessWebsiteClient client)
        {
            _client = client;
        }

        public async Task<SetTeamResponse> Handle(SetTeamCommand command)
        {
            bool isSuccess;

            try
            {
                var response = await _client.GetTeamAsync(command.TeamName);
                isSuccess = response != null;
            }
            catch
            {
                isSuccess = false;
            }

            return new SetTeamResponse(isSuccess);
        }
    }

    public record SetTeamResponse(bool IsSuccess);
}
