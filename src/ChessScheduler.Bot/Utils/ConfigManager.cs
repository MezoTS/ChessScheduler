using DSharpPlus;

namespace ChessScheduler.Bot.Utils
{
    public class ConfigManager
    {
        private static string? BotToken =>
            Environment.GetEnvironmentVariable(
                "CHESS_SCHEDULER",
                EnvironmentVariableTarget.Machine);

        public static DiscordConfiguration BotConfig =>
            new DiscordConfiguration
            {
                Token = BotToken,
                TokenType = TokenType.Bot,
                Intents = DiscordIntents.All,
            };
    }
}
