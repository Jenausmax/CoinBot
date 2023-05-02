using CoinBot.Domain.Attributes;
using CoinBot.Domain.Interfaces;

namespace CoinBot.Core.Commands.Telegram;

[Command("income")]
public interface IIncomeCommand : ICommand
{
}
