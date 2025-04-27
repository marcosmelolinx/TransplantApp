declare module '*.js';  // Permite que arquivos .js sejam reconhecidos pelo TypeScript
declare module '*.vue' {
  import { DefineComponent } from 'vue';
  const component: DefineComponent<{}, {}, any>;
  export default component;
}
