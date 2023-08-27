using Telegram.Bot.Polling;

namespace CoinBot.Core.EventHandlers.Interfaces;

public interface IClientUpdateHandler : IUpdateHandler
{
    public event UpdateEventHandlerAsync? UpdateReceivedEvent;

    public event UpdateEventCallbackAsync? UpdateEventCallbackEvent;
}