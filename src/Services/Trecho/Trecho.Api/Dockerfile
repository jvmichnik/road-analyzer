FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["src/Services/Trecho/Trecho.Api/Trecho.Api.csproj", "src/Services/Trecho/Trecho.Api/"]
COPY ["src/BuildingBlocks/EventBus/EventBusRabbitMQ/BusRabbitMQ.csproj", "src/BuildingBlocks/EventBus/EventBusRabbitMQ/"]
COPY ["src/BuildingBlocks/EventBus/ZEventBus/ZEventBus.csproj", "src/BuildingBlocks/EventBus/ZEventBus/"]
RUN dotnet restore "src/Services/Trecho/Trecho.Api/Trecho.Api.csproj"
COPY . .
WORKDIR "/src/src/Services/Trecho/Trecho.Api"
RUN dotnet build "Trecho.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Trecho.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Trecho.Api.dll"]