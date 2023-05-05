using CoinBot.Domain.Dto;
using CoinBot.Domain.Interfaces.Services;
using CoinBot.Domain.Models;

namespace CoinBot.Core.Services;

public class UserService : IUserService
{
    public Task<User> GetUserAsync(long chatId)
    {
        throw new NotImplementedException();
    }

    public Task<UserStateDto> GetCacheUserStateAsync(long chatId)
    {
        throw new NotImplementedException();
    }

    public Task SetCacheUserAsync(User user)
    {
        throw new NotImplementedException();
    }
}
