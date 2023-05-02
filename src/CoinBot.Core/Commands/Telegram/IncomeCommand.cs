namespace CoinBot.Core.Commands.Telegram;

public class IncomeCommand : IIncomeCommand
{
    public async Task<string> ExecuteAsync(long chatId, long userId, string? commandText, CancellationToken cancellationToken)
    {
        return "Доход";
    }
}
