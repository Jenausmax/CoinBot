#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 7550

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["CoinBot.Api/CoinBot.Api.csproj", "CoinBot.Api/"]
COPY ["CoinBot.Database/CoinBot.Database.csproj", "CoinBot.Database/"]
COPY ["CoinBot.Domain/CoinBot.Domain.csproj", "CoinBot.Domain/"]
COPY ["CoinBot.Settings/CoinBot.Settings.csproj", "CoinBot.Settings/"]
RUN dotnet restore "CoinBot.Api/CoinBot.Api.csproj"
COPY . .
WORKDIR "/src/CoinBot.Api"
RUN dotnet build "CoinBot.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CoinBot.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CoinBot.Api.dll"]