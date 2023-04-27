namespace CoinBot.DTO;

public record MessageDto
{
    public long Id { get; init; }

    public string Text { get; init; } = string.Empty;

    public long UserId { get; init; }

    public bool IsDeleted { get; init; }
}

