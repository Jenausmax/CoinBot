using System.Reflection;
using CoinBot.Core.Exceptions;
using CoinBot.Domain.Attributes;
using CoinBot.Domain.Interfaces;

namespace CoinBot.Core.Commands.Extensions;

public static class CommandExtensions
{
    public static Type GetTypeCommand(this string textCommand)
    {
        var result = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(t =>
                typeof(ICommand).IsAssignableFrom(t) &&
                (t.GetCustomAttribute(typeof(CommandAttribute)) as CommandAttribute)?.Command == textCommand)
            .FirstOrDefault();

        if (result is null)
        {
            throw new CommandNotFoundException($"Command {textCommand} not found");
        }

        return result;
    }
}
