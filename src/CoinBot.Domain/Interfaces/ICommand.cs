namespace CoinBot.Domain.Interfaces;

public interface ICommand
{
    Task<string> ExecuteAsync(long chatId, int userId, int messageId, string? commandText);
}
