FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /src
COPY ["StellarClothing.Catalog.Api/StellarClothing.Catalog.Api.csproj", "StellarClothing.Catalog.Api/"]

RUN dotnet restore "StellarClothing.Catalog.Api/StellarClothing.Catalog.Api.csproj"
COPY . .
WORKDIR "/src/StellarClothing.Catalog.Api"
RUN dotnet build "StellarClothing.Catalog.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "StellarClothing.Catalog.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "StellarClothing.Catalog.Api.dll"]