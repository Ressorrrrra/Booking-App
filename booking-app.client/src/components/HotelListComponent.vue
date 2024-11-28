<template>
    <div class="hotelList">
        <div v-for="hotel in hotels" :key="hotel.id" class="item">
            <Image :src="hotel.pictureLinks[0]" width="150" height="110" />
            <div class="info">
                <p class="hotelName">{{ hotel.name }}</p>
                <p class="price">От {{ hotel.price }}₽ за ночь</p>
                <p class="location">{{ hotel.country }}, {{ hotel.city }}</p>
                <Button label="Забронировать номер" @click="goToHotelInfo(hotel.id)">
                </Button>
            </div>
        </div>
    </div>
</template>

<script setup>
import { ref, onMounted } from 'vue';
import { Button } from 'primevue';
import { useRouter } from 'vue-router';
import Image from 'primevue/image';

const hotels = ref([]); // Состояние для хранения списка отелей
const router = useRouter();

// Функция для получения данных с бэкенда
async function fetchHotels() {
    try {
        const response = await fetch('https://localhost:7273/api/Hotels', {
            method: 'GET', // Указываем HTTP-метод
            headers: {
                'Content-Type': 'application/json' // Заголовки, если нужны
            }
        });

        if (!response.ok) {
            throw new Error(`Ошибка HTTP: ${response.status}`);
        }

        const data = await response.json();
        hotels.value = data;
    } catch (error) {
        console.error('Ошибка при загрузке отелей:', error);
    }
}

// Переход на страницу информации об отеле
function goToHotelInfo(hotelId) {
    router.push({ name: 'hotelinfo', params: { id: hotelId } });
}

// Загружаем данные при монтировании компонента
onMounted(() => {
    fetchHotels();
});
</script>

<style>
.hotelList {
    display: flex;
    flex-direction: column;
    align-items: flex-start;
    width: 100%;
    height: auto;
    /* Убираем фиксированную высоту, чтобы контейнер подстраивался под контент */
    padding: 10px;
}

.hotelList .item {
    margin: 10px;
    display: grid;
    grid-auto-flow: row;
    /* Переводим в ряд для мобильных устройств */
    grid-gap: 10px;
    justify-items: center;
    align-items: center;
    width: 100%;
    /* Делает каждый элемент растягивающимся по ширине */
}

.hotelList .item .image {
    width: 100%;
    /* Сделаем изображения адаптивными */
    max-width: 300px;
    /* Ограничим максимальную ширину */
    margin: 0 auto;
    display: block;
}

.bookingHistory .item .info {
    margin: 10px;
    margin-left: 0;
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: flex-start;
}

.bookingHistory .item .info .hotelName {
    font-size: 1.2rem;
    /* Используем относительные единицы для адаптивности */
    font-weight: 600;
}

.bookingHistory .item .info .price {
    font-size: 1rem;
    /* Также используем относительные единицы */
    font-weight: 500;
}

.bookingHistory .item .info .location {
    font-size: 0.9rem;
    color: #777;
}

/* Медиазапросы для мобильных устройств */
@media (max-width: 600px) {
    .hotelList .item {
        grid-template-columns: 1fr;
        /* Строки, а не колонки на маленьких экранах */
    }

    .hotelList .item .image {
        max-width: 100%;
        /* На мобильных устройствах изображение будет растягиваться */
        margin: 0;
    }

    .bookingHistory .item .info {
        align-items: flex-start;
        margin-left: 0;
        /* Убираем отступ слева на маленьких экранах */
    }
}

/* Медиазапросы для планшетов и экранов больше 600px */
@media (min-width: 600px) {
    .hotelList .item {
        grid-template-columns: 1fr 1fr;
        /* Два элемента в строке на экранах больше 600px */
    }

    .hotelList .item .image {
        max-width: 50%;
        /* Ограничиваем максимальную ширину изображения */
    }
}

/* Для экранов шириной больше 1024px */
@media (min-width: 1024px) {
    .hotelList .item {
        grid-template-columns: 1fr 1fr 1fr;
        /* Три элемента в строке */
    }

    .hotelList .item .image {
        max-width: 100%;
        /* Изображения для больших экранов */
    }

    .bookingHistory .item .info {
        margin-left: 20px;
        /* Добавляем отступы для большего экрана */
    }

    .bookingHistory .item .info .hotelName {
        font-size: 1.5rem;
        /* Увеличиваем размер шрифта для названия отеля */
    }

    .bookingHistory .item .info .price {
        font-size: 1.2rem;
    }

    .bookingHistory .item .info .location {
        font-size: 1rem;
    }
}
</style>