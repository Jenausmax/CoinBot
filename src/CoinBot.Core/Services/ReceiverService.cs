using AutoMapper;
using CoinBot.Core.Constants;
using CoinBot.Core.EventHadlers.Interfaces;
using CoinBot.Domain.Interfaces.Commands;
using CoinBot.Domain.Interfaces.Services;
using CoinBot.Domain.Models;
using Microsoft.Extensions.Logging;
using Polly.Timeout;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.Enums;

namespace CoinBot.Core.Services;

public class ReceiverService : IReceiverService
{
    private readonly ITelegramBotClient _client;
    private readonly IClientUpdateHandler _clientUpdateHandler;
    private readonly ITelegramExecuteCommand _executeCommand;
    private readonly IMapper _mapper;
    private readonly ILogger<ReceiverService> _logger;

    public ReceiverService(ITelegramBotClient client, IClientUpdateHandler clientUpdateHandler, ITelegramExecuteCommand executeCommand,
        IMapper mapper,
        ILogger<ReceiverService> logger)
    {
        _client = client;
        _clientUpdateHandler = clientUpdateHandler;
        _executeCommand = executeCommand;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task ReceiveAsync(CancellationToken stoppingToken)
    {
        var options = new ReceiverOptions()
        {
            AllowedUpdates = new[] { UpdateType.Message }
        };

        var stoppingReceiveSource = new CancellationTokenSource();

        _clientUpdateHandler.UpdateReceivedEvent += async (sender, update) =>
        {
            if (update.Message != null)
            {
                if (update.Message.Contact?.UserId == update.Message.Chat.Id)
                {
                    update.Message.Text = CommandKeys.Registration;
                }

                var user = _mapper.Map<User>(update.Message);

                await _executeCommand.ProcessingUpdate(new Message(){ Text = update.Message.Text, UserId = user.Id}, user, stoppingToken);
            }
        };

        // Start receiving updates
        try
        {
            await _client.ReceiveAsync(
                updateHandler: _clientUpdateHandler,
                receiverOptions: options,
                cancellationToken: stoppingReceiveSource.Token);
        }
        catch (TimeoutRejectedException)
        {
            stoppingReceiveSource.Cancel();
        }


    }
}
