using CoinBot.Domain.Interfaces;

namespace CoinBot.Domain.Models;

public class Message : IEntity<long>, IDeletable
{
    public long Id { get; set; }

    public string Text { get; set; } = string.Empty;

    public long UserId { get; set; }

    public bool IsDeleted { get; }

    public User User { get; set; } = null!;
}

