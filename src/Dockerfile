# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /source

# copy sln and csproj and restore as distinct layers
COPY *.slnx .
COPY BPol.Api/*.csproj ./BPol.Api/
RUN dotnet restore

# copy everything else and build app
COPY BPol.Api/. ./BPol.Api/
WORKDIR /source
RUN dotnet publish -c release -o /app --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "BPol.Api.dll"]