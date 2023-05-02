using CoinBot.DTO.Enums;

namespace CoinBot.DTO;

public record UserStateDto
{
    public long UserId { get; set; }

    public long ChatId { get; set; }

    public State State { get; set; }
}
