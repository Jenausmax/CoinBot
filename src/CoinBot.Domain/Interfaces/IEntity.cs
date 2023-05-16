namespace CoinBot.Domain.Interfaces;

/// <summary>
/// Интерфейс представляет сущность.
/// </summary>
/// <typeparam name="TId">Тип Id.</typeparam>
public interface IEntity<TId> where TId : struct
{
    /// <summary>
    /// Id.
    /// </summary>
    TId Id { get; set; }
}

