import { createRouter, createWebHistory } from "vue-router";
import Login from "./components/Login.vue";
import Profile from "./components/Profile.vue";

const routes = [
  { path: "/", component: Login, name: "login" },
  { path: "/profile", component: Profile, name: "profile" },
  { path: "/:pathMatch(.*)*", redirect: "/" }
];

const router = createRouter({
  history: createWebHistory(),
  routes
});

export default router;
