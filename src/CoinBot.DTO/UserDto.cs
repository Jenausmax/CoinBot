namespace CoinBot.DTO;

public record UserDto
{
    public long Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public long ChatId { get; set; }

    public bool IsDeleted { get; set; }
}

