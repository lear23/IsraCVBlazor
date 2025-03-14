# Use the official .NET 9 SDK image
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

# Set the working directory
WORKDIR /app

# Copy the project file and restore the dependencies
COPY ["IsraCVBlazor/IsraCVBlazor.csproj", "IsraCVBlazor/"]
RUN dotnet restore "IsraCVBlazor/IsraCVBlazor.csproj"

# Copy the rest of the files
COPY . .

# Build the app in Release configuration
RUN dotnet publish "IsraCVBlazor/IsraCVBlazor.csproj" -c Release -o /app/publish

# Use the official .NET ASP.NET runtime image for the final stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80

# Copy the published files from the build stage
COPY --from=build /app/publish .

# Define the entrypoint to run your application
ENTRYPOINT ["dotnet", "IsraCVBlazor.dll"]