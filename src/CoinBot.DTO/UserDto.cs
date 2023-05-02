﻿namespace CoinBot.DTO;

public record UserDto
{
    public string Name { get; init; } = string.Empty;

    public long ChatId { get; init; }

    public bool IsDeleted { get; init; }
}

