
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80
ENV ASPNETCORE_URLS=http://+:80  


FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["IsraCVBlazor/IsraCVBlazor.csproj", "IsraCVBlazor/"]
RUN dotnet restore "IsraCVBlazor/IsraCVBlazor.csproj"

COPY . .
WORKDIR "/src/IsraCVBlazor"
RUN dotnet build "IsraCVBlazor.csproj" -c $BUILD_CONFIGURATION -o /app/build


FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "IsraCVBlazor.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false


FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IsraCVBlazor.dll"]
