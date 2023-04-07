using CoinBot.Database.Data.Configurations;
using CoinBot.Database.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CoinBot.Database.Data;

public class CoinBotDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public CoinBotDbContext(DbContextOptions options) : base(options)
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());

        base.OnModelCreating(modelBuilder);
    }

    //// метод нужен для работы с интерфейсом IUpdatableEntity...для проставления даты изменения
    ////public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    ////{
    ////    foreach (Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<IUpdatableEntity> entry in ChangeTracker.Entries<IUpdatableEntity>())
    ////    {
    ////        if (entry.Entity is IUpdatableEntity updatableEntity &&
    ////            entry.State == EntityState.Modified)
    ////        {
    ////            updatableEntity.LastUpdatedDate = DateTime.UtcNow;

    ////            var sessionCache = _sessionProvider.SessionData;
    ////            var user = $"{sessionCache.FirstName} {sessionCache.LastName}";

    ////            if (string.IsNullOrEmpty(user))
    ////            {
    ////                throw new InvalidOperationException("The session data is not initialized");
    ////            }

    ////            updatableEntity.LastUpdatedBy = user;
    ////        }
    ////    }

    ////    return await base.SaveChangesAsync(cancellationToken);
    ////}
}
