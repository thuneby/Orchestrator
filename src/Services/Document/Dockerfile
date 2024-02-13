#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/Services/Document/Document.csproj", "src/Services/Document/"]
RUN dotnet restore "src/Services/Document/Document.csproj"
COPY . .
WORKDIR "/src/src/Services/Document"
RUN dotnet build "Document.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Document.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Document.dll"]