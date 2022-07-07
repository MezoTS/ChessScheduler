using ChessScheduler.Bot.Utils;
using DSharpPlus;

var client = new DiscordClient(ConfigManager.BotConfig);
client.Configure();

await client.ConnectAsync();
await Task.Delay(-1);
