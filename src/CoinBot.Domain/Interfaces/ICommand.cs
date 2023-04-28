namespace CoinBot.Domain.Interfaces;

public interface ICommand
{
    Task<string> ExecuteAsync(long chatId, long userId, string? commandText, CancellationToken cancellationToken);
}
