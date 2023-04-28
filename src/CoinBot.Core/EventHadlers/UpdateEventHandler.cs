using Telegram.Bot.Types;

namespace CoinBot.Core.EventHadlers
{
    public delegate Task UpdateEventHandlerAsync(object sender, Update e);
}
