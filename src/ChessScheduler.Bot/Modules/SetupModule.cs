using DSharpPlus.SlashCommands;

namespace ChessScheduler.Bot.Modules
{
    [SlashCommandGroup("setup", "Setup commands")]
    public class SetupModule : ApplicationCommandModule
    {
        [SlashCommand("team", "Sets the server Lichess team")]
        public async Task SetupTeamAsync(
            InteractionContext context,
            [Option("name", "Lichess team name")] string name)
        {
            var message = $"Setting team {name} for server {context.Guild.Id}";
            await context.CreateResponseAsync(message);
        }
    }
}
