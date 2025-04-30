# Etapa 1: Build do frontend (Vite)
FROM node:20-alpine AS frontend-build
WORKDIR /app/frontend

# Copia o arquivo package.json e package-lock.json para o diretório de trabalho
COPY frontend/package*.json ./ 

# Instala as dependências do frontend
RUN npm install

# Instala a versão específica do esbuild
RUN npm install esbuild@0.25.2 --save-dev

# Copia o restante dos arquivos do frontend (a partir do diretório correto)
COPY frontend/ ./  
# Isso vai copiar todos os arquivos da pasta frontend para o diretório /app/frontend dentro do container

# Gera os arquivos de produção
RUN npm run build


# Etapa 2: Build do backend (.NET)
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copia o arquivo .csproj e restaura as dependências do backend
COPY backend/*.csproj ./ 
RUN dotnet restore

# Copia o restante dos arquivos do backend
COPY backend/ ./ 

# Publica o projeto para produção
RUN dotnet publish -c Release -o /app/publish


# Etapa 3: Runtime (imagem final do container)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app

# Copia o backend publicado para o container
COPY --from=build /app/publish ./ 

# Copia os arquivos estáticos gerados pelo frontend para o diretório wwwroot do backend
COPY --from=frontend-build /app/frontend/dist ./wwwroot/

# Diretório de volume opcional para dados
VOLUME /app/data

# Variáveis de ambiente
ENV ASPNETCORE_HTTP_PORTS=5001
ENV DOTNET_RUNNING_IN_CONTAINER=true

# Inicia a aplicação ASP.NET
ENTRYPOINT ["dotnet", "backend.dll"]
