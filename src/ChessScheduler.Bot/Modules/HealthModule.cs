using DSharpPlus.SlashCommands;

namespace ChessScheduler.Bot.Modules
{
    public class HealthModule : ApplicationCommandModule
    {
        [SlashCommand("ping", "Responds with pong.")]
        public async Task PingAsync(InteractionContext context)
        {
            await context.CreateResponseAsync("Pong!");
        }
    }
}
