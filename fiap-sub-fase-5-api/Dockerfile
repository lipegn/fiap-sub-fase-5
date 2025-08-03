FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["fiap-sub-fase-5-api/fiap-sub-fase-5-api.csproj", "."]
RUN dotnet restore "fiap-sub-fase-5-api/fiap-sub-fase-5-api.csproj"
COPY . .
WORKDIR "/src/fiap-sub-fase-5-api"
RUN dotnet build "fiap-sub-fase-5-api/fiap-sub-fase-5-api.csproj" -c Release -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "fiap-sub-fase-5-api/fiap-sub-fase-5-api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "fiap-sub-fase-5-api.dll"]