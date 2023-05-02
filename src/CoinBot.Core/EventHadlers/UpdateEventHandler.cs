using Telegram.Bot.Types;

namespace CoinBot.Core.EventHadlers
{
    public delegate Task UpdateEventHandlerAsync(object sender, Update e);

    public delegate Task UpdateEventCallbackAsync(Update e);
}
