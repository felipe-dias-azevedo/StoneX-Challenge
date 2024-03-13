FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["FelipeDiasAzevedo.StoneX/FelipeDiasAzevedo.StoneX.csproj", "FelipeDiasAzevedo.StoneX/"]
RUN dotnet restore "FelipeDiasAzevedo.StoneX/FelipeDiasAzevedo.StoneX.csproj"
COPY . .
WORKDIR "/src/FelipeDiasAzevedo.StoneX"
RUN dotnet build "FelipeDiasAzevedo.StoneX.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "FelipeDiasAzevedo.StoneX.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FelipeDiasAzevedo.StoneX.dll"]
