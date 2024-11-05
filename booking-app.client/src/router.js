import { createRouter, createWebHistory } from "vue-router";
import LoginComponent from "./components/LoginComponent.vue";
import ProfileComponent from "./components/ProfileComponent.vue";
import SearchComponent from "./components/SearchComponent.vue";
import MainPageComponent from "./components/MainPageComponent.vue";
import HotelInfoComponent from "./components/HotelInfoComponent.vue";

const routes = [
  { path: "/", component: LoginComponent, name: "login" },
  { path: "/profile", component: ProfileComponent, name: "profile" },
  { path: "/search", component: SearchComponent, name: "search" },
  { path: "/mainpage", component: MainPageComponent, name: "mainpage" },
  { path: "/hotelinfo", component: HotelInfoComponent, name: "hotelinfo" },
  { path: "/:pathMatch(.*)*", redirect: "/" }
];

const router = createRouter({
  history: createWebHistory(),
  routes
});

export default router;
