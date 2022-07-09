using ChessScheduler.Bot.Commands;
using ChessScheduler.Bot.DTOs;
using DSharpPlus.Entities;
using System.Globalization;

namespace ChessScheduler.Bot.Builders
{
    public class EmbedBuilder
    {
        public static DiscordEmbed FromSwissPodium(GetSwissInfoResponse tournament, SendPodiumCommand command)
        {
            return new DiscordEmbedBuilder
            {
                Title = $":trophy: **Pódio: {tournament.Name}** :trophy:",
                Description =
                    $":calendar: **Data**: {tournament.StartsAt.ToString(@"d \de MMMM \de yyyy", new CultureInfo("PT-br"))}\n" +
                    $":computer: **Link**: {command.TournamentLink}\n" +
                    $"\n" +
                    $":first_place: <@{command.First.Id}>\n" +
                    $":second_place: <@{command.Second.Id}>\n" +
                    $":third_place: <@{command.Third.Id}>",
                Color = new DiscordColor("#FFC300"),
                ImageUrl = command.ImageLink,
            };
        }

        public static DiscordEmbed AfterPodiumMessage(DiscordMessage message)
        {
            return new DiscordEmbedBuilder
            {
                Description =
                    $"Pódio enviado com sucesso!\n" +
                    $"[**Ir para a mensagem**]({message.JumpLink})",
            };
        }

        public static DiscordEmbed AfterSuccessAction()
        {
            // TODO: Add footer with info about who triggered the command

            return new DiscordEmbedBuilder
            {
                Description = $"Ação realizada com sucesso!",
            };
        }

        public static DiscordEmbed AfterFailedAction(Exception? exception = null)
        {
            // TODO: Add footer with info about who triggered the command

            var message = string.Empty;

            if(exception != null)
            {
                message = $"\nDetalhes: {exception.Message}\n{exception.StackTrace}";
            }

            return new DiscordEmbedBuilder
            {
                Description = $"Falha ao realizar ação.{message}",
            };
        }
    }
}
