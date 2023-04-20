namespace CoinBot.Domain.Interfaces;

public interface IBotCommand
{
    Task ExecuteAsync(IChatService chatService, long chatId, int userId, int messageId, string? commandText);
}
