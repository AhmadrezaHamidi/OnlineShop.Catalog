#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["DevtubeShop.Catalog.Infrastructure.API/DevtubeShop.Catalog.Infrastructure.API.csproj", "DevtubeShop.Catalog.Infrastructure.API/"]
RUN dotnet restore "DevtubeShop.Catalog.Infrastructure.API/DevtubeShop.Catalog.Infrastructure.API.csproj"
COPY . .
WORKDIR "/src/DevtubeShop.Catalog.Infrastructure.API"
RUN dotnet build "DevtubeShop.Catalog.Infrastructure.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DevtubeShop.Catalog.Infrastructure.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DevtubeShop.Catalog.Infrastructure.API.dll"]