FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /src
COPY ["StellarClothing.Identity.Api/StellarClothing.Identity.Api.csproj", "StellarClothing.Identity.Api/"]

RUN dotnet restore "StellarClothing.Identity.Api/StellarClothing.Identity.Api.csproj"
COPY . .
WORKDIR "/src/StellarClothing.Identity.Api"
RUN dotnet build "StellarClothing.Identity.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "StellarClothing.Identity.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "StellarClothing.Identity.Api.dll"]