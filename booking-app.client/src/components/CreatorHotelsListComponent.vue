<template>
    <div class="hotelList">
        <div v-if="!hotels.length" class="noResults">
            Вы пока не создали ни одного отеля.
        </div>
        <div class="items" v-else>
            <div v-for="hotel in hotels" :key="hotel.id" class="item">
                <Image :src="hotel.picture" width="128" />
                <div class="info">
                    <p class="hotelName">{{ hotel.name }}</p>
                    <p class="location">{{ hotel.country }}, {{ hotel.city }}</p>
                    <Button class="button" label="Изменить информацию" @click="goToEditHotel(hotel.id)" />
                    <Button class="button" label="Управление номерами" @click="goToRoomControl(hotel.id)" />
                </div>
            </div>
        </div>
    </div>
</template>

<script setup>
import { ref, inject, onMounted } from 'vue';
import { Button } from 'primevue';
import { useRouter } from 'vue-router';
import Image from 'primevue/image';


const hotels = ref([]); // Состояние для хранения списка отелей
const router = useRouter();
const globalVar = inject('globalVar')

// Функция для получения данных с сервера
async function fetchHotels() {
    try {
        const url = `${globalVar.apiUrl}/Hotels/GetHotelsByCreatorId`

        const response = await fetch(url, {
            credentials: "include",
            method: 'GET',
            headers: {
                'Content-Type': 'application/json'
            },
        });


        if (response.status != 404 && response.status != 200) {
            throw new Error(`Ошибка HTTP: ${response.status}`);
        }
        const data = await response.json();

        hotels.value = data;
        console.log(hotels.value)
    } catch (error) {
        console.error('Ошибка при загрузке отелей:', error);
        hotels.value = []; // Очищаем список отелей в случае ошибки
    }
}

function goToEditHotel(hotelId) {
    console.log(hotelId)
    router.push({ name: 'createHotel', params: { id: hotelId } });
}

// Переход на страницу информации об отеле
function goToRoomControl(hotelId) {
    console.log(hotelId)
    router.push({ name: 'roomControl', params: { id: hotelId } });
}

onMounted(fetchHotels)
</script>


<style>
.hotelList {
    display: flex;
    flex-direction: column;
    align-items: flex-start;
    width: 100%;
    height: auto;
    /* Убираем фиксированную высоту, чтобы контейнер подстраивался под контент */
}

.hotelList .items {
    display: flex;
    flex-direction: column;
    align-items: center;
    width: 100%;
    height: auto;
    /* Убираем фиксированную высоту, чтобы контейнер подстраивался под контент */
}

.hotelList .items .item {
    display: flex;
    flex-direction: row;
    /* Переводим в ряд для мобильных устройств */
    grid-gap: 10px;
    justify-items: center;
    align-items: center;
    width: 100%;
    /* Делает каждый элемент растягивающимся по ширине */
}

.hotelList .items .item .image {
    width: 100%;
    /* Сделаем изображения адаптивными */
    max-width: 200px;
    height: auto;
    /* Ограничим максимальную ширину */
    margin: 0 auto;
    display: block;
}

.hotelList .items .item .info {
    gap: 3px;
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: flex-start;
}

.hotelList .items .item .info .hotelName {
    font-size: 1.0rem;
    /* Используем относительные единицы для адаптивности */
    font-weight: 600;
}


.hotelList .items .item .info .location {
    font-size: 0.9rem;
    color: #777;
}

.hotelList .items .item .info .button {
    font-size: 0.7rem;
    width: 170px;
    height: 30px
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