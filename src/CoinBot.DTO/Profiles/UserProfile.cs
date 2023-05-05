using AutoMapper;
using CoinBot.Domain.Dto;
using Telegram.Bot.Types;
using User = CoinBot.Domain.Models.User;

namespace CoinBot.DTO.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserDto, User>().ReverseMap();

        CreateMap<Message, UserDto>()
            .ForMember(dst => dst.ChatId, cfg => cfg.MapFrom(src => src.Chat.Id))
            .ForMember(dst => dst.Name, cfg => cfg.MapFrom(src => src.Chat.FirstName + src.Chat.LastName))
            .ForMember(dst => dst.IsDeleted, cfg => cfg.Ignore());

        CreateMap<Message, User>()
            .ForMember(dst => dst.ChatId, cfg => cfg.MapFrom(src => src.Chat.Id))
            .ForMember(dst => dst.FirstName, cfg => cfg.MapFrom(src => src.Chat.FirstName))
            .ForMember(dst => dst.LastName, cfg => cfg.MapFrom(src => src.Chat.LastName))
            .ForMember(dst => dst.TelegramId, cfg => cfg.MapFrom(src => src.From!.Id))
            .ForMember(dst => dst.IsDeleted, cfg => cfg.Ignore())
            .ForMember(dst => dst.Id, cfg => cfg.Ignore());

        CreateMap<CallbackQuery, User>()
            .ForMember(dst => dst.ChatId, cfg => cfg.MapFrom(src => src.Message!.Chat.Id))
            .ForMember(dst => dst.FirstName, cfg => cfg.MapFrom(src => src.From.FirstName))
            .ForMember(dst => dst.LastName, cfg => cfg.MapFrom(src => src.From.LastName))
            .ForMember(dst => dst.TelegramId, cfg => cfg.MapFrom(src => src.From.Id))
            .ForMember(dst => dst.IsDeleted, cfg => cfg.Ignore())
            .ForMember(dst => dst.Id, cfg => cfg.Ignore());

        CreateMap<User, UserStateDto>()
            .ForMember(dst => dst.ChatId, cfg => cfg.MapFrom(src => src.ChatId))
            .ForMember(dst => dst.UserId, cfg => cfg.MapFrom(src => src.Id))
            .ForMember(dst => dst.State, cfg => cfg.Ignore());
    }
}

