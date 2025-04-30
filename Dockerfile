# Etapa 1: Build do frontend (Vite)
FROM node:20 AS frontend-build
WORKDIR /app/frontend

# Copia os arquivos necessários para instalar as dependências
COPY frontend/package*.json ./

# Limpa dependências antigas e instala novamente usando 'npm ci' para garantir consistência
#RUN rm -rf node_modules package-lock.json && npm ci --legacy-peer-deps

# Instala a versão específica do esbuild
RUN npm install esbuild@0.25.2 --save-dev

# Copia o restante dos arquivos do frontend
COPY frontend/ .

# Gera os arquivos de produção
RUN npm run build


# Etapa 2: Build do backend (.NET)
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copia e restaura o projeto
COPY backend/*.csproj ./
RUN dotnet restore

# Copia o restante do backend
COPY backend/ ./

# Publica o projeto
RUN dotnet publish -c Release -o /app/publish


# Etapa 3: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app

# Copia o backend publicado
COPY --from=build /app/publish ./

# Copia os arquivos estáticos gerados pelo frontend
COPY --from=frontend-build /app/frontend/dist ./wwwroot/

# Diretório de volume opcional para dados
VOLUME /app/data

# Inicia a aplicação ASP.NET
ENTRYPOINT ["dotnet", "backend.dll"]
