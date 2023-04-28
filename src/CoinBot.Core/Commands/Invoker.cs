using CoinBot.Core.Commands.Extensions;
using CoinBot.Domain.Attributes;
using CoinBot.Domain.Interfaces;
using CoinBot.Domain.Models;
using Microsoft.Extensions.DependencyInjection;

namespace CoinBot.Core.Commands;

public class Invoker : IInvoker
{
    private static ICommand? _command;
    private readonly IServiceProvider _serviceProvider;

    public Invoker(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public void SetCommand<T>(string? textCommand)
        where T : CommandAttribute
    {
        if (string.IsNullOrWhiteSpace(textCommand))
        {
            throw new ArgumentException("text command empty");
        }

        var commandType = textCommand.GetTypeCommand();

        _command = (ICommand)_serviceProvider.GetRequiredService(commandType);
    }

    public async Task<string> ExecuteCommand(User user, Message message, CancellationToken cancellationToken)
    {
        if (_command is null)
        {
            throw new Exception("first set a command");
        }

        return await _command.ExecuteAsync(user.ChatId, user.Id, message.Text,  cancellationToken);
    }
}
