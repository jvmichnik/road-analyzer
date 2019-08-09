FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["src/Services/Levantamento/Levantamento.Api/Levantamento.Api.csproj", "src/Services/Levantamento/Levantamento.Api/"]
RUN dotnet restore "src/Services/Levantamento/Levantamento.Api/Levantamento.Api.csproj"
COPY . .
WORKDIR "/src/src/Services/Levantamento/Levantamento.Api"
RUN dotnet build "Levantamento.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Levantamento.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Levantamento.Api.dll"]