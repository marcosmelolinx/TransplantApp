import { defineConfig } from 'vite';
import vue from '@vitejs/plugin-vue';

export default defineConfig({
  plugins: [vue()],
  server: {
    host: '0.0.0.0',   // <- força aceitar conexões de fora (não só localhost)
    port: 3000,
    strictPort: true,   // <- garante erro se a porta 3000 já estiver em uso
    open: false,        // <- não tenta abrir navegador
    cors: true          // <- habilita CORS, caso seu front acesse APIs externas
  },
  build: {
    outDir: 'dist',
  },
  resolve: {
    alias: {
      '@': '/src',
    },
  },
});
