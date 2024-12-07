import "./assets/main.css";

import { createApp } from "vue";
import App from "./App.vue";
import router from "./router.js";
import PrimeVue from "primevue/config";
import { userStatePlugin } from "./plugins/userStatePlugin";

import "primeicons/primeicons.css";
import Aura from "@primevue/themes/aura";

const app = createApp(App);
app.use(router);
app.use(userStatePlugin);
app.use(PrimeVue, {
  theme: {
    preset: Aura
  }
});

app.mount("#app");
