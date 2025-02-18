# Use the official .NET Core runtime as a base image
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app

# Use the official .NET Core SDK as a build image
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copy the project files into the container
COPY ["./MiniTMS.API/MiniTMS.csproj", "."]
RUN dotnet restore

# Copy the remaining code into the container
COPY . .
WORKDIR "/src/MiniTMS.API"
RUN dotnet build -c Release -o /app/build

# Build the final image with the runtime
FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MiniTMS.dll"]

ENV PORT=8080

EXPOSE 8080