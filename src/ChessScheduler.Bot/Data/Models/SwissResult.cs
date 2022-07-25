using ChessScheduler.Bot.Data.Clients.DTOs;
using System.Globalization;

namespace ChessScheduler.Bot.Data.Models
{
    public class SwissResult
    {
        public static SwissResult FromLichess(LichessSwissInfo info, LichessSwissResult result, string? image = null)
        {
            return new SwissResult
            {
                Name = info.Name,
                StartsAt = info.StartsAt,
                Link = $"https://lichess.org/swiss/{info.Id}",
                Image = image ?? string.Empty,
                First = result.First?.Username ?? string.Empty,
                Second = result.Second?.Username ?? string.Empty,
                Third = result.Third?.Username ?? string.Empty,
            };
        }

        public string Name { get; set; } = string.Empty;
        public DateTime StartsAt { get; set; }
        public string Link { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public string First { get; set; } = string.Empty;
        public string Second { get; set; } = string.Empty;
        public string Third { get; set; } = string.Empty;

        public string FormattedDate => StartsAt.ToString(@"d \de MMMM \de yyyy", new CultureInfo("PT-br"));
    }
}
