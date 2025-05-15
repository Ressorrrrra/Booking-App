<template>
    <div class="bookingsList">
        <div v-if="!bookings.length" class="noBookings">
            Нет предстоящих броней для этого номера.
        </div>
        <div v-else>
            <div v-for="booking in bookings" :key="booking.id" class="bookingItem">
                <p><strong>Дата начала:</strong> {{ formatDate(booking.startDate) }}</p>
                <p><strong>Дата окончания:</strong> {{ formatDate(booking.endDate) }}</p>
                <Button label="Отменить" severity="danger" @click="cancelBooking(booking.id)" />
            </div>
        </div>
    </div>
</template>

<script setup>
import { Button } from 'primevue';
import { defineProps } from 'vue';

// Props
const props = defineProps({
    bookings: {
        type: Array,
        default: () => []
    }
});

async function cancelBooking(id) {

}

function formatDate(dateString) {
    const date = new Date(dateString);
    return date.toLocaleDateString('ru-RU', {
        day: '2-digit',
        month: '2-digit',
        year: 'numeric'
    });
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