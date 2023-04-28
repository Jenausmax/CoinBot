using CoinBot.Domain.Interfaces.Client;
using CoinBot.Domain.Interfaces.Facade;

namespace CoinBot.Domain.Interfaces.Commands;

public interface ITelegramExecuteCommand : IExecuteCommand<IBotFacade<ITelegram>, ITelegram>
{
}

