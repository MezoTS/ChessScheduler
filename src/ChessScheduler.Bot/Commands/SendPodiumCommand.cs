using DSharpPlus.Entities;

namespace ChessScheduler.Bot.Commands
{
    public class SendPodiumCommand
    {
        public SendPodiumCommand(
            string link,
            DiscordChannel channel,
            DiscordUser first,
            DiscordUser second,
            DiscordUser third,
            DiscordRole role)
        {
            Link = link;
            Channel = channel;
            First = (DiscordMember)first;
            Second = (DiscordMember)second;
            Third = (DiscordMember)third;
            Role = role;
        }

        public string Link { get; set; }
        public DiscordChannel Channel { get; set; }
        public DiscordMember First { get; set; }
        public DiscordMember Second { get; set; }
        public DiscordMember Third { get; set; }
        public DiscordRole Role { get; set; }

        public List<DiscordMember> Champions => new() { First, Second, Third };
    }
}
