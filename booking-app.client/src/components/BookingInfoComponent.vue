<template>
    <div class="bookingInfo" v-if="order">
        <div class="hotelInfo">
            <Image :src="order.hotel.picture" preview width="256" />
            <div class="info">
                <p> {{ order.hotel.name }}</p>
                <p>{{ order.hotel.country }}, {{ order.hotel.city }} </p>
                <Button v-if="order.paymentStatus != 1" label="Оплатить" @click="pay"></Button>
                <Button label="Отменить бронирование" @click="cancelOrder"></Button>
            </div>
        </div>

        <div class="orderInfo">
            <p>Дата прибытия: {{ formatDate(order.arrivalDate) }}</p>
            <p>Дата отбытия: {{ formatDate(order.departureDate) }}</p>
            <p>Цена: {{ order.totalPrice }} ₽</p>
            <p>Дата оформления заказа: {{ formatDate(order.orderTime) }}</p>
            <p>Количество проживающих</p>
            <p>Взрослых: {{ order.adultsAmount }}</p>
            <p>Детей: {{ order.childrenAmount }}</p>
            <p>Статус: {{ PaymentStatusMapper[order.paymentStatus] }}</p>
        </div>
        <Navbar></Navbar>
    </div>

    <div v-else>
        <p>Загрузка данных о заказе... </p>
    </div>
</template>

<script setup>
import Button from 'primevue/button';
import Image from 'primevue/image';
import Navbar from './NavbarComponent.vue';
import { onMounted, ref } from 'vue';
import { checkAuth } from '@/plugins/userStatePlugin';
import router from '@/router';
import { useRoute } from 'vue-router';

var order = ref(null)
var userData = checkAuth()
const route = useRoute();

const PaymentStatusMapper = {
    0: 'Ожидает оплаты',
    1: 'Оплачен'
};

async function fetchOrder() {
    const auth = await checkAuth()
    if (!auth.isAuthorized) goToLogin()
    else {
        userData = auth
        try {
            const orderId = route.params.id;
            const url = `https://localhost:7273/api/Orders/GetOrderById_${orderId}`
            console.log(url)

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
            order.value = data;
            console.log(order.value)
        } catch (error) {
            console.error('Ошибка при загрузке отелей:', error);
        }
    }
}

async function cancelOrder() {
    try {
        const orderId = route.params.id;
        const url = `https://localhost:7273/api/Orders/${orderId}`

        const response = await fetch(url, {
            method: 'DELETE',
            headers: {
                'Content-Type': 'application/json'
            },
        });


        if (response.status != 404 && response.status != 204) {
            throw new Error(`Ошибка HTTP: ${response.status}`);
        }

        if (response.ok) goToProfile()
    } catch (error) {
        console.error('Не удалось удалить бронь:', error);
    }
}

async function pay() {
    try {
        const orderId = route.params.id;
        const url = `https://localhost:7273/api/Orders/PayForOrder_${orderId}`
        console.log(url)

        const response = await fetch(url, {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json'
            },
        });

        if (response.ok) goToProfile()


        if (response.status != 404 && response.status != 200) {
            throw new Error(`Ошибка HTTP: ${response.status}`);
        }
    } catch (error) {
        console.error('Не удалось оплатить бронь:', error);
    }
}

function formatDate(isoDate) {
    let date = new Date(isoDate);
    let day = date.getDate().toString().padStart(2, '0'); // Добавляем ведущий ноль, если день меньше 10
    let month = (date.getMonth() + 1).toString().padStart(2, '0'); // Добавляем ведущий ноль, если месяц меньше 10
    let year = date.getFullYear();
    return `${day}.${month}.${year}`;
}

function goToProfile() {
    router.push({ name: 'profile' });
}

function goToLogin() {
    router.push({ name: 'login' });
}

onMounted(fetchOrder)
</script>

<style>
.bookingInfo {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
}

.bookingInfo .hotelInfo {
    display: flex;
    flex-direction: column;
    margin-bottom: 20px;

}

.bookingInfo .hotelInfo .info {
    display: flex;
    flex-direction: column;
    margin-left: 0;
    margin-top: 10px;
    row-gap: 10px;
}

.bookingInfo .hotelInfo .name {
    font-size: 1.5rem;
    /* Используем относительный размер шрифта */
    font-weight: 600;
}

.bookingInfo .hotelInfo .location {
    font-size: 1rem;
    color: #777;
}

.bookingInfo .orderInfo {
    margin-top: 15px;
    display: flex;
    flex-direction: column;
    gap: 10px;
}

/* Медиазапросы для более крупных экранов */
@media (min-width: 600px) {
    .bookingInfo .hotelInfo {
        flex-direction: row;
        /* На экранах шире 600px используем горизонтальную компоновку */
    }

    .bookingInfo .hotelInfo .info {
        margin-left: 10px;
    }

    .bookingInfo .hotelInfo .name {
        font-size: 1.8rem;
        /* Увеличиваем размер шрифта */
    }

    .bookingInfo .hotelInfo .location {
        font-size: 1.2rem;
    }
}

@media (min-width: 1024px) {
    .bookingInfo .hotelInfo .name {
        font-size: 2rem;
        /* Для больших экранов ещё больше увеличиваем шрифт */
    }

    .bookingInfo .hotelInfo .location {
        font-size: 1.4rem;
    }
}
</style>