FROM node:18-alpine

WORKDIR /app

COPY frontend/package*.json ./
RUN npm install

COPY frontend/ .

# Rodar o Vite na porta 3000 e expor para fora
EXPOSE 3000

CMD ["npm", "run", "dev", "--", "--host"]
