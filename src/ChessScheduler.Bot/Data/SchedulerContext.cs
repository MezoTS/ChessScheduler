using ChessScheduler.Bot.Data.Models;
using ChessScheduler.Bot.Utils;
using Microsoft.EntityFrameworkCore;

namespace ChessScheduler.Bot.Data
{
    public class SchedulerContext : DbContext
    {
        public DbSet<Server> Servers => Set<Server>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Server>()
                .HasKey(s => s.Id);

            modelBuilder.Entity<Server>()
                .Property(s => s.TeamName)
                .HasColumnType("varchar(50)");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(ConfigManager.DbConnection);
        }
    }
}
