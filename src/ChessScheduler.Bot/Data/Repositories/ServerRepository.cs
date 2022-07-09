using ChessScheduler.Bot.Data.Models;

namespace ChessScheduler.Bot.Data.Repositories
{
    public interface IServerRepository
    {
        Task<Server> AddOptionsAsync(Server server);
    }

    public class ServerRepository : IServerRepository
    {
        private readonly SchedulerContext _context;

        public ServerRepository(SchedulerContext context)
        {
            _context = context;
        }

        public async Task<Server> AddOptionsAsync(Server server)
        {
            var serverExists = _context.Servers.Any(s => s.Id == server.Id);

            if (serverExists)
            {
                _context.Servers.Add(server);
            }
            else
            {
                _context.Servers.Update(server);
                
            }

            await _context.SaveChangesAsync();
            return server;
        }
    }
}
