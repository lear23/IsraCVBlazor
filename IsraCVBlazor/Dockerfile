# Etapa base, donde se correr� la aplicaci�n
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80
ENV ASPNETCORE_URLS=http://+:80

# Etapa de construcci�n, donde se restauran las dependencias y se compila el proyecto
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copiar la soluci�n y los archivos de proyecto para la restauraci�n de dependencias

COPY ["IsraCVBlazor.csproj", "./"]

# Restaurar dependencias (restore)
RUN dotnet restore "IsraCVBlazor.csproj"

# Copiar el resto del c�digo fuente
COPY . .

# Construir el proyecto
RUN dotnet build "IsraCVBlazor.csproj" -c Release -o /app/build

# Publicar la aplicaci�n
FROM build AS publish
RUN dotnet publish "IsraCVBlazor.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Imagen final que se usar� para ejecutar la aplicaci�n
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IsraCVBlazor.dll"]
