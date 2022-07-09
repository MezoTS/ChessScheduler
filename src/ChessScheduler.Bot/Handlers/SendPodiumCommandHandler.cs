using ChessScheduler.Bot.Clients;
using ChessScheduler.Bot.Commands;
using ChessScheduler.Bot.DTOs;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using System.Globalization;

namespace ChessScheduler.Bot.Handlers
{
    public class SendPodiumCommandHandler
    {
        private readonly DiscordWebhookBuilder _webhook;
        private readonly ILichessClient _lichessClient;

        public SendPodiumCommandHandler(DiscordWebhookBuilder webhook, ILichessClient lichessClient)
        {
            _webhook = webhook;
            _lichessClient = lichessClient;
        }

        public async Task Handle(InteractionContext context, SendPodiumCommand command)
        {
            await context.DeferAsync();

            var tournamentId = command.Link.Split('/').Last();
            var swissInfo = await _lichessClient.GetSwissInfoAsync(tournamentId);
            var embed = BuildEmbed(swissInfo, command);

            await command.Channel.SendMessageAsync(embed);

            command.Champions.ForEach(champion =>
            {
                // TODO: Validate if role is not admin
                champion.GrantRoleAsync(command.Role);
            });

            // TODO: Respond with embed
            await context.DeleteResponseAsync();
        }

        private static DiscordEmbed BuildEmbed(GetSwissInfoResponse swiss, SendPodiumCommand command)
        {
            var embed = new DiscordEmbedBuilder
            {
                Title = $":trophy: **Pódio: {swiss.Name}** :trophy:",
                Description =
                    $":calendar: **Data**: {swiss.StartsAt.ToString(@"d \de MMMM \de yyyy", new CultureInfo("PT-br"))}\n" +
                    $":computer: **Link**: {command.Link}\n" +
                    $"\n" +
                    $":first_place: <@{command.First.Id}>\n" +
                    $":second_place: <@{command.Second.Id}>\n" +
                    $":third_place: <@{command.Third.Id}>",
                Color = new DiscordColor("#FFC300"),
                ImageUrl = "https://imgur.com/VHdG3sl.png",
            };

            return embed;
        }
    }
}
