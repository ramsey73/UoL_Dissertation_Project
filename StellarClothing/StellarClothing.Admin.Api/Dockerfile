FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /src
COPY ["StellarClothing.Admin.Api/StellarClothing.Admin.Api.csproj", "StellarClothing.Admin.Api/"]

RUN dotnet restore "StellarClothing.Admin.Api/StellarClothing.Admin.Api.csproj"
COPY . .
WORKDIR "/src/StellarClothing.Admin.Api"
RUN dotnet build "StellarClothing.Admin.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "StellarClothing.Admin.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "StellarClothing.Admin.Api.dll"]