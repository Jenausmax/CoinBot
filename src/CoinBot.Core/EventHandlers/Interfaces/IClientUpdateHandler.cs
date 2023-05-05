using CoinBot.Core.EventHandlers;
using Telegram.Bot.Polling;

namespace CoinBot.Core.EventHadlers.Interfaces;

public interface IClientUpdateHandler : IUpdateHandler
{
    public event UpdateEventHandlerAsync? UpdateReceivedEvent;

    public event UpdateEventCallbackAsync? UpdateEventCallbackEvent;
}