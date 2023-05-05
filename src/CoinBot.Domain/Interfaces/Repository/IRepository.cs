namespace CoinBot.Domain.Interfaces.Repository;

public interface IRepository<TId, TEntity> 
    where TEntity : IEntity<TId> 
    where TId : struct
{
    IQueryable<TEntity> Query();

    Task<ICollection<TEntity>> GetAllAsync();

    Task<TEntity> FindByIdAsync(TId id);

    Task<TId> AddAsync(TEntity entity);

    Task<TEntity> UpdateAsync(TEntity entity);

    Task DeleteAsync(TId id);
}
