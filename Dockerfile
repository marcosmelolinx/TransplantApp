# Etapa 1 - Build do front (Vue.js)
FROM node:18-alpine AS frontend
WORKDIR /app
COPY frontend/ ./
RUN npm install
RUN npm run build

# Etapa 2 - Build do back (ASP.NET Core)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY backend/ ./backend/
WORKDIR /src/backend
RUN dotnet restore
RUN dotnet publish -c Release -o /app/publish

# Etapa 3 - Imagem final com tudo junto
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Copia a aplicação .NET publicada
COPY --from=build /app/publish .

# Copia o front gerado para wwwroot
COPY --from=frontend /app/dist ./wwwroot

EXPOSE 80
ENTRYPOINT ["dotnet", "backend.dll"]
