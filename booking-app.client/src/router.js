import { createRouter, createWebHistory } from "vue-router";
import LoginComponent from "./components/LoginComponent.vue";
import ProfileComponent from "./components/ProfileComponent.vue";
import SearchComponent from "./components/SearchComponent.vue";
import MainPageComponent from "./components/MainPageComponent.vue";
import HotelInfoComponent from "./components/HotelInfoComponent.vue";
import BookingPageComponent from "./components/BookingPageComponent.vue";
import BookingInfoComponent from "./components/BookingInfoComponent.vue";
import RegistrationComponent from "./components/RegistrationComponent.vue";

const routes = [
  {
    path: "/",
    component: LoginComponent,
    name: "login"
  },
  {
    path: "/registration",
    component: RegistrationComponent,
    name: "registration"
  },
  {
    path: "/profile",
    component: ProfileComponent,
    name: "profile"
  },
  {
    path: "/search",
    component: SearchComponent,
    name: "search"
  },
  {
    path: "/mainpage",
    component: MainPageComponent,
    name: "mainpage"
  },
  {
    path: "/hotelinfo/:id", // Добавлен параметр id
    component: HotelInfoComponent,
    name: "hotelinfo"
  },
  {
    path: "/bookinginfo/:id", // Если требуется параметр id
    component: BookingInfoComponent,
    name: "bookinginfo"
  },
  {
    path: "/bookingpage/:id", // Если требуется параметр id
    component: BookingPageComponent,
    name: "bookingpage"
  },
  {
    path: "/:pathMatch(.*)*",
    redirect: "/"
  }
];

const router = createRouter({
  history: createWebHistory(),
  routes
});

export default router;
