import { createRouter, createWebHistory } from "vue-router";
import LoginComponent from "./components/LoginComponent.vue";
import ProfileComponent from "./components/ProfileComponent.vue";
import SearchComponent from "./components/SearchComponent.vue";
import MainPageComponent from "./components/MainPageComponent.vue";
import HotelInfoComponent from "./components/HotelInfoComponent.vue";
import BookingPageComponent from "./components/BookingPageComponent.vue";
import BookingInfoComponent from "./components/BookingInfoComponent.vue";
import RegistrationComponent from "./components/RegistrationComponent.vue";
import HotelsControlPageComponent from "./components/HotelsControlPageComponent.vue";
import CreateHotelComponent from "./components/CreateHotelComponent.vue";
import HotelRoomsControl from "./components/HotelRoomsControlController.vue";
import CreateRoomComponent from "./components/CreateRoomComponent.vue";
import RoomInfoComponent from "./components/RoomInfoComponent.vue";

const routes = [
  {
    path: "/",
    component: LoginComponent,
    name: "login",
    meta: { layout: "empty" }
  },
  {
    path: "/registration",
    component: RegistrationComponent,
    name: "registration",
    meta: { layout: "empty" }
  },
  {
    path: "/profile",
    component: ProfileComponent,
    name: "profile",
    meta: { layout: "navbarOnly" }
  },
  {
    path: "/search",
    component: SearchComponent,
    name: "search",
    meta: { layout: "navbarOnly" }
  },
  {
    path: "/mainpage",
    component: MainPageComponent,
    name: "mainpage",
    meta: { layout: "navbarOnly" }
  },
  {
    path: "/hotelinfo/:id", // Добавлен параметр id
    component: HotelInfoComponent,
    name: "hotelinfo",
    meta: { layout: "user" }
  },
  {
    path: "/bookinginfo/:id", // Если требуется параметр id
    component: BookingInfoComponent,
    name: "bookinginfo",
    meta: { layout: "user" }
  },
  {
    path: "/bookingpage/:id", // Если требуется параметр id
    component: BookingPageComponent,
    name: "bookingpage",
    meta: { layout: "user" }
  },
  {
    path: "/hotelsControlPage",
    component: HotelsControlPageComponent,
    name: "hotelsControlPage",
    meta: { layout: "empty" }
  },
  {
    path: "/createHotel/:id?",
    component: CreateHotelComponent,
    name: "createHotel",
    meta: { layout: "topBarOnly" },
    props: true
  },
  {
    path: "/roomControl/:id",
    component: HotelRoomsControl, // Предполагаемый компонент для информации о номере
    name: "roomControl",
    meta: { layout: "topBarOnly" },
    props: true
  },
  {
    path: "/roomControl/:hotelId/createRoom/:roomId?",
    component: CreateRoomComponent, // Предполагаемый компонент для информации о номере
    name: "createRoom",
    meta: { layout: "topBarOnly" },
    props: true
  },
  {
    path: "/roomControl/:hotelId/:roomId?",
    component: RoomInfoComponent, // Предполагаемый компонент для информации о номере
    name: "roomInfo",
    meta: { layout: "topBarOnly" },
    props: true
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

router.goTo = function(path) {
  this.push(path);
};

router.goBack = () => {
  try {
    if (window.history.length > 1) {
      router.go(-1);
    } else {
      router.push("/");
    }
  } catch (error) {
    console.error("Navigation error:", error);
    router.push("/");
  }
};

export default router;
