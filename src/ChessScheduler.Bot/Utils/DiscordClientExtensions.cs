using ChessScheduler.Bot.Modules;
using DSharpPlus;
using DSharpPlus.SlashCommands;

namespace ChessScheduler.Bot.Utils
{
    public static class DiscordClientExtensions
    {
        public static DiscordClient AddSlashCommands(this DiscordClient client, IServiceProvider services)
        {
            var slashConfig = new SlashCommandsConfiguration { Services = services };
            var slash = client.UseSlashCommands(slashConfig);

            slash.RegisterCommands();
            slash.AddExceptionHandling();

            return client;
        }

        private static void RegisterCommands(this SlashCommandsExtension slash)
        {
            // Add new command modules here
            slash.RegisterCommands<HealthModule>();
            slash.RegisterCommands<PodiumModule>();
        }

        private static void AddExceptionHandling(this SlashCommandsExtension slash)
        {
            slash.SlashCommandErrored += async (e, args) =>
            {
                await args.Context.CreateResponseAsync(
                    $"Unable to proceed. Error: {args.Exception.Message}\n{args.Exception.StackTrace}");
            };
        }
    }
}
