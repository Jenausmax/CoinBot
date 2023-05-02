using CoinBot.Domain.Enums;
using CoinBot.Domain.Interfaces.Client;

namespace CoinBot.Domain.Interfaces.Facade;

public interface IBotFacade<T> where T: IClient
{
    Task SendChatActionAsync(
        long chatId,
        BotAction chatAction,
        CancellationToken cancellationToken);

    Task SendTextInlineKeyboardMessageAsync(
        long chatId,
        string text,
        CancellationToken cancellationToken);
}

