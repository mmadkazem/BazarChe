FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Services/BazarChe.Media/Media.Api/Media.Api.csproj", "Services/BazarChe.Media/Media.Api/"]
RUN dotnet restore "./Services/BazarChe.Media/Media.Api/Media.Api.csproj"
COPY . .
WORKDIR "/src/Services/BazarChe.Media/Media.Api"
RUN dotnet build "./Media.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Media.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app

COPY ../BuildingBlocks ./BuildingBlocks

COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Media.Api.dll"]