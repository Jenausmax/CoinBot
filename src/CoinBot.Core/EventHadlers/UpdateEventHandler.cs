using Telegram.Bot.Types;

namespace CoinBot.Core.EventHadlers
{
    internal delegate Task UpdateEventHandlerAsync(object sender, Update e);
}
