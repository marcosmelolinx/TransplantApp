# backend/Dockerfile
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

WORKDIR /app
COPY backend/*.csproj ./
RUN dotnet restore

COPY backend/ .
RUN dotnet publish -c Release -o /publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /publish .

ENV ASPNETCORE_URLS=http://0.0.0.0:5000
EXPOSE 5000

# Define o diretório do banco de dados
VOLUME /app/data

ENTRYPOINT ["dotnet", "backend.dll"]
