using DSharpPlus.Entities;

namespace ChessScheduler.Bot.Commands
{
    public class SendPodiumCommand
    {
        public SendPodiumCommand(
            string imageLink,
            DiscordUser first,
            DiscordUser second,
            DiscordUser third)
        {
            ImageLink = imageLink;
            First = (DiscordMember)first;
            Second = (DiscordMember)second;
            Third = (DiscordMember)third;
        }

        public string ImageLink { get; set; }
        public DiscordMember First { get; set; }
        public DiscordMember Second { get; set; }
        public DiscordMember Third { get; set; }

        public List<DiscordMember> Champions => new() { First, Second, Third };
    }
}
