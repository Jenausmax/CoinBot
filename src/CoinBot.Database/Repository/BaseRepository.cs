using CoinBot.Database.Data;
using CoinBot.Domain.Interfaces;
using CoinBot.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CoinBot.Database.Repository;

public class BaseRepository<TId, TEntity> : IRepository<TId, TEntity>
    where TEntity : class, IEntity<TId>
    where TId : struct
{
    private readonly CoinBotDbContext _context;
    private readonly Logger<BaseRepository<TId, TEntity>> _logger;
    private readonly DbSet<TEntity> _dbSet;

    public BaseRepository(CoinBotDbContext context, Logger<BaseRepository<TId, TEntity>> logger)
    {
        _context = context;
        _logger = logger;
        _dbSet = context.Set<TEntity>();
    }

    protected virtual IQueryable<TEntity> Query => _dbSet;

    public ICollection<TEntity> GetAllAsync()
    {
        return Query.AsNoTracking().ToList();
    }

    public async Task<TEntity?> FindByIdAsync(TId id, CancellationToken cancellationToken = default)
    {
        return await Query
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id.Equals(id), cancellationToken);
    }

    public async Task<bool> ExistsAsync(TEntity entity, CancellationToken cancellationToken)
    {
        return await Query.AsNoTracking().AnyAsync(x => x.Id.Equals(entity.Id), cancellationToken);
    }

    public async Task<TId> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        var entityDb = await _dbSet.AddAsync(entity, cancellationToken);

        await _context.SaveChangesAsync(cancellationToken);

        return entityDb.Entity.Id;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        var updateEntity = _dbSet.Update(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return updateEntity.Entity;
    }

    public async Task DeleteAsync(TId id, CancellationToken cancellationToken = default)
    {
        var entity = await FindByIdAsync(id, cancellationToken);

        if (entity == null)
        {
            _logger.LogError("Entity {id} not exist", id);
            throw new InvalidOperationException("Entity not exist");
        }

        _dbSet.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);
    }
}

