#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["TrackAnalyser/TrackAnalyser.csproj", "TrackAnalyser/"]
COPY ["TrackAnalyser.DataAccess/TrackAnalyser.DataAccess.csproj", "TrackAnalyser.DataAccess/"]
COPY ["TrackAnalyser.Models/TrackAnalyser.Models.csproj", "TrackAnalyser.Models/"]
COPY ["TrackAnalyser.Utilities/TrackAnalyser.Utilities.csproj", "TrackAnalyser.Utilities/"]
RUN dotnet restore "TrackAnalyser/TrackAnalyser.csproj"
COPY . .
WORKDIR "/src/TrackAnalyser"
RUN dotnet build "TrackAnalyser.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TrackAnalyser.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TrackAnalyser.dll"]