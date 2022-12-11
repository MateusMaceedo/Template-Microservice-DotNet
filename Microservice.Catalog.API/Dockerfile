#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Microservice.Catalog.API/Microservice.Catalog.API.csproj", "Microservice.Catalog.API/"]
COPY ["Microservice.Catalog.IoC/Microservice.Catalog.IoC.csproj", "Microservice.Catalog.IoC/"]
COPY ["Microservice.Catalog.Core/Microservice.Catalog.Core.csproj", "Microservice.Catalog.Core/"]
COPY ["Microservice.Catalog.Domain/Microservice.Catalog.Domain.csproj", "Microservice.Catalog.Domain/"]
COPY ["Microservice.Catalog.Infra/Microservice.Catalog.Infra.csproj", "Microservice.Catalog.Infra/"]
RUN dotnet restore "Microservice.Catalog.API/Microservice.Catalog.API.csproj"
COPY . .
WORKDIR "/src/Microservice.Catalog.API"
RUN dotnet build "Microservice.Catalog.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Microservice.Catalog.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Microservice.Catalog.API.dll"]