namespace CoinBot.Domain.Interfaces.Migration;

/// <summary>
/// Контракт миграции базы.
/// </summary>
public interface IMigrator
{
    Task MigrateAsync(CancellationToken cancellationToken);
}
