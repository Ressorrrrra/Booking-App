<template>
    <div class="mainPage">
        <RecentHotels></RecentHotels>
        <p class="header">Популярные направления</p>
        <ScrollPanel>
            <HotelList class="hotelList"></HotelList>
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
}

.mainPage .header {
    font-size: 24px;
    font-weight: 600;
}
</style>