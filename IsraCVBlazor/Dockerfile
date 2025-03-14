# Usa la imagen base para ASP.NET
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80
ENV ASPNETCORE_URLS=http://+:80

# Usa la imagen de SDK de .NET para construir
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copia la solución y el archivo .csproj
COPY ["IsraCVBlazor/IsraCVBlazor.sln", "./"]
COPY ["IsraCVBlazor/IsraCVBlazor.csproj", "./"]

# Restaura las dependencias
RUN dotnet restore "IsraCVBlazor.csproj"

# Copia el resto del código
COPY . .

# Construye el proyecto
RUN dotnet build "IsraCVBlazor.csproj" -c Release -o /app/build

# Publica la aplicación
FROM build AS publish
RUN dotnet publish "IsraCVBlazor.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Imagen final con los archivos publicados
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "IsraCVBlazor.dll"]
