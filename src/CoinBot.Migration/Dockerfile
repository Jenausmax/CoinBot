#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 82

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["CoinBot.Migration/CoinBot.Migration.csproj", "CoinBot.Migration/"]
COPY ["CoinBot.Database/CoinBot.Database.csproj", "CoinBot.Database/"]
COPY ["CoinBot.Domain/CoinBot.Domain.csproj", "CoinBot.Domain/"]
RUN dotnet restore "CoinBot.Migration/CoinBot.Migration.csproj"
COPY . .
WORKDIR "/src/CoinBot.Migration"
RUN dotnet build "CoinBot.Migration.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CoinBot.Migration.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CoinBot.Migration.dll"]