using AutoMapper;
using CoinBot.Domain.Enums;
using CoinBot.Domain.Interfaces.Client;
using CoinBot.Domain.Interfaces.Facade;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;

namespace CoinBot.Core.Services.Facade;

public class TelegramBotFacade : IBotFacade<ITelegram>
{
    private readonly ITelegramBotClient _botClient;
    private readonly IMapper _mapper;

    public TelegramBotFacade(ITelegramBotClient botClient,
        IMapper mapper)
    {
        _botClient = botClient;
        _mapper = mapper;
    }

    public async Task SendChatActionAsync(long chatId, BotAction chatAction, CancellationToken cancellationToken)
    {
        await _botClient.SendChatActionAsync(
            chatId,
            (ChatAction)chatAction,
            cancellationToken);
    }

    public async Task SendTextMessageAsync(long chatId, string text, CancellationToken cancellationToken)
    {
        await _botClient.SendTextMessageAsync(
            chatId: chatId,
            text: text,
            replyMarkup: null,
            cancellationToken: cancellationToken);
    }
}
