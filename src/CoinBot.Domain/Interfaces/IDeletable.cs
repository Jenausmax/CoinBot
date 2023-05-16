namespace CoinBot.Domain.Interfaces;

/// <summary>
/// Контракт софт-удаления сущности.
/// </summary>
public interface IDeletable
{
    /// <summary>
    /// Свойство удаления сущности. true - сущность удалена, false - сущность не удалена.
    /// </summary>
    bool IsDeleted { get; }
}
