using DSharpPlus;

namespace ChessScheduler.Bot.Utils
{
    public class ConfigManager
    {
        public const string LichessApiBaseUrl = "https://lichess.org/api";

        private static string BotToken =>
            Environment.GetEnvironmentVariable(
                "CHESS_SCHEDULER",
                EnvironmentVariableTarget.Machine) ??
            throw new ArgumentException("Missing bot token");

        public static string LichessToken =>
            Environment.GetEnvironmentVariable(
                "LICHESS_TOKEN",
                EnvironmentVariableTarget.Machine) ??
            throw new ArgumentException("Missing Lichess token");

        public static DiscordConfiguration BotConfig => new()
        {
            Token = BotToken,
            TokenType = TokenType.Bot,
            Intents = DiscordIntents.All,
        };
    }
}
