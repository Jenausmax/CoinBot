﻿using CoinBot.Core.EventHadlers.Interfaces;
using Microsoft.Extensions.Logging;
using Polly.Timeout;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;

namespace CoinBot.Core.EventHadlers;

public class ClientUpdateHandler : IClientUpdateHandler
{
    private readonly ILogger<ClientUpdateHandler> _logger;
    public event UpdateEventHandlerAsync? UpdateReceivedEvent;

    public ClientUpdateHandler(ILogger<ClientUpdateHandler> logger)
    {
        _logger = logger;
    }

    public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        if (UpdateReceivedEvent is not null)
        {
            await UpdateReceivedEvent(this, update);
        }
    }

    public async Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {
        string errorMessage;

        if (exception is ApiRequestException apiRequestException)
        {
            errorMessage = $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}";
        }
        else if (exception is RequestException requestException)
        {
            if (requestException.InnerException is TimeoutRejectedException timeoutRejectedException)
            {
                throw timeoutRejectedException;
            }
            else
            {
                errorMessage = exception.ToString();
            }
        }
        else
        {
            errorMessage = exception.ToString();
        }

        _logger.LogError("HandleError: {ErrorMessage}", errorMessage);

        // Cooldown in case of network connection error
        if (exception is RequestException)
        {
            await Task.Delay(TimeSpan.FromSeconds(2), cancellationToken);
        }
    }
}