<template>
    <div>
        <div v-if="!orders.length" class="noResults">
            У вас нет бронирований
        </div>
        <div class="orderList" v-else>
            <div v-for="order in orders" :key="order.id" class="item">
                <Image :src="order.hotel.picture" width="128" class="image" />
                <div class="info">
                    <p class="name">{{ order.hotel.name }}</p>
                    <p class="dates">{{ formatDate(order.arrivalDate) }} - {{ formatDate(order.departureDate) }}</p>
                    <Button class="button1" type="bookingInfo" severity="secondary" label="Информация о брони"
                        @click="goToBookingInfo(order.id)">
                    </Button>
                    <Button class="button1" label="Оставить отзыв" @click="openModal(order)" />
                </div>
            </div>

            <Dialog v-model:visible="isVisible" :style="{ height: '50%', width: '90%' }" header="Оставить отзыв"
                :modal="true">
                <ReviewModal ref="reviewForm" :order="selectedOrder" />

                <template #footer>
                    <Button label="Отмена" icon="pi pi-times" @click="closeModal" class="p-button-text" />
                    <Button label="Отправить" icon="pi pi-check" @click="submitReview" :disabled="!isFormValid" />
                </template>
            </Dialog>
        </div>
    </div>
</template>

<script setup>
import { onMounted, ref, computed, inject } from 'vue';
import { Button } from 'primevue';
import { useRouter } from 'vue-router';
import Image from 'primevue/image';
import { checkAuth } from '@/plugins/userStatePlugin';
import ReviewModal from './ReviewModalComponent.vue';
import Dialog from 'primevue/dialog';


const selectedOrder = ref({ /* данные брониы*/ });

const isVisible = ref(false);
const reviewForm = ref(null);
const globalVar = inject('globalVar')

const orders = ref([]); // Состояние для хранения списка бронирований
const router = useRouter();

const isFormValid = computed(() => {
    if (!reviewForm.value) return false;
    return reviewForm.value.form.rating > 0 &&
        reviewForm.value.form.text?.length >= 10;
});

// Функция для получения данных с сервера
async function fetchOrders() {
    const auth = await checkAuth()
    if (!auth.isAuthorized) goToLogin()
    else {
        try {
            const url = `${globalVar.apiUrl}/Orders/GetUserOrders`
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
        orderId: selectedOrder.value.id,
        rating: reviewForm.value.form.rating,
        text: reviewForm.value.form.text
    };

    console.log(formData)
    try {


        const response = await fetch('https://localhost:7273/api/Reviews', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(formData)
        });

        if (response.status != 201 || response.status != 204) {
            throw new Error(`Ошибка HTTP: ${response.status}`);
        }
    } catch (error) {
        console.error('Ошибка при создании отзыва:', error);
    }

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
.orderList {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    width: 100%;
    padding: 30px;
}


.orderList .item {
    display: flex;
    flex-direction: row;
    justify-content: center;
    align-items: center;
}

.orderList .item .image {
    width: 100%;
    max-width: 300px;
    margin-right: 10px;
    display: block;
}

.orderList .item .info {
    margin-left: 10px;
    display: flex;
    gap: 3px;
    flex-direction: column;
    justify-content: center;
    align-items: flex-start;
}

.orderList .item .info .dates {
    font-size: 14px;
}

.orderList .item .info .name {
    font-weight: 600;
}

.orderList .item .info .button1 {
    font-size: 11px;
    width: 150px;
}


/* Медиазапросы для мобильных устройств */
@media (max-width: 600px) {
    .orderList .item {
        grid-template-columns: 1fr;
        /* Строки, а не колонки на маленьких экранах */
    }

    .orderList .item .image {
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
    .orderList .item {
        grid-template-columns: 1fr 1fr;
        /* Два элемента в строке на экранах больше 600px */
    }

    .orderList .item .image {
        max-width: 50%;
        /* Ограничиваем максимальную ширину изображения */
    }
}

/* Для экранов шириной больше 1024px */
@media (min-width: 1024px) {
    .orderList .item {
        grid-template-columns: 1fr 1fr 1fr;
        /* Три элемента в строке */
    }

    .orderList .item .image {
        max-width: 100%;
        /* Изображения для больших экранов */
    }

    .orderList .item .info {
        margin-left: 20px;
        /* Добавляем отступы для большего экрана */
    }
}
</style>