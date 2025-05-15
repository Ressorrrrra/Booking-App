<template>
    <div class="reviewList">
        <div v-if="!reviews.length" class="noResults">
            На этот отель ещё нет отзывов
        </div>
        <div v-else>
            <div v-for="review in reviews" :key="review.id" class="item">
                <div class="info">
                    <p class="username">{{ review.username }}</p>
                    <Rating v-model="review.rating" readonly></Rating>
                    <p class="text">{{ review.text }}</p>
                </div>
            </div>
        </div>
    </div>
</template>

<script setup>
import { ref, onMounted, inject } from 'vue';
import { useRoute } from 'vue-router';
import  Rating  from 'primevue/rating';

const reviews = ref([]); // Состояние для хранения списка отелей
const route = useRoute();
const globalVar = inject('globalVar')

// Функция для получения данных с сервера
async function fetchReviews() {
    try {
        const hotelId = route.params.id;
        const response = await fetch(`${globalVar.apiUrl}/Hotels/${hotelId}/reviews`)
        if (!response.ok) throw new Error('Ошибка при загрузке данных');
        const data = await response.json();

        reviews.value = data;
        console.log(reviews)
        console.log(reviews.value)
    } catch (error) {
        console.error('Ошибка при загрузке отзывов:', error);
        reviews.value = []; // Очищаем список отелей в случае ошибки
    }
}

onMounted(fetchReviews)
</script>


<style>
.reviewList {
    display: flex;
    flex-direction: column;
    align-items: flex-start;
    width: 100%;
    height: auto;
    /* Убираем фиксированную высоту, чтобы контейнер подстраивался под контент */
}

.reviewList .item {
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

.reviewList .item .image {
    width: 100%;
    /* Сделаем изображения адаптивными */
    max-width: 300px;
    /* Ограничим максимальную ширину */
    margin: 0 auto;
    display: block;
}

.reviewList .item .info {
    margin: 10px;
    margin-left: 0;
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: flex-start;
}


/* Медиазапросы для мобильных устройств */
@media (max-width: 600px) {
    .reviewList .item {
        grid-template-columns: 1fr;
        /* Строки, а не колонки на маленьких экранах */
    }

    .reviewList .item .image {
        max-width: 100%;
        /* На мобильных устройствах изображение будет растягиваться */
        margin: 0;
    }

    .reviewList .item .info {
        align-items: flex-start;
        margin-left: 0;
        /* Убираем отступ слева на маленьких экранах */
    }
}

/* Медиазапросы для планшетов и экранов больше 600px */
@media (min-width: 600px) {
    .reviewList .item {
        grid-template-columns: 1fr 1fr;
        /* Два элемента в строке на экранах больше 600px */
    }

    .reviewList .item .image {
        max-width: 50%;
        /* Ограничиваем максимальную ширину изображения */
    }
}

/* Для экранов шириной больше 1024px */
@media (min-width: 1024px) {
    .reviewList .item {
        grid-template-columns: 1fr 1fr 1fr;
        /* Три элемента в строке */
    }

    .reviewList .item .image {
        max-width: 100%;
        /* Изображения для больших экранов */
    }

    .reviewList .item .info {
        margin-left: 20px;
        /* Добавляем отступы для большего экрана */
    }
}
</style>