using AutoMapper;
using CoinBot.Domain.Models;

namespace CoinBot.DTO.Profiles;

public class MessageProfile : Profile
{
    public MessageProfile()
    {
        CreateMap<Message, Telegram.Bot.Types.Message>()
            .ForMember(dst => dst.Text, cfg => cfg.MapFrom(src => src.Text));
    }
}