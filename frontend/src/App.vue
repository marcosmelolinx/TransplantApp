<template>
  <div id="app">
    <Login />
  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue';
import Login from './components/Login.vue'; // Importa o componente Login

export default defineComponent({
  name: 'App',
  components: {
    Login // Usa o componente Login aqui
  }
});
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
