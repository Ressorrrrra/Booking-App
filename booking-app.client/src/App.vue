<script setup>
import { computed } from 'vue';
import { useRoute } from 'vue-router';
import EmptyLayout from './layouts/EmptyLayout.vue';
import UserLayout from './layouts/UserLayout.vue';
import TopBarOnly from './layouts/TopBarOnlyLayout.vue';
import NavbarOnly from './layouts/NavbarOnlyLayout.vue';

const route = useRoute();
const layout = computed(() => route.meta.layout || 'empty');
const layouts = {
  user: UserLayout,
  empty: EmptyLayout,
  topBarOnly: TopBarOnly,
  navbarOnly: NavbarOnly,
};
</script>

<template>
  <component :is="layouts[layout]">
    <router-view />
  </component>
</template>

<style>
/* Глобальные стили для всего приложения */
html,
body {
  height: 100%;
  margin: 0;
  padding: 0;
  background-color: #c0f5f2; /* Установим такой же цвет, как у #app */
}

#app {
  min-height: 100vh; /* Гарантирует, что #app занимает всю высоту экрана */
  background-color: #c0f5f2; /* Светло-бирюзовый фон */
  display: flex;
  flex-direction: column;
}

:root {
  --primary-color: #20B2AA;
  --secondary-color: #008B8B;
  --surface-ground: #c0f5f2; /* Синхронизируем с фоном приложения */
}

/* Убедимся, что компоненты PrimeVue не переопределяют фон */
.p-component {
  background-color: transparent;
}
</style>