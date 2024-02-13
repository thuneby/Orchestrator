#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["src/Services/Validate/Validate.csproj", "src/Services/Validate/"]
RUN dotnet restore "src/Services/Validate/Validate.csproj"
COPY . .
WORKDIR "/src/src/Services/Validate"
RUN dotnet build "Validate.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Validate.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Validate.dll"]