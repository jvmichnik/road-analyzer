FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["src/ApiGateways/ApiGateway/ApiGateway.csproj", "src/ApiGateways/ApiGateway/"]
RUN dotnet restore "src/ApiGateways/ApiGateway/ApiGateway.csproj"
COPY . .
WORKDIR "/src/src/ApiGateways/ApiGateway"
RUN dotnet build "ApiGateway.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ApiGateway.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ApiGateway.dll"]