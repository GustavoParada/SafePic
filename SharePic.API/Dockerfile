#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["SharePic.API/SharePic.API.csproj", "SharePic.API/"]
COPY ["Infra.IoC/Infra.IoC.csproj", "Infra.IoC/"]
COPY ["SharePic.Data/SharePic.Data.csproj", "SharePic.Data/"]
COPY ["SharePic.Domain/SharePic.Domain.csproj", "SharePic.Domain/"]
COPY ["Domain.Core/Domain.Core.csproj", "Domain.Core/"]
COPY ["Domain.MongoDB/Domain.MongoDB.csproj", "Domain.MongoDB/"]
COPY ["Infra.Bus/Infra.Bus.csproj", "Infra.Bus/"]
COPY ["SharePic.Application/SharePic.Application.csproj", "SharePic.Application/"]
RUN dotnet restore "SharePic.API/SharePic.API.csproj"
COPY . .
WORKDIR "/src/SharePic.API"
RUN dotnet build "SharePic.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SharePic.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SharePic.API.dll"]