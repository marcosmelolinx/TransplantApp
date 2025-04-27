import { createApp } from 'vue';
import App from './App.vue';
import VueSweetalert2 from 'vue-sweetalert2';
import BootstrapVue3 from 'bootstrap-vue-3';

import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap-icons/font/bootstrap-icons.css';
import 'bootstrap-vue-3/dist/bootstrap-vue-3.css';
import 'sweetalert2/dist/sweetalert2.min.css';


const app = createApp(App);

app.use(BootstrapVue3);
app.use(VueSweetalert2);
app.mount('#app');
