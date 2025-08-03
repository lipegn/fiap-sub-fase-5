#FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
#USER $APP_UID
#WORKDIR /app
#EXPOSE 8080
#EXPOSE 8081
#
#FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
#ARG BUILD_CONFIGURATION=Release
#WORKDIR /src
#COPY ["fiap-sub-fase-5-api/fiap-sub-fase-5-api.csproj", "."]
#RUN dotnet restore "./fiap-sub-fase-5-api.csproj"
#COPY . .
#WORKDIR "/src/."
#RUN dotnet build "./fiap-sub-fase-5-api/fiap-sub-fase-5-api.csproj" -c Release -o /app/build
#
#FROM build AS publish
#ARG BUILD_CONFIGURATION=Release
#RUN dotnet publish "./fiap-sub-fase-5-api/fiap-sub-fase-5-api.csproj" -c Release -o /app/publish /p:UseAppHost=false
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "fiap-sub-fase-5-api.dll"]
#
##See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 72

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["fiap-sub-fase-5-api/FiapDocker.csproj", "fiap-sub-fase-5-api/"]
RUN dotnet restore "fiap-sub-fase-5-api/fiap-sub-fase-5-api.dll.csproj"
COPY . .
WORKDIR "/src/fiap-sub-fase-5-api"
RUN dotnet build "fiap-sub-fase-5-api.dll.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "fiap-sub-fase-5-api.dll.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "fiap-sub-fase-5-api.dll"]