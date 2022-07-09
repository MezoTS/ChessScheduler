using DSharpPlus;
using DSharpPlus.SlashCommands;

namespace ChessScheduler.Bot.Utils
{
    public static class InteractionContextExtensions
    {
        public static async Task StartResponseAsync(this InteractionContext context)
        {
            var responseType = InteractionResponseType.DeferredChannelMessageWithSource;
            await context.CreateResponseAsync(responseType);
        }
    }
}
