namespace CoinBot.Domain.Models.Interfaces;

/// <summary>
/// Интерфейс представляет сущность.
/// </summary>
/// <typeparam name="TId">Тип Id.</typeparam>
public interface IEntity<TId> where TId : struct
{
    TId Id { get; set; }
}

