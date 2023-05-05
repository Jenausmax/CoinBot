using CoinBot.Domain.Interfaces;
using CoinBot.Domain.Interfaces.Repository;

namespace CoinBot.Database.Repository;

public class BaseRepository<TId, TEntity> : IRepository<TId, TEntity>
    where TEntity : IEntity<TId>
    where TId : struct
{
    public IQueryable<TEntity> Query()
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<TEntity>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> FindByIdAsync(TId id)
    {
        throw new NotImplementedException();
    }

    public Task<TId> AddAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> UpdateAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(TId id)
    {
        throw new NotImplementedException();
    }
}

