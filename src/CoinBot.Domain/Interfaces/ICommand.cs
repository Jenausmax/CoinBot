namespace CoinBot.Domain.Interfaces;

/// <summary>
/// Контракт команды.
/// </summary>
public interface ICommand
{
    /// <summary>
    /// Метод обработки команды.
    /// </summary>
    /// <param name="chatId"></param>
    /// <param name="userId"></param>
    /// <param name="commandText"></param>
    /// <param name="cancellationToken">ТОкен отмены.</param>
    /// <returns></returns>
    Task<string> ExecuteAsync(long chatId, long userId, string? commandText, CancellationToken cancellationToken);
}
