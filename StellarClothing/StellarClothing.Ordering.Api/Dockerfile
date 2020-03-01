FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /src
COPY ["StellarClothing.Ordering.Api/StellarClothing.Ordering.Api.csproj", "StellarClothing.Ordering.Api/"]

RUN dotnet restore "StellarClothing.Ordering.Api/StellarClothing.Ordering.Api.csproj"
COPY . .
WORKDIR "/src/StellarClothing.Ordering.Api"
RUN dotnet build "StellarClothing.Ordering.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "StellarClothing.Ordering.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "StellarClothing.Ordering.Api.dll"]