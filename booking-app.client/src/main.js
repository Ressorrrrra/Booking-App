import "./assets/main.css";

import { createApp } from "vue";
import App from "./App.vue";
import router from "./router.js";
import PrimeVue from "primevue/config";

import "primeicons/primeicons.css";
import Aura from "@primevue/themes/aura";

const app = createApp(App);
app.use(router);
app.use(PrimeVue, {
  theme: {
    preset: Aura
  }
});

app.mount("#app");
