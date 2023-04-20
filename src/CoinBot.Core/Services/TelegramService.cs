using CoinBot.Domain.Interfaces;
using CoinBot.Domain.Models.ModelEvents;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Telegram.Bot;

namespace CoinBot.Core.Services;

public class TelegramService : IChatService
{
    private readonly TelegramBotClient _botClient;
    private readonly IConfiguration _configuration;
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<TelegramService> _logger;

    public event EventHandler<ChatMessageEventArgs>? ChatMessage;
    public event EventHandler<CallbackEventArgs>? Callback;

    public TelegramService(IConfiguration configuration, IServiceProvider serviceProvider, ILogger<TelegramService> logger)
    {
        _configuration = configuration;
        _serviceProvider = serviceProvider;
        _logger = logger;

    }

    public Task<string> BotUserName()
    {
        throw new NotImplementedException();
    }

    public Task<bool> SendMessage(long chatId, string? message, Dictionary<string, string>? buttons = null)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateMessage(long chatId, int messageId, string newText, Dictionary<string, string>? buttons = null)
    {
        throw new NotImplementedException();
    }

    public Task<string> GetChatMemberName(long chatId, int userId)
    {
        throw new NotImplementedException();
    }
}
