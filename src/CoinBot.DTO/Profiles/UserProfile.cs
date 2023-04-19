using AutoMapper;
using CoinBot.Domain.Models;

namespace CoinBot.DTO.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserDto, User>();
    }
}

