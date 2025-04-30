import { defineConfig } from 'vite';
import vue from '@vitejs/plugin-vue';

export default defineConfig({
  plugins: [vue()],
  server: {
    host: '0.0.0.0',
    port: 3000,
    strictPort: true,
    open: false,
    cors: true
  },
  build: {
    outDir: 'dist',
    sourcemap: false, // Desativa sourcemaps para produção
    minify: 'esbuild', // Garante que o esbuild seja usado para minificação
  },
  resolve: {
    alias: {
      '@': '/src',
    },
  },
});
