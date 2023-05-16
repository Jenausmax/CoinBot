using CoinBot.Domain.Interfaces.Client;
using CoinBot.Domain.Interfaces.Facade;
using CoinBot.Domain.Models;

namespace CoinBot.Domain.Interfaces;

/// <summary>
/// Базовый контракт обработчика команд.
/// </summary>
/// <typeparam name="TBotFacade"></typeparam>
/// <typeparam name="TClient"></typeparam>
public interface IExecuteCommand<TBotFacade, TClient>
    where TClient : IClient
    where TBotFacade : IBotFacade<TClient>
{
    Task ProcessingUpdate(
        Message? testCommand,
        User user,
        CancellationToken cancellationToken);
}
