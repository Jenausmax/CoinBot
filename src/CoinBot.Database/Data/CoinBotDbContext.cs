using Microsoft.EntityFrameworkCore;

namespace CoinBot.Database.Data;

internal class CoinBotDbContext : DbContext
{
    public CoinBotDbContext(DbContextOptions options) : base(options)
    {
        
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
