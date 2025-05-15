<template>
    <div class="hotelList">
        <div v-if="!hotels.length" class="noResults">
            Ничего не найдено по вашему запросу
        </div>
        <div v-else>
            <div v-for="hotel in hotels" :key="hotel.id" class="item">
                <Image :src="hotel.picture" width="128" height="110" />
                <div class="info">
                    <p class="hotelName">{{ hotel.name }}</p>
                    <p class="price">От {{ hotel.price }}₽ за ночь</p>
                    <p class="location">{{ hotel.country }}, {{ hotel.city }}</p>
                    <Button class="button" label="Забронировать номер" @click="goToHotelInfo(hotel.id)" />
                </div>
            </div>
        </div>
    </div>
</template>

<script setup>
import { ref, watch, inject } from 'vue';
import { Button } from 'primevue';
import { useRouter } from 'vue-router';
import Image from 'primevue/image';

// Проп с критериями поиска (может быть null или объектом с параметрами поиска)
const props = defineProps({
    criteria: {
        type: Object,
        default: () => null
    }
});

const hotels = ref([]); // Состояние для хранения списка отелей
const router = useRouter();
const globalVar = inject('globalVar')

// Функция для получения данных с сервера
async function fetchHotels(searchCriteria) {
    try {
        const url = searchCriteria ? `${globalVar.apiUrl}/Hotels/SearchHotels` :
            `${globalVar.apiUrl}/Hotels/GetHotelsDTO`;


        const response = await fetch(url, {
            method: searchCriteria ? 'POST' : 'GET', // Метод POST для поиска, GET для всех
            headers: {
                'Content-Type': 'application/json'
            },
            body: searchCriteria ? JSON.stringify(searchCriteria) : null
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

// Переход на страницу информации об отеле
function goToHotelInfo(hotelId) {
    router.push({ name: 'hotelinfo', params: { id: hotelId } });
}

// Обновление данных при изменении критерия поиска
watch(
    () => props.criteria, // Доступ к критериям через props
    (newCriteria) => {
        console.log('Критерии поиска изменились:', newCriteria);
        fetchHotels(newCriteria);
    },
    { immediate: true }
);
</script>


<style>
.hotelList {
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    width: 100%;
    height: auto;
    /* Убираем фиксированную высоту, чтобы контейнер подстраивался под контент */
    padding: 10px;
}

.hotelList .item {
    margin: 10px;
    display: flex;
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

.hotelList .item .info {
    margin: 10px;
    margin-left: 0;
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: flex-start;
}

.hotelList .item .info .hotelName {
    font-size: 1.0rem;
    /* Используем относительные единицы для адаптивности */
    font-weight: 600;
}

.hotelList .item .info .price {
    font-size: 1rem;
    /* Также используем относительные единицы */
}

.hotelList .item .info .location {
    font-size: 0.9rem;
}

.hotelList .item .info .button {
    font-size: 0.7rem;
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

    .hotelList .item .info {
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

    .hotelList .item .info {
        margin-left: 20px;
        /* Добавляем отступы для большего экрана */
    }

    .hotelList .item .info .hotelName {
        font-size: 1.5rem;
        /* Увеличиваем размер шрифта для названия отеля */
    }

    .hotelList .item .info .price {
        font-size: 1.2rem;
    }

    .hotelList .item .info .location {
        font-size: 1rem;
    }
}
</style>