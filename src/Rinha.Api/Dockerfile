FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 3000
EXPOSE 3001

ENV ASPNETCORE_URLS=http://+:3000

FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["src/Rinha.Api/Rinha.Api.csproj", "src/Rinha.Api/"]
RUN dotnet restore "src/Rinha.Api/Rinha.Api.csproj"
COPY . .
WORKDIR "/src/src/Rinha.Api"
RUN dotnet build "Rinha.Api.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "Rinha.Api.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Rinha.Api.dll"]
