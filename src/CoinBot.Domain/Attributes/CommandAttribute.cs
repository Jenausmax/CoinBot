namespace CoinBot.Domain.Attributes;

public class CommandAttribute : Attribute
{
    public CommandAttribute(string command)
    {
        Command = command;
    }

    public string Command { get; }
}

