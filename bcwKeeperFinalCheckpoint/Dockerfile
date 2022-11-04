FROM mcr.microsoft.com/dotnet/sdk:6.0 AS base
WORKDIR /app
EXPOSE 80/tcp

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["bcwKeeperFinalCheckpoint.csproj", "./"]
RUN dotnet restore "bcwKeeperFinalCheckpoint.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "bcwKeeperFinalCheckpoint.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "bcwKeeperFinalCheckpoint.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "bcwKeeperFinalCheckpoint.dll"]
