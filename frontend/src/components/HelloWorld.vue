<template>
  <div class="hello">
    <h1>{{ msg }}</h1>
    <p>
      For more information about Vue.js, check out the
      <a href="https://vuejs.org" target="_blank">Vue.js documentation</a>.
    </p>
  </div>
</template>

<script lang="ts">
import { defineComponent } from 'vue';

export default defineComponent({
  name: 'HelloWorld',
  props: {
    msg: {
      type: String,
      required: true
    }
  }
});
</script>

<style scoped>
.hello {
  text-align: center;
  padding: 20px;
}
</style>