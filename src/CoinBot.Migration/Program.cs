using CoinBot.Database.Extensions;
using CoinBot.Migration.HostedServices;
using Serilog;
using Serilog.Events;

namespace CoinBot.Migration
{
    public class Program
    {
        private const string SettingsName = "appsettings.json";

        private static readonly CancellationTokenSource _canToken = new CancellationTokenSource();

        public static void Main(string[] args)
        {
            MainAsync(args).GetAwaiter().GetResult();
        }

        private static async Task MainAsync(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateBootstrapLogger();

            var builder = Host.CreateDefaultBuilder()
                    .ConfigureHostConfiguration(configHost =>
                    {
                        configHost.SetBasePath(Directory.GetCurrentDirectory());
                        configHost.AddJsonFile(SettingsName);
                        configHost.AddCommandLine(args);
                        configHost.AddEnvironmentVariables();
                    })
                    .ConfigureServices((hostContext, services) =>
                    {
                        hostContext.HostingEnvironment.EnvironmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")!;
                        var connectionString = hostContext.Configuration.GetConnectionString("ConnectionDb");
                        if (Environment.GetEnvironmentVariable("SQL_HOST") is not null &&
                            Environment.GetEnvironmentVariable("SQL_PORT") is not null &&
                            Environment.GetEnvironmentVariable("SQL_DATABASE") is not null &&
                            Environment.GetEnvironmentVariable("SQL_USER") is not null &&
                            Environment.GetEnvironmentVariable("SQL_PASSWORD") is not null)
                        {
                            connectionString = $"Host={Environment.GetEnvironmentVariable("SQL_HOST")};" +
                                               $"Port={Environment.GetEnvironmentVariable("SQL_PORT")};" +
                                               $"Database={Environment.GetEnvironmentVariable("SQL_DATABASE")};" +
                                               $"Username={Environment.GetEnvironmentVariable("SQL_USER")};" +
                                               $"Password={Environment.GetEnvironmentVariable("SQL_PASSWORD")}";
                        }

                        Console.WriteLine(connectionString);

                        if (connectionString != null)
                        {
                            services.AddDbServices(connectionString);
                        }

                        services.AddScoped<MigrateHostedService>();
                    })
                    .UseConsoleLifetime()
                    .UseSerilog((context, services, configuration) => configuration
                        .ReadFrom.Configuration(context.Configuration)
                        .ReadFrom.Services(services)
                        .Enrich.FromLogContext()
                        .WriteTo.Console());

            var host = builder.Build();
            using var serviceScope = host.Services.CreateScope();

            ILogger<Program>? logger = serviceScope.ServiceProvider.GetService<ILogger<Program>>();
            logger?.LogDebug("init migration");
            try
            {
                IServiceProvider services = serviceScope.ServiceProvider;

                logger?.LogInformation("start migration");
                await services.GetRequiredService<MigrateHostedService>().StartAsync(_canToken.Token);
                logger?.LogInformation("exit migration");
            }
            catch (Exception ex)
            {
                logger?.LogError(ex, "Unknown error occured");
            }
        }
    }
}