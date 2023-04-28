using CoinBot.Core.Commands;
using CoinBot.Core.EventHadlers;
using CoinBot.Core.EventHadlers.Interfaces;
using CoinBot.Core.HostedServices;
using CoinBot.Core.Services;
using CoinBot.Core.Services.Facade;
using CoinBot.Domain.Interfaces;
using CoinBot.Domain.Interfaces.Client;
using CoinBot.Domain.Interfaces.Commands;
using CoinBot.Domain.Interfaces.Facade;
using CoinBot.Domain.Interfaces.Services;
using CoinBot.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Telegram.Bot;

namespace CoinBot.Core;

public static class BuilderExtensions
{
    public static void ConfigureTelegramBotClient(
        this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        var botConfig = configuration.GetSection("BotClientSettings");
        var botConfigObj = botConfig.Get<BotClientSettings>();
        var telegramToken = Environment.GetEnvironmentVariable("TELEGRAM_TOKEN");

        if (!string.IsNullOrEmpty(telegramToken))
        {
            if (botConfigObj != null)
            {
                botConfigObj.Token = telegramToken;
            }
        }

        if (botConfigObj != null)
        {
            serviceCollection.AddCoreServices(botConfigObj);
        }

        serviceCollection.ConfigureTelegramBotClient();
        serviceCollection.AddCommands();
    }

    private static void ConfigureTelegramBotClient(
        this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IClientUpdateHandler, ClientUpdateHandler>();
        serviceCollection.AddScoped<ITelegramExecuteCommand, TelegramExecuteCommand>();
        serviceCollection.AddScoped<IReceiverService, ReceiverService>();
        serviceCollection.AddScoped<IBotFacade<ITelegram>, TelegramBotFacade>();

        serviceCollection.AddHostedService<PollingService>();
    }

    private static void AddCoreServices(this IServiceCollection serviceCollection,
        BotClientSettings conf)
    {
        serviceCollection.AddSingleton(conf);
        serviceCollection
            .AddHttpClient("telegram_bot_client")
            .AddPolicyHandler(Policy.TimeoutAsync<HttpResponseMessage>(10))
            .AddTypedClient<ITelegramBotClient>((httpClient, sp) =>
            {
                var options = new TelegramBotClientOptions(conf.Token);

                return new TelegramBotClient(options, httpClient);
            });
    }

    private static void AddCommands(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IInvoker, Invoker>();
    }
}

