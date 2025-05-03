<template>
    <div class="hotelInfo" v-if="hotel">
        <div class="mainInfo">
            <Image :src="hotel.pictureLinks[0]" preview width="256" />
            <div class="info">
                <p class="name">{{ hotel.name }}</p>
                <p class="location">{{ hotel.city }}, {{ hotel.country }}</p>
                <Button label="Забронировать номер" @click="goToBookingPage(hotel.id)" />
            </div>
        </div>

        <div class="description">
            <p class="header">Описание</p>
            <p class="content">{{ hotel.description }}</p>
        </div>

        <div class="tags" v-if="hotel.tags.length">
            <Tag v-for="(tag, index) in hotel.tags" :key="index" :value="tag" />
        </div>

        <div class="pictures">
            <p class="header">Фотографии</p>
            <div class="content">
                <Image v-for="(picture, index) in hotel.pictureLinks" :key="index" :src="picture" preview width="150" />
            </div>
        </div>
        <Reviews></Reviews>
        <Navbar />
    </div>

    <div v-else>
        <p>Загрузка данных об отеле...</p>
    </div>
</template>

<script setup>
import { ref, onMounted } from 'vue';
import Button from 'primevue/button';
import Tag from 'primevue/tag';
import Image from 'primevue/image';
import Navbar from './NavbarComponent.vue';
import { useRouter, useRoute } from 'vue-router';
import Reviews from './ReviewListComponent.vue'

const router = useRouter();
const route = useRoute();
const hotel = ref(null);

async function fetchHotelData() {
    try {
        const hotelId = route.params.id; // Предполагаем, что ID передаётся в параметрах маршрута
        const response = await fetch(`https://localhost:7273/api/Hotels/${hotelId}`);
        console.log(`https://localhost:7273/api/Hotels/${hotelId}`)
        if (!response.ok) throw new Error('Ошибка при загрузке данных');
        hotel.value = await response.json();
    } catch (error) {
        console.error('Ошибка:', error);
    }
}

function goToBookingPage(hotelId) {
    router.push({ name: 'bookingpage', params: { id: hotelId } });
}

// Загружаем данные при монтировании компонента
onMounted(fetchHotelData);
</script>

<style>
.hotelInfo {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
}

.hotelInfo .mainInfo {
    display: flex;
    flex-direction: column;
    align-items: flex-start;
    margin-bottom: 20px;
}

.hotelInfo .mainInfo .info {
    display: flex;
    flex-direction: column;
    margin-left: 0;
    margin-top: 10px;
}

.hotelInfo .mainInfo .name {
    font-size: 1.5rem;
    /* Используем относительный размер */
    font-weight: 600;
}

.hotelInfo .mainInfo .location {
    font-size: 1rem;
    color: #777;
}

.hotelInfo .description {
    display: flex;
    flex-direction: column;
    margin-bottom: 20px;
}

.hotelInfo .description .header {
    font-size: 1rem;
    font-weight: 600;
}

.hotelInfo .description .content {
    font-size: 1rem;
    width: 100%;
    /* Убираем фиксированную ширину для гибкости */
    max-width: 350px;
}

.hotelInfo .tags {
    display: grid;
    grid-auto-flow: column;
    grid-column-gap: 10px;
    align-items: center;
    justify-content: center;
    margin: 10px;
}

.hotelInfo .pictures {
    display: flex;
    flex-direction: column;
    margin: 10px;
}

.hotelInfo .pictures .header {
    font-size: 1rem;
    font-weight: 600;
}

.hotelInfo .pictures .content {
    display: grid;
    grid-column-gap: 10px;
    grid-row-gap: 10px;
    grid-template-columns: repeat(2, 150px);
    align-items: center;
    justify-content: center;
    margin: 10px;
}

/* Медиазапросы для более крупных экранов */
@media (min-width: 600px) {
    .hotelInfo .mainInfo {
        flex-direction: row;
        /* Меняем расположение на экранах шире 600px */
    }

    .hotelInfo .mainInfo .info {
        margin-left: 10px;
    }

    .hotelInfo .description .content {
        width: 100%;
        /* Ширина текста на экранах больше 600px */
    }

    .hotelInfo .pictures .content {
        grid-template-columns: repeat(3, 150px);
        /* Увеличиваем количество столбцов */
    }
}

/* Для экрана больше 1024px */
@media (min-width: 1024px) {
    .hotelInfo .mainInfo .name {
        font-size: 2rem;
        /* Увеличиваем шрифт для больших экранов */
    }

    .hotelInfo .mainInfo .location {
        font-size: 1.2rem;
    }

    .hotelInfo .description .header {
        font-size: 1.2rem;
    }

    .hotelInfo .tags {
        grid-template-columns: repeat(4, auto);
        /* Используем больше колонок для тегов */
    }

    .hotelInfo .pictures .content {
        grid-template-columns: repeat(4, 1fr);
        /* Для больших экранов показываем больше картинок в строке */
    }
}
</style>