<template>
    <div class="mainPage">
        <RecentHotels></RecentHotels>
        <p class="header">Популярные направления</p>
        <ScrollPanel>
            <HotelList></HotelList>
        </ScrollPanel>
        <Navbar class="navbar"></Navbar>
    </div>
</template>

<script setup>
import RecentHotels from './RecentHotelsComponent.vue';
import HotelList from './HotelListComponent.vue';
import Navbar from './NavbarComponent.vue';
import ScrollPanel from 'primevue/scrollpanel';
</script>

<style>
.mainPage {
    display: flex;
    flex-direction: column;
    column-gap: 100px;
    padding: 20px;
    height: auto;

}


.mainPage .header {
    font-size: 1.5rem;
    /* Используем относительные единицы */
    font-weight: 600;
    margin-bottom: 20px;
}


/* Медиазапросы для мобильных устройств */
@media (max-width: 600px) {
    .mainPage {
        column-gap: 20px;
        /* Уменьшаем расстояние между колонками на мобильных устройствах */
        padding: 10px;
        /* Уменьшаем отступы */
    }

    .mainPage .header {
        font-size: 1.2rem;
        /* Уменьшаем размер шрифта заголовка */
        margin-bottom: 10px;
    }
}

/* Для планшетов и экранов больше 600px */
@media (min-width: 600px) {
    .mainPage {
        column-gap: 50px;
        /* Среднее расстояние между колонками для планшетов */
    }
}

/* Для экранов шириной больше 1024px */
@media (min-width: 1024px) {
    .mainPage {
        column-gap: 100px;
        /* Оставляем большое расстояние между колонками для десктопов */
    }

    .mainPage .header {
        font-size: 2rem;
        /* Увеличиваем размер шрифта для десктопов */
    }
}
</style>