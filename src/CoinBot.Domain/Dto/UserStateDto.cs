using CoinBot.Domain.Enums;

namespace CoinBot.Domain.Dto;

public record UserStateDto
{
    public long UserId { get; set; }

    public long ChatId { get; set; }

    public State State { get; set; }
}
