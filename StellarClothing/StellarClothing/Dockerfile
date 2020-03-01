FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /src
COPY ["StellarClothing/StellarClothing.csproj", "StellarClothing/"]

RUN dotnet restore "StellarClothing/StellarClothing.csproj"
COPY . .
WORKDIR "/src/StellarClothing"
RUN dotnet build "StellarClothing.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "StellarClothing.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "StellarClothing.dll"]