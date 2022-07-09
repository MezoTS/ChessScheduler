using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;

namespace ChessScheduler.Bot.Commands
{
    public class SetupPodiumCommand
    {
        public SetupPodiumCommand(DiscordRole role, DiscordChannel channel, InteractionContext context)
        {
            Role = role;
            Channel = channel;
            Context = context;
        }

        public DiscordRole Role { get; set; }
        public DiscordChannel Channel { get; set; }
        public InteractionContext Context { get; set; }
    }
}
