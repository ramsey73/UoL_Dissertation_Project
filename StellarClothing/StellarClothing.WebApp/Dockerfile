FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /src
COPY ["StellarClothing.WebApp/StellarClothing.WebApp.csproj", "StellarClothing.WebApp/"]

RUN dotnet restore "StellarClothing.WebApp/StellarClothing.WebApp.csproj"
COPY . .
WORKDIR "/src/StellarClothing.WebApp"
RUN dotnet build "StellarClothing.WebApp.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "StellarClothing.WebApp.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "StellarClothing.WebApp.dll"]