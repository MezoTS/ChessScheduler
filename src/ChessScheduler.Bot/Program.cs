using ChessScheduler.Bot.Utils;
using DSharpPlus;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection()
    .AddServices()
    .BuildServiceProvider();

var client = new DiscordClient(ConfigManager.BotConfig)
    .AddSlashCommands(services);

await client.ConnectAsync();
await Task.Delay(-1);
