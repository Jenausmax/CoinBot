namespace CoinBot.Domain.Interfaces.Services;
public interface IReceiverService
{
    Task ReceiveAsync(CancellationToken stoppingToken);
}
