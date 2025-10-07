FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /
COPY ["../Directory.Build.props", "."]
COPY ["../src/PulseTrack.Domain/PulseTrack.Domain.csproj", "src/PulseTrack.Domain/"]
COPY ["../src/PulseTrack.Application/PulseTrack.Application.csproj", "src/PulseTrack.Application/"]
COPY ["../src/PulseTrack.CrossCutting/PulseTrack.CrossCutting.csproj", "src/PulseTrack.CrossCutting/"]
COPY ["../src/PulseTrack.Persistence/PulseTrack.Persistence.csproj", "src/PulseTrack.Persistence/"]
COPY ["../src/PulseTrack.Api/PulseTrack.Api.csproj", "src/PulseTrack.Api/"]

RUN dotnet restore src/PulseTrack.Api/PulseTrack.Api.csproj

COPY . .
WORKDIR "src/PulseTrack.Api"
RUN dotnet build "PulseTrack.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PulseTrack.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_HTTP_PORTS=80
#ENV ASPNETCORE_HTTPS_PORTS=443
ENTRYPOINT ["dotnet", "PulseTrack.Api.dll"]