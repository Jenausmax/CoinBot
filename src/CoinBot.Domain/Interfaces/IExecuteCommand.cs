using CoinBot.Domain.Interfaces.Client;
using CoinBot.Domain.Interfaces.Facade;
using CoinBot.Domain.Models;

namespace CoinBot.Domain.Interfaces;

public interface IExecuteCommand<TBotFacade, TClient>
    where TClient : IClient
    where TBotFacade : IBotFacade<TClient>
{
    Task ProcessingUpdate(
        string? testCommand,
        User user,
        CancellationToken cancellationToken);
}
