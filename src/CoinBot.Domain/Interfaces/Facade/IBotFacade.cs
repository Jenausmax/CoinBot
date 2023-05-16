using CoinBot.Domain.Enums;
using CoinBot.Domain.Interfaces.Client;

namespace CoinBot.Domain.Interfaces.Facade;

/// <summary>
/// Контракт "фасада" библиотеки <see cref="ITelegramBotClient"/>
/// </summary>
/// <typeparam name="T"></typeparam>
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

