using CoinBot.Domain.Interfaces;

namespace CoinBot.Domain.Models;

/// <summary>
/// Пользователь.
/// </summary>
public class User : IEntity<long>, IDeletable
{
    public long Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public long ChatId { get; set; }

    public bool IsDeleted { get; set; }

    public ICollection<Message>? Messages { get; set; }
}
