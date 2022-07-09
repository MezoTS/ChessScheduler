using ChessScheduler.Bot.DTOs;
using DSharpPlus.Entities;

namespace ChessScheduler.Bot.Utils
{
    public static class DiscordEmbedExtensions
    {
        public static DiscordEmbed ToDiscordEmbed(this GetSwissInfoResponse swissTournament)
        {
            var embed = new DiscordEmbedBuilder
            {
                Title = swissTournament.Name,
                Description = swissTournament.StartsAt.ToShortDateString(),
            };

            return embed;
        }
    }
}
