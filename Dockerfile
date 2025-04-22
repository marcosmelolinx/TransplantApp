# 1) Build do frontend
FROM node:18-alpine AS frontend
WORKDIR /app
COPY frontend/ .
RUN npm install
RUN npm run build

# 2) Build do backend
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY backend/ ./backend/
WORKDIR /src/backend
RUN dotnet restore
RUN dotnet publish -c Release -o /app/publish

# 3) Imagem final
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app

# Copia front (após build)
COPY --from=frontend /app/dist ./wwwroot

# Copia backend (após publish)
COPY --from=build /app/publish .

EXPOSE 80
ENTRYPOINT ["dotnet", "backend.dll"]
