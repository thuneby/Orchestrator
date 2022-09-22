#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Services/Orchestrator/Orchestrator.csproj", "src/Services/Orchestrator/"]
COPY ["src/Components/DataAccess/DataAccess.csproj", "src/Components/DataAccess/"]
COPY ["src/Core/Core/Core.csproj", "src/Core/Core/"]
COPY ["src/Components/BlobAccess/BlobAccess.csproj", "src/Components/BlobAccess/"]
COPY ["src/Components/DocumentAccess/DocumentAccess.csproj", "src/Components/DocumentAccess/"]
COPY ["src/Core/ExternalModels/ExternalModels.csproj", "src/Core/ExternalModels/"]
COPY ["src/Components/StateMachine/StateMachine.csproj", "src/Components/StateMachine/"]
COPY ["src/Services/Ingestion/Ingestion.csproj", "src/Services/Ingestion/"]
COPY ["src/Components/EventBus/EventBus.csproj", "src/Components/EventBus/"]
COPY ["src/Components/Utilities/Utilities.csproj", "src/Components/Utilities/"]
COPY ["src/Services/Parse/Parse.csproj", "src/Services/Parse/"]
COPY ["src/Core/Configuration/Configuration.csproj", "src/Core/Configuration/"]
RUN dotnet restore "src/Services/Orchestrator/Orchestrator.csproj"
COPY . .
WORKDIR "/src/src/Services/Orchestrator"
RUN dotnet build "Orchestrator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Orchestrator.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Orchestrator.dll"]