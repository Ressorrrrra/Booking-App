import { createRouter, createWebHistory } from "vue-router";
import LoginComponent from "./components/LoginComponent.vue";
import ProfileComponent from "./components/ProfileComponent.vue";
import SearchComponent from "./components/SearchComponent.vue";

const routes = [
  { path: "/", component: LoginComponent, name: "login" },
  { path: "/profile", component: ProfileComponent, name: "profile" },
  { path: "/search", component: SearchComponent, name: "search" },
  { path: "/:pathMatch(.*)*", redirect: "/" }
];

const router = createRouter({
  history: createWebHistory(),
  routes
});

export default router;
