using ChessScheduler.Core.Clients.ChessWebsite;
using ChessScheduler.Core.Setup.Commands;
using ChessScheduler.Core.Setup.Handlers;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ChessScheduler.Core.Tests.Setup.Handlers
{
    public class SetTeamCommandHandlerTest
    {
        private readonly SetTeamCommandHandler _handler;
        private readonly Mock<IChessWebsiteClient> _mockLichessClient;

        public SetTeamCommandHandlerTest()
        {
            _mockLichessClient = new Mock<IChessWebsiteClient>();
            _handler = new SetTeamCommandHandler(_mockLichessClient.Object);
        }

        [Fact]
        public async Task Handle_CallsChessWebsite()
        {
            // Arrange
            var team = "test";
            var command = new SetTeamCommand { TeamName = team };

            // Act
            await _handler.Handle(command);

            // Assert
            _mockLichessClient.Verify(l => l.GetTeamAsync(team), Times.Once);
        }

        [Fact]
        public async Task Handle_ClientThrowsException_ResponseIsNotSuccess()
        {
            // Arrange
            var team = "test";
            var command = new SetTeamCommand { TeamName = team };

            _mockLichessClient
                .Setup(c => c.GetTeamAsync(team))
                .ThrowsAsync(new Exception());

            // Act
            var response = await _handler.Handle(command);

            // Assert
            Assert.False(response.IsSuccess);
        }
    }
}
