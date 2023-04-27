using AutoMapper;
using Telegram.Bot.Types;
using User = CoinBot.Domain.Models.User;

namespace CoinBot.DTO.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserDto, User>();

        CreateMap<Message, UserDto>()
            .ForMember(dst => dst.ChatId, cfg => cfg.MapFrom(src => src.Chat.Id))
            .ForMember(dst => dst.Name, cfg => cfg.MapFrom(src => src.Chat.FirstName + src.Chat.LastName))
            .ForMember(dst => dst.IsDeleted, cfg => cfg.Ignore());
    }
}

