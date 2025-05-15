<template>
    <div class="roomInfo">
        <h2>Информация о номере</h2>
        <div class="roomDetails">
            <p><strong>Номер комнаты:</strong> {{ room?.number || 'Загрузка...' }}</p>
            <p><strong>Вместимость:</strong> {{ room?.capacity || 'N/A' }} человек(-а)</p>
            <p><strong>Цена за ночь:</strong> {{ room?.price || 0 }} руб.</p>
        </div>

        <!-- Close Room Section -->
        <h3>Закрыть номер</h3>
        <div class="closeRoomSection">
            <FloatLabel variant="on">
                <Calendar v-model="closeStartDate" dateFormat="dd.mm.yy" showIcon />
                <label>Дата начала</label>
            </FloatLabel>
            <FloatLabel variant="on">
                <Calendar v-model="closeEndDate" dateFormat="dd.mm.yy" showIcon />
                <label>Дата окончания</label>
            </FloatLabel>
            <Button label="Закрыть комнату" @click="closeRoom" :disabled="!closeStartDate || !closeEndDate" />
        </div>

        <!-- Bookings List -->
        <h3>Ближайшие брони</h3>
        <RoomBookingsList :bookings="bookings" @cancel-booking="cancelBooking" />
    </div>
</template>

<script setup>
import { ref, onMounted, inject } from 'vue';
import { useRouter, useRoute } from 'vue-router';
import { FloatLabel, Calendar, Button } from 'primevue';
import RoomBookingsList from './RoomBookingsListComponent.vue'; 

const route = useRoute();
const router = useRouter();
const globalVar = inject('globalVar');

const hotelId = ref(route.params.id);
const roomId = ref(route.params.roomId);
const room = ref(null);
const bookings = ref([]);
const closeStartDate = ref(null);
const closeEndDate = ref(null);

// Fetch room details
async function fetchRoomDetails() {
    try {
        const response = await fetch(`${globalVar.apiUrl}/Hotels/${hotelId.value}/Rooms/${roomId.value}`, {
            credentials: 'include'
        });
        if (!response.ok) {
            throw new Error(`Ошибка HTTP: ${response.status}`);
        }
        room.value = await response.json();
        console.log(room.value)
    } catch (error) {
        console.error('Ошибка при загрузке информации о комнате:', error);
    }
}

async function fetchBookings() {
    try {
        const response = await fetch(`${globalVar.apiUrl}/Hotels/${hotelId.value}/Rooms/${roomId.value}/Bookings`, {
            credentials: 'include'
        });
        if (!response.ok) {
            throw new Error(`Ошибка HTTP: ${response.status}`);
        }
        const data = await response.json();
        // Filter for upcoming bookings (assuming booking has a startDate)
        bookings.value = data.filter(booking => new Date(booking.startDate) >= new Date());
    } catch (error) {
        console.error('Ошибка при загрузке броней:', error);
        bookings.value = [];
    }
}

// Close the room by creating a special booking
async function closeRoom() {
    try {
        const response = await fetch(`${globalVar.apiUrl}/Hotels/${hotelId.value}/Rooms/${roomId.value}/Bookings`, {
            credentials: 'include',
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                startDate: closeStartDate.value.toISOString(),
                endDate: closeEndDate.value.toISOString(),
                status: 'CLOSED' // Special status to indicate the room is closed
            })
        });
        if (!response.ok) {
            throw new Error(`Ошибка HTTP: ${response.status}`);
        }
        alert('Комната успешно закрыта на указанный период.');
        closeStartDate.value = null;
        closeEndDate.value = null;
        fetchBookings(); // Refresh the bookings list
    } catch (error) {
        console.error('Ошибка при закрытии комнаты:', error);
        alert('Не удалось закрыть комнату. Попробуйте снова.');
    }
}

// Cancel a booking
async function cancelBooking(bookingId) {
    try {
        const response = await fetch(`${globalVar.apiUrl}/Hotels/${hotelId.value}/Rooms/${roomId.value}/Bookings/${bookingId}`, {
            credentials: 'include',
            method: 'DELETE'
        });
        if (!response.ok) {
            throw new Error(`Ошибка HTTP: ${response.status}`);
        }
        alert('Бронь успешно отменена.');
        fetchBookings(); // Refresh the bookings list
    } catch (error) {
        console.error('Ошибка при отмене брони:', error);
        alert('Не удалось отменить бронь. Попробуйте снова.');
    }
}

// Load data on mount
onMounted(() => {
    fetchRoomDetails();
    fetchBookings();
});
</script>

<style scoped>
.roomInfo {
    display: flex;
    flex-direction: column;
    align-items: center;
    padding: 20px;
    max-width: 800px;
    margin: 0 auto;
}

.roomDetails {
    width: 100%;
    padding: 15px;
    background-color: #f9f9f9;
    border-radius: 8px;
    margin-bottom: 20px;
}

.roomDetails p {
    margin: 5px 0;
    font-size: 1.1rem;
}

.closeRoomSection {
    display: flex;
    gap: 15px;
    flex-wrap: wrap;
    margin-bottom: 20px;
    align-items:  center;
    justify-content: center;
}

h2, h3 {
    color: #333;
    margin-bottom: 10px;
}
</style>