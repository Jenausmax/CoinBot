using CoinBot.Domain.Interfaces.Migration;

namespace CoinBot.Migration.HostedServices;

/// <summary>
/// Класс фоновой задачи по инициализации миграции.
/// </summary>
internal class MigrateHostedService : IHostedService
{
    private readonly IMigrator _migrator;

    public MigrateHostedService(IMigrator migrator)
    {
        _migrator = migrator ?? throw new ArgumentNullException(nameof(migrator));
    }

    public async Task StartAsync(CancellationToken cancellationToken = default)
    {
        await _migrator.MigrateAsync(cancellationToken);
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}

