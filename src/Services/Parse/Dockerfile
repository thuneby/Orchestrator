#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/Services/Parse/Parse.csproj", "src/Services/Parse/"]
COPY ["src/Components/BlobAccess/BlobAccess.csproj", "src/Components/BlobAccess/"]
COPY ["src/Core/Core/Core.csproj", "src/Core/Core/"]
COPY ["src/Components/DocumentAccess/DocumentAccess.csproj", "src/Components/DocumentAccess/"]
COPY ["src/Core/ExternalModels/ExternalModels.csproj", "src/Core/ExternalModels/"]
COPY ["src/Components/EventBus/EventBus.csproj", "src/Components/EventBus/"]
COPY ["src/Components/DataAccess/DataAccess.csproj", "src/Components/DataAccess/"]
COPY ["src/Components/Utilities/Utilities.csproj", "src/Components/Utilities/"]
RUN dotnet restore "src/Services/Parse/Parse.csproj"
COPY . .
WORKDIR "/src/src/Services/Parse"
RUN dotnet build "Parse.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Parse.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Parse.dll"]