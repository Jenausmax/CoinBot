using CoinBot.Database.Extensions;
using Serilog;

namespace CoinBot.Api.Extensions;

/// <summary>
/// Расширение регистрации сервисов.
/// </summary>
public static class ExtensionsDependentServices
{
    /// <summary>
    /// Регистрация сервисов.
    /// </summary>
    /// <param name="builder"><see cref="WebApplicationBuilder"/></param>
    /// <returns></returns>
    public static WebApplicationBuilder RegisterServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        builder.Services.RegisterDataLayer(builder.Configuration);

        return builder;
    }

    private static void RegisterDataLayer(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("ConnectionDb");

        if (Environment.GetEnvironmentVariable("SQL_HOST") is not null
            && Environment.GetEnvironmentVariable("SQL_PORT") is not null
            && Environment.GetEnvironmentVariable("SQL_DATABASE") is not null
            && Environment.GetEnvironmentVariable("SQL_USER") is not null
            && Environment.GetEnvironmentVariable("SQL_PASSWORD") is not null)
        {
            Log.Logger.Information("EnvironmentVariable is found");
            connectionString = string.Format("Host={0};Port={1};Database={2};Username={3};Password={4}",
                Environment.GetEnvironmentVariable("SQL_HOST"),
                Environment.GetEnvironmentVariable("SQL_PORT"),
                Environment.GetEnvironmentVariable("SQL_DATABASE"),
                Environment.GetEnvironmentVariable("SQL_USER"),
                Environment.GetEnvironmentVariable("SQL_PASSWORD"));
        }

        if (connectionString != null)
        {
            services.AddDbServices(connectionString);

            Console.WriteLine(connectionString);
        }
        else
        {
            Log.Logger.Error($"Connection string is null");
            throw new ArgumentNullException("ConnectionString is null");
        }
    }
}