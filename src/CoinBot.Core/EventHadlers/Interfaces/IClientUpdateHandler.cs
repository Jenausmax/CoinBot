using Telegram.Bot.Polling;

namespace CoinBot.Core.EventHadlers.Interfaces;

internal interface IClientUpdateHandler : IUpdateHandler
{
    event UpdateEventHandlerAsync? UpdateReceivedEvent;
}