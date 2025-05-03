<template>
    <div class="hotelList">
        <div v-if="!orders.length" class="noResults">
            У вас нет бронирований
        </div>
        <div v-else>
            <div v-for="order in orders" :key="order.id" class="item">
                <Image :src="order.hotel.picture" width="190" />

                <div class="info">
                    <p class="hotelName">{{ order.hotel.name }}</p>
                    <p>{{ formatDate(order.arrivalDate) }} - {{ formatDate(order.departureDate) }}</p>
                    <p> {{ order.OrderStatus }}</p>
                    <Button type="bookingInfo" severity="secondary" label="Информация о заказе"
                        @click="goToBookingInfo(order.id)">
                    </Button>
                    <Button label="Оставить отзыв" @click="openModal(order)" />
                </div>
            </div>

            <Dialog v-model:visible="displayModal" :style="{ width: '500px' }" header="Оставить отзыв" :modal="true">

                <ReviewModal :order="selectedOrder" />

                <template #footer>
                    <Button label="Отмена" icon="pi pi-times" @click="closeModal" class="p-button-text" />
                    <Button label="Отправить" icon="pi pi-check" @click="submitReview" :disabled="!isFormValid" />
                </template>

            </Dialog>
        </div>
    </div>
</template>

<script setup>
import { onMounted, ref } from 'vue';
import { Button } from 'primevue';
import { useRouter } from 'vue-router';
import Image from 'primevue/image';
import { checkAuth } from '@/plugins/userStatePlugin';
import ReviewModal from './ReviewModalComponent.vue';


const selectedOrder = ref({ /* данные брониы*/ });

const isVisible = ref(false);
const reviewForm = ref(null);

const orders = ref([]); // Состояние для хранения списка бронирований
const router = useRouter();
var userData = checkAuth()

// Функция для получения данных с сервера
async function fetchOrders() {
    const auth = await checkAuth()
    if (!auth.isAuthorized) goToLogin()
    else {
        userData = auth
        try {
            const url = `https://localhost:7273/api/Orders/GetUserOrders_${userData.id}`


            const response = await fetch(url, {
                method: 'GET',
                headers: {
                    'Content-Type': 'application/json'
                },
            });


            if (response.status != 404 && response.status != 200) {
                throw new Error(`Ошибка HTTP: ${response.status}`);
            }
            const data = await response.json();
            orders.value = data;
            console.log(orders.value)
        } catch (error) {
            console.error('Ошибка при загрузке отелей:', error);
            orders.value = [];
        }
    }
}

// Переход на страницу информации об отеле
function goToBookingInfo(orderId) {
    router.push({ name: 'bookinginfo', params: { id: orderId } });
}

function goToLogin() {
    router.push({ name: 'login' });
}

const openModal = async (order) => {
    // Загрузка данных (пример)
    selectedOrder.value = order
    isVisible.value = true;
};

const closeModal = () => {
    isVisible.value = false;
};

const submitReview = async () => {
    if (!reviewForm.value) return;

    const formData = {
        ...reviewForm.value.form,
    };

    await fetch('/api/Orders', {
        method: 'POST',
        body: formData
    });

    closeModal();
};


// Обновление данных при изменении критерия поиска
onMounted(fetchOrders)

function formatDate(isoDate) {
    let date = new Date(isoDate);
    let day = date.getDate().toString().padStart(2, '0'); // Добавляем ведущий ноль, если день меньше 10
    let month = (date.getMonth() + 1).toString().padStart(2, '0'); // Добавляем ведущий ноль, если месяц меньше 10
    let year = date.getFullYear();
    return `${day}.${month}.${year}`;
}
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