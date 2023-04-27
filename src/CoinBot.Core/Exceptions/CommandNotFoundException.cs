namespace CoinBot.Core.Exceptions;

public class CommandNotFoundException : Exception
{
    public CommandNotFoundException(string? message) : base(message)
    {
    }
}

