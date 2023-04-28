using CoinBot.Domain.Interfaces;
using CoinBot.Domain.Interfaces.Client;
using CoinBot.Domain.Interfaces.Commands;
using CoinBot.Domain.Interfaces.Facade;
using Microsoft.Extensions.Logging;

namespace CoinBot.Core.Commands;

internal class TelegramExecuteCommand : BaseExecuteCommand<IBotFacade<ITelegram>, ITelegram>, ITelegramExecuteCommand
{
    public TelegramExecuteCommand(IBotFacade<ITelegram> bot, IInvoker invoker, ILogger<BaseExecuteCommand<IBotFacade<ITelegram>, ITelegram>> logger) : base(bot, invoker, logger)
    {
    }
}

