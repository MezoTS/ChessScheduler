using ChessScheduler.Bot.Data.Models;

namespace ChessScheduler.Bot.Data.Repositories
{
    public interface IServerRepository
    {
        Task<Server> AddOptionsAsync(Server server);

        Task<Server?> GetServerAsync(ulong id);
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
            var sourceServer = _context.Servers.Find(server.Id);

            if (sourceServer == null)
            {
                _context.Servers.Add(server);
            }
            else
            {
                sourceServer.UpdateWith(server);
            }

            await _context.SaveChangesAsync();
            return server;
        }

        public async Task<Server?> GetServerAsync(ulong id)
        {
            return await _context.Servers.FindAsync(id);
        }
    }
}
