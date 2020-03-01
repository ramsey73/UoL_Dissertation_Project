FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["StellarClothing.ShoppingCart.Api/StellarClothing.ShoppingCart.Api.csproj", "StellarClothing.ShoppingCart.Api/"]
RUN dotnet restore "StellarClothing.ShoppingCart.Api/StellarClothing.ShoppingCart.Api.csproj"
COPY . .
WORKDIR "/src/StellarClothing.ShoppingCart.Api"
RUN dotnet build "StellarClothing.ShoppingCart.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "StellarClothing.ShoppingCart.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "StellarClothing.ShoppingCart.Api.dll"]