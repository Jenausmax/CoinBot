using AutoMapper;
using CoinBot.DTO.Profiles;

namespace CoinBot.DTO.Extensions;

public static class ConfigureDto
{
    public static void AddMappingProfiles(this IMapperConfigurationExpression configuration)
    {
        configuration.AddProfile<UserProfile>();
    }
}

