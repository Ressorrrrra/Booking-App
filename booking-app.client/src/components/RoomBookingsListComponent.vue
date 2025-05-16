<template>
    <div class="bookingsList">
        <div v-if="!orders.length" class="noBookings">
            Нет предстоящих броней для этого номера.
        </div>
        <div v-else>
            <div v-for="order in orders" :key="order.id" class="bookingItem">
                <p><strong>Дата прибытия:</strong> {{ formatDate(order.arrivalDate) }}</p>
                <p><strong>Дата отбытия:</strong> {{ formatDate(order.departureDate) }}</p>
            </div>
        </div>
    </div>
</template>

<script setup>
import { defineProps, ref, inject } from 'vue';
import { onMounted } from 'vue';

const orders = ref([])
const globalVar = inject('globalVar');

// Props
const props = defineProps({
    roomId: {
        type: String,
        default: () => '0'
    },
    hotelId: {
        type: String,
        default: () => '0'
    },
});

async function cancelBooking(id) {
}

function check() {
    console.log(props)
}

onMounted(fetchOrders)

function formatDate(isoDate) {
    let date = new Date(isoDate);
    let day = date.getDate().toString().padStart(2, '0'); // Добавляем ведущий ноль, если день меньше 10
    let month = (date.getMonth() + 1).toString().padStart(2, '0'); // Добавляем ведущий ноль, если месяц меньше 10
    let year = date.getFullYear();
    return `${day}.${month}.${year}`;
}

async function fetchOrders() {
    try {
        console.log(`${globalVar.apiUrl}/Hotels/${props.hotelId}/Rooms/${props.roomId}/GetRoomOrders`)
        const response = await fetch(`${globalVar.apiUrl}/Hotels/${props.hotelId}/Rooms/${props.roomId}/GetRoomOrders`, {
            credentials: 'include'
        });
        if (!response.ok) {
            throw new Error(`Ошибка HTTP: ${response.status}`);
        }
        const data = await response.json();

        orders.value = data;
        console.log(orders)
    } catch (error) {
        console.error('Ошибка при загрузке броней:', error);
        orders.value = [];
    }
}
</script>

<style scoped>
.bookingsList {
    width: 100%;
    padding: 10px;
}

.noBookings {
    font-size: 1rem;
    color: #777;
    margin: 20px 0;
    text-align: center;
}

.bookingItem {
    display: flex;
    flex-direction: column;
    padding: 15px;
    background-color: #f1f1f1;
    border-radius: 8px;
    margin-bottom: 10px;
    gap: 5px;
}

.bookingItem p {
    margin: 0;
    font-size: 1rem;
}

.bookingItem .p-button {
    align-self: flex-start;
    margin-top: 10px;
}
</style>