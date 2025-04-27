<template>
    <div class="d-flex align-items-center justify-content-center min-vh-100">
      <div class="border rounded p-4 shadow" style="width: 400px;">
        <h2 class="text-center mb-4">Login</h2>
        <form @submit.prevent="onSubmit">
          <div class="mb-3">
            <label for="usuario" class="form-label">Usuário</label>
            <input
              v-model="form.usuario"
              type="text"
              class="form-control"
              id="usuario"
              required
            />
          </div>
  
          <div class="mb-3">
            <label for="password" class="form-label">Senha</label>
            <input
              v-model="form.password"
              type="password"
              class="form-control"
              id="password"
              required
            />
          </div>
  
          <div class="mb-3" v-if="isPasswordValid">
            <p class="mb-2">Sua senha precisa conter:</p>
            <ul class="list-unstyled">
              <li class="text-start ps-3">
                <i :class="hasUppercase ? 'bi bi-check-circle-fill text-success' : 'bi bi-x-circle-fill text-danger'"></i>
                1 Letra Maiúscula
              </li>
              <li class="text-start ps-3">
                <i :class="hasNumber ? 'bi bi-check-circle-fill text-success' : 'bi bi-x-circle-fill text-danger'"></i>
                1 Número
              </li>
              <li class="text-start ps-3">
                <i :class="hasMinLength ? 'bi bi-check-circle-fill text-success' : 'bi bi-x-circle-fill text-danger'"></i>
                Mínimo 8 caracteres
              </li>
              <li class="text-start ps-3">
                <i :class="hasLowcase ? 'bi bi-check-circle-fill text-success' : 'bi bi-x-circle-fill text-danger'"></i>
                1 Letra minúscula
              </li>
            </ul>
          </div>
  
          <button type="submit" class="btn btn-primary w-100">Entrar</button>
        </form>
      </div>
    </div>
  </template>
 <script lang="ts">
 
 import { defineComponent, computed, reactive, ref, getCurrentInstance } from 'vue';
 import { showAlert } from '../Utils/Toast-plugin.js'; // Note the .js extension

 export default defineComponent({
   name: 'Login',
   setup() {
     const { appContext } = getCurrentInstance()!;
     const toast = appContext.config.globalProperties.$toast;
 
     const form = reactive({
       usuario: '',
       password: '',
     });
 
     const isPasswordValid = ref(false);
 
     const hasUppercase = computed(() => /[A-Z]/.test(form.password));
     const hasNumber = computed(() => /\d/.test(form.password));
     const hasMinLength = computed(() => form.password.length >= 8);
     const hasLowcase = computed(() => /[a-z]/.test(form.password));
 
     function onSubmit() {
       if (hasUppercase.value && hasNumber.value && hasMinLength.value && hasLowcase.value) {
         showAlert('success', 'Acesso Liberado', 'Obrigado pelos Dados!', 1500, true);

       } else {
         isPasswordValid.value = true;
         showAlert('warning', 'Credenciais inválidas', 'Por gentileza valide se foi preenchido corretamente!', 1500, true);
       }
     }
 
     return {
       form,
       hasUppercase,
       hasNumber,
       hasMinLength,
       hasLowcase,
       isPasswordValid,
       onSubmit,
     };
   },
 });
 </script>
 