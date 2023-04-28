using CoinBot.Core.Constants;
using CoinBot.Core.Exceptions;
using CoinBot.Domain.Attributes;
using CoinBot.Domain.Enums;
using CoinBot.Domain.Interfaces;
using CoinBot.Domain.Interfaces.Client;
using CoinBot.Domain.Interfaces.Facade;
using CoinBot.Domain.Models;
using Microsoft.Extensions.Logging;

namespace CoinBot.Core.Commands;

public abstract class BaseExecuteCommand<TBotFacade, TClient> : IExecuteCommand<TBotFacade, TClient>
    where TClient : IClient
    where TBotFacade : IBotFacade<TClient>
{
    private readonly TBotFacade _bot;
    private readonly IInvoker _invoker;
    private readonly ILogger<BaseExecuteCommand<TBotFacade, TClient>> _logger;

    public BaseExecuteCommand(
        TBotFacade bot,
        IInvoker invoker,
        ILogger<BaseExecuteCommand<TBotFacade, TClient>> logger)
    {
        _bot = bot;
        _invoker = invoker;
        _logger = logger;
    }

    public async Task ProcessingUpdate(Message? testCommand, User user, CancellationToken cancellationToken)
    {
        await _bot.SendChatActionAsync(user.ChatId, BotAction.Typing, cancellationToken);

        string? msg;
        try
        {
            _invoker.SetCommand<CommandAttribute>(testCommand?.Text);

            if(testCommand == null) { return; }

            msg = await _invoker.ExecuteCommand(user, testCommand, cancellationToken);
        }
        catch (CommandNotFoundException ex)
        {
            msg = MessageKeys.UNKNOWN_COMMAND;
            _logger.LogError(ex.Message);
        }

        await _bot.SendTextMessageAsync(user.ChatId, msg, cancellationToken);
    }
}
