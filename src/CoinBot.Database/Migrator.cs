using CoinBot.Database.Data;
using CoinBot.Database.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CoinBot.Database;

internal class Migrator : IMigrator
{
    private readonly IServiceProvider _serviceProvider;

    public Migrator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync(CancellationToken cancellationToken)
    {
        using var scope = _serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<CoinBotDbContext>();

        await dbContext.Database.MigrateAsync(cancellationToken);
    }
}

