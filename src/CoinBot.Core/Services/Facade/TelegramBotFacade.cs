using CoinBot.Domain.Enums;
using CoinBot.Domain.Interfaces.Client;
using CoinBot.Domain.Interfaces.Facade;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace CoinBot.Core.Services.Facade;

public class TelegramBotFacade : IBotFacade<ITelegram>
{
    private readonly ITelegramBotClient _botClient;

    private readonly IReplyMarkup _replyMarkup = new InlineKeyboardMarkup(new List<InlineKeyboardButton>()
    {
        InlineKeyboardButton.WithCallbackData("Доход", "income"),
        InlineKeyboardButton.WithCallbackData("Расход", "сonsumption")
    });

    public TelegramBotFacade(ITelegramBotClient botClient)
    {
        _botClient = botClient;
    }

    public async Task SendChatActionAsync(long chatId, BotAction chatAction, CancellationToken cancellationToken)
    {
        await _botClient.SendChatActionAsync(
            chatId,
            (ChatAction)chatAction,
            cancellationToken);
    }

    public async Task SendTextInlineKeyboardMessageAsync(long chatId, string text, CancellationToken cancellationToken)
    {
        await _botClient.SendTextMessageAsync(
            chatId: chatId,
            text: text,
            replyMarkup: _replyMarkup,
            cancellationToken: cancellationToken);
    }
}
