<template>
    <div class="roomsList">
        <p class="header">Управление номерами</p>
        <Button label="Создать номер" @click="router.push({ name: 'createRoom', params: { hotelId } })" />
        <p class="header">Поиск номеров</p>
        <div class="search-section">
            <FloatLabel variant="on">
                <InputNumber v-model="searchCriteria.number" @input="fetchRooms" />
                <label>Номер комнаты</label>
            </FloatLabel>
            <FloatLabel variant="on">
                <InputNumber v-model="searchCriteria.minPrice" mode="currency" currency="RUB" locale="ru-RU"
                    @input="fetchRooms" />
                <label>Минимальная цена</label>
            </FloatLabel>
            <FloatLabel variant="on">
                <InputNumber v-model="searchCriteria.maxPrice" mode="currency" currency="RUB" locale="ru-RU"
                    @input="fetchRooms" />
                <label>Максимальная цена</label>
            </FloatLabel>
        </div>
        <div v-if="!rooms.length" class="noResults">
            Не найдено номеровв по вашему запросу.
        </div>
        <div v-else>
            <div v-for="room in rooms" :key="room.id" class="item">
                <Button class="info" :label="room.number.toString()" rounded severity="secondary"
                    @click="goToRoomInfo(room.id)"></Button>
            </div>
        </div>
    </div>
</template>

<script setup>
import { ref, watch, inject } from 'vue';
import { useRouter, useRoute } from 'vue-router';
import { Button, FloatLabel, InputNumber } from 'primevue';

// Пропсы для критериев поиска
const props = defineProps({
    criteria: {
        type: Object,
        default: () => null
    }
});

const route = useRoute();
const router = useRouter();
const globalVar = inject('globalVar');

const hotelId = ref(route.params.id); // ID отеля из маршрута
const rooms = ref([]); // Список номеров
const searchCriteria = ref({
    number: null,
    minPrice: null,
    maxPrice: null
});

// Получение списка номеров с учетом критериев поиска
async function fetchRooms() {
    try {
        let url = `${globalVar.apiUrl}/Hotels/${hotelId.value}/SearchRooms`;
        const params = new URLSearchParams();

        const response = await fetch(url, {
            credentials: 'include',
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(searchCriteria.value)
        });

        if (response.status !== 200 && response.status !== 404) {
            throw new Error(`Ошибка HTTP: ${response.status}`);
        }

        const data = await response.json();
        rooms.value = data || [];
    } catch (error) {
        console.error('Ошибка при загрузке номеров:', error);
        rooms.value = [];
    }
}

// Переход на страницу информации о номере
function goToRoomInfo(roomId) {
    if (!roomId) {
        console.error('Invalid roomId:', roomId);
        return;
    }
    router.push({ name: 'roomInfo', params: { hotelId, roomId } });
}

// Отслеживание изменений критериев поиска
watch(
    () => searchCriteria.value,
    () => {
        console.log('Search criteria changed:', searchCriteria.value);
        fetchRooms();
    },
    { deep: true, immediate: true }
);
</script>

<style scoped>
.roomsList {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center; /* Center vertically */
    width: 100%;
    gap: 20px;
    min-height: 100vh; /* Take full viewport height */
    background-color: #c0f5f2; /* Match the screenshot background */
}

.roomsList {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center; /* Center vertically */
    width: 100%;
    min-height: 100vh; /* Take full viewport height */
    padding: 20px;
    background-color: #c0f5f2; /* Match the screenshot background */
}

.roomsList .header{
    font-weight: 700;
    font-size: 1.2rem;
}

.roomsList .search-section {
    display: flex;
    gap: 15px;
    flex-wrap: wrap;
    margin-bottom: 30px;
    justify-content: center; /* Center the search inputs and button */
}

.roomsList .search-section .p-float-label {
    min-width: 200px; /* Ensure inputs have a consistent width */
}

.roomsList .roomsList .noResults {
    font-size: 1rem;
    color: #777;
    margin: 20px 0;
    text-align: center;
}

.roomsList .roomsList .item {
    display: flex;
    flex-direction: row;
    align-items: center;
    justify-content: center;
    flex-wrap: wrap;
    gap: 10px;
    margin-bottom: 10px;
}

.roomsList .item .info {
    width: 64px;
    height: 64px;
    background-color: lightgreen; /* Match the screenshot */
    display: flex;
    align-items: center;
    justify-content: center;
    font-size: 1.5rem;
    font-weight: 600;
    color: #333;
}

/* Медиазапросы для мобильных устройств */
@media (max-width: 600px) {
    .roomsList {
        padding: 10px;
    }

    .search-section {
        flex-direction: column;
        align-items: center;
    }

    .search-section .p-float-label {
        width: 100%; /* Full width on mobile */
    }

    .search-section .p-button {
        width: 100%;
        max-width: 200px;
    }

    .roomsList .item .info {
        margin-left: 0;
    }
}

/* Для планшетов и экранов больше 600px */
@media (min-width: 600px) {
    .roomsList .item .info {
        margin-left: 20px;
    }
}

/* Для экранов больше 1024px */
@media (min-width: 1024px) {
    .roomsList .item .info {
        margin-left: 20px;
    }
}
</style>