using CoinBot.Database.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CoinBot.Database.Extensions;

public static class DatabaseRegistrationExtensions
{
    public static IServiceCollection AddDbServices(this IServiceCollection services,
        string connectionString, Action<DbContextOptionsBuilder>? configureAction = null)
    {
        services.AddDbContext<CoinBotDbContext>(builder =>
        {
            builder.UseNpgsql(connectionString);
            builder.UseSnakeCaseNamingConvention();
            configureAction?.Invoke(builder);
        });

        return services;
    }
}
