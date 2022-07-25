using ChessScheduler.Bot.Data.Models;
using DSharpPlus.Entities;

namespace ChessScheduler.Bot.Builders
{
    public class EmbedBuilder
    {
        public static DiscordEmbed FromSwissResult(SwissResult swissResult)
        {
            return new DiscordEmbedBuilder
            {
                Title = $":trophy: **Pódio: {swissResult.Name}** :trophy:",
                Description =
                    $":calendar: **Data**: {swissResult.FormattedDate}\n" +
                    $":computer: **Link**: {swissResult.Link}\n" +
                    $"\n" +
                    $":first_place: <@{swissResult.First.Id}>\n" +
                    $":second_place: <@{swissResult.Second.Id}>\n" +
                    $":third_place: <@{swissResult.Third.Id}>",
                Color = new DiscordColor("#FFC300"),
                ImageUrl = swissResult.Image,
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

            if (exception != null)
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
