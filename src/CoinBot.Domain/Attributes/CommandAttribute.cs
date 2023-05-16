namespace CoinBot.Domain.Attributes;

/// <summary>
/// Атрибут команды.
/// </summary>
public class CommandAttribute : Attribute
{
    public CommandAttribute(string command)
    {
        Command = command;
    }

    public string Command { get; }
}

