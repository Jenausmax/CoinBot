using CoinBot.Domain.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Telegram.Bot;

namespace CoinBot.Core.HostedServices;

public class PollingService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<PollingService> _logger;

    private int _pollingInterval = 10;

    public PollingService(
        IServiceProvider serviceProvider,
        ILogger<PollingService> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Starting polling service");

        await DoWork(stoppingToken);
    }
    
    private async Task DoWork(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                using var scope = _serviceProvider.CreateScope();

                var botClient = scope.ServiceProvider.GetRequiredService<ITelegramBotClient>();

                _logger.LogInformation("Removing webhook");

                await botClient.DeleteWebhookAsync(cancellationToken: stoppingToken);

                var receiver = scope.ServiceProvider.GetRequiredService<IReceiverService>();

                await receiver.ReceiveAsync(stoppingToken);
                
                _logger.LogInformation($"Sleep polling service will be {_pollingInterval}s");

                await Task.Delay(TimeSpan.FromSeconds(_pollingInterval), stoppingToken);
            }
            catch (Exception ex)
            {
                _logger.LogError("Polling failed with exception: {Exception}", ex);
                await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
            }
        }
    }
}
