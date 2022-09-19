#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Web/OrchestratorApi/OrchestratorApi.csproj", "src/Web/OrchestratorApi/"]
COPY ["src/Components/Persistance/Persistance.csproj", "src/Components/Persistance/"]
COPY ["src/Core/Core/Core.csproj", "src/Core/Core/"]
RUN dotnet restore "src/Web/OrchestratorApi/OrchestratorApi.csproj"
COPY . .
WORKDIR "/src/src/Web/OrchestratorApi"
RUN dotnet build "OrchestratorApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OrchestratorApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OrchestratorApi.dll"]