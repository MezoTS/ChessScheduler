using ChessScheduler.Bot.Clients;
using ChessScheduler.Bot.Handlers;
using DSharpPlus.Entities;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using System.Net.Http.Headers;

namespace ChessScheduler.Bot.Utils
{
    public static class ServiceProviderExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services
                .AddRefitClients()
                .AddCommandHandlers()
                .AddTransient<DiscordWebhookBuilder>();

            return services;
        }

        private static IServiceCollection AddCommandHandlers(this IServiceCollection services)
        {
            // Add new command-handlers here
            services.AddTransient<SendPodiumCommandHandler>();

            return services;
        }

        private static IServiceCollection AddRefitClients(this IServiceCollection services)
        {
            // Add new refit clients here
            services.AddRefitClient<ILichessClient>()
                .ConfigureHttpClient(c =>
                {
                    var baseUri = new Uri(ConfigManager.LichessApiBaseUrl);
                    var authHeader = new AuthenticationHeaderValue("Bearer", ConfigManager.LichessToken);

                    c.BaseAddress = baseUri;
                    c.DefaultRequestHeaders.Authorization = authHeader;
                });

            return services;
        }
    }
}
