﻿namespace CoinBot.Domain.Interfaces.Repository;

/// <summary>
/// Контракт репозитория.
/// </summary>
/// <typeparam name="TId">Тип Id</typeparam>
/// <typeparam name="TEntity">Сущность.</typeparam>
public interface IRepository<TId, TEntity> 
    where TEntity : class, IEntity<TId> 
    where TId : struct
{
    /// <summary>
    /// Метод получения коллекции нужной сущности.
    /// </summary>
    /// <returns>Коллекция <see cref="ICollection{T}"/>.</returns>
    ICollection<TEntity> GetAllAsync();

    /// <summary>
    /// Метод поиска сущности по Id.
    /// </summary>
    /// <param name="id">Id.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Сущность <see cref="TEntity"/> nullable.</returns>
    Task<TEntity?> FindByIdAsync(TId id, CancellationToken cancellationToken);

    /// <summary>
    /// Метод проверки существования сущности в коллекции.
    /// </summary>
    /// <param name="entity">Сущность.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Логическое true/false. true - сущность имеется в коллекциии false - сущности нет в коллекциии.</returns>
    Task<bool> ExistsAsync(TEntity entity, CancellationToken cancellationToken);

    /// <summary>
    /// Добавление сущности.
    /// </summary>
    /// <param name="entity">Сущность.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Id.</returns>
    Task<TId> AddAsync(TEntity entity, CancellationToken cancellationToken);

    /// <summary>
    /// Обновление сущности.
    /// </summary>
    /// <param name="entity">Сущность.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Сущность <see cref="TEntity"/>.</returns>
    Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken);

    /// <summary>
    /// Удаление сущности.
    /// </summary>
    /// <param name="id">Id.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns></returns>
    Task DeleteAsync(TId id, CancellationToken cancellationToken);
}
