FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /src
COPY ["StellarClothing.Customer.Api/StellarClothing.Customer.Api.csproj", "StellarClothing.Customer.Api/"]

RUN dotnet restore "StellarClothing.Customer.Api/StellarClothing.Customer.Api.csproj"
COPY . .
WORKDIR "/src/StellarClothing.Customer.Api"
RUN dotnet build "StellarClothing.Customer.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "StellarClothing.Customer.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "StellarClothing.Customer.Api.dll"]