using ChessScheduler.Bot.Data.Models;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;

namespace ChessScheduler.Bot.Commands
{
    public class SetupCommand
    {
        public SetupCommand(
            string teamName,
            DiscordRole championRole,
            DiscordChannel podiumChannel,
            InteractionContext context)
        {
            TeamName = teamName;
            ChampionRole = championRole;
            PodiumChannel = podiumChannel;
            Context = context;
        }

        public string TeamName { get; set; } = string.Empty;
        public DiscordRole ChampionRole { get; set; }
        public DiscordChannel PodiumChannel { get; set; }
        public InteractionContext Context { get; set; }

        public Server Server => new()
        {
            Id = Context.Guild.Id,
            PodiumChannel = PodiumChannel.Id,
            ChampionRole = ChampionRole.Id,
            TeamName = TeamName,
        };
    }
}
