using ChessScheduler.Bot.Data.Clients.DTOs;
using DSharpPlus.Entities;
using System.Globalization;

namespace ChessScheduler.Bot.Data.Models
{
    public class SwissResult
    {
        public static SwissResult FromLichess(LichessSwissInfo info, List<DiscordMember> champions, string image)
        {
            return new SwissResult
            {
                Name = info.Name,
                StartsAt = info.StartsAt,
                Link = $"https://lichess.org/swiss/{info.Id}",
                Image = image,
                Champions = champions,
            };
        }

        public string Name { get; set; } = string.Empty;
        public DateTime StartsAt { get; set; }
        public string Link { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public List<DiscordMember> Champions { get; set; } = new();

        public string FormattedDate => StartsAt.ToString(@"d \de MMMM \de yyyy", new CultureInfo("PT-br"));

        public DiscordMember? First => Champions.ElementAtOrDefault(0);

        public DiscordMember? Second => Champions.ElementAtOrDefault(1);

        public DiscordMember? Third => Champions.ElementAtOrDefault(2);
    }
}
