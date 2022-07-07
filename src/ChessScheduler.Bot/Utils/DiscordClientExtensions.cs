using ChessScheduler.Bot.Modules;
using DSharpPlus;
using DSharpPlus.SlashCommands;
using DSharpPlus.SlashCommands.EventArgs;

namespace ChessScheduler.Bot.Utils
{
    public static class DiscordClientExtensions
    {
        public static DiscordClient Configure(this DiscordClient client)
        {
            var slash = client.UseSlashCommands();

            slash.RegisterCommands<HealthModule>();
            slash.RegisterCommands<SetupModule>();

            slash.SlashCommandErrored += HandleSlashCommandErrorAsync;

            return client;
        }

        private static async Task HandleSlashCommandErrorAsync(
            SlashCommandsExtension extension,
            SlashCommandErrorEventArgs args)
        {
            await args.Context.CreateResponseAsync(
                $"Unable to proceed. Error: {args.Exception.Message}");
        }
    }
}
