# Etapa base, donde se correrá la aplicación
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80
ENV ASPNETCORE_URLS=http://+:80

# Etapa de construcción, donde se restauran las dependencias y se compila el proyecto
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copiar la solución y los archivos de proyecto para la restauración de dependencias

COPY ["IsraCVBlazor.csproj", "./"]

# Restaurar dependencias (restore)
RUN dotnet restore "IsraCVBlazor.csproj"

# Copiar el resto del código fuente
COPY . .

# Construir el proyecto
RUN dotnet build "IsraCVBlazor.csproj" -c Release -o /app/build

# Publicar la aplicación
FROM build AS publish
RUN dotnet publish "IsraCVBlazor.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Imagen final que se usará para ejecutar la aplicación
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IsraCVBlazor.dll"]
