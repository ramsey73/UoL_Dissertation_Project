FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["StellarClothing.AdminApp/StellarClothing.AdminApp.csproj", "StellarClothing.AdminApp/"]
RUN dotnet restore "StellarClothing.AdminApp/StellarClothing.AdminApp.csproj"
COPY . .
WORKDIR "/src/StellarClothing.AdminApp"
RUN dotnet build "StellarClothing.AdminApp.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "StellarClothing.AdminApp.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "StellarClothing.AdminApp.dll"]