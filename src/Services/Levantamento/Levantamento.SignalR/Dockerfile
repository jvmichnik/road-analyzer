FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["src/Services/Levantamento/Levantamento.SignalR/Levantamento.SignalR.csproj", "src/Services/Levantamento/Levantamento.SignalR/"]
RUN dotnet restore "src/Services/Levantamento/Levantamento.SignalR/Levantamento.SignalR.csproj"
COPY . .
WORKDIR "/src/src/Services/Levantamento/Levantamento.SignalR"
RUN dotnet build "Levantamento.SignalR.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Levantamento.SignalR.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Levantamento.SignalR.dll"]