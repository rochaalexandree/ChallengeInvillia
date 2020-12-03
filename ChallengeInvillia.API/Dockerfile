FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["ChallengeInvillia.API/ChallengeInvillia.API.csproj", "ChallengeInvillia.API/"]
RUN dotnet restore "ChallengeInvillia.API\ChallengeInvillia.API.csproj"
COPY . .
WORKDIR "/src/ChallengeInvillia.API"
RUN dotnet build "ChallengeInvillia.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ChallengeInvillia.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ChallengeInvillia.API.dll"]
