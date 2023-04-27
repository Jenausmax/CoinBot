using CoinBot.Domain.Attributes;
using CoinBot.Domain.Models;

namespace CoinBot.Domain.Interfaces;

public interface IInvoker
{
    void SetCommand<T>(string? textCommand)
        where T : CommandAttribute;

    Task<string> ExecuteCommand(User userViewModels, CancellationToken cancellationToken);
}
