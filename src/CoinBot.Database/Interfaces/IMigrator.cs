namespace CoinBot.Database.Interfaces;

/// <summary>
/// Контракт миграции базы.
/// </summary>
public interface IMigrator
{
    Task MigrateAsync(CancellationToken cancellationToken);
}
