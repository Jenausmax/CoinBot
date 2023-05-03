using CoinBot.Domain.Dto;
using CoinBot.Domain.Models;

namespace CoinBot.Domain.Interfaces.Services;

public interface IUserService
{
    Task<User> GetUserAsync(long chatId);

    Task<UserStateDto> GetCacheUserStateAsync(long chatId);

    Task SetCacheUserAsync(User user);
}
