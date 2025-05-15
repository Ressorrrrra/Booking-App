<template>
    <Form v-slot="$form" :resolver @submit="onFormSubmit" class="roomInfo">
        <div class="div">
            <div class="inputs">
                <FloatLabel variant="on">
                    <InputNumber v-model="roomNumber"></InputNumber>
                    <label>Номер комнаты</label>
                </FloatLabel>
                <FloatLabel variant="on">
                    <InputNumber v-model="capacity" />
                    <label>Вместимость</label>
                </FloatLabel>
                <FloatLabel variant="on">
                    <InputNumber v-model="price" mode="currency" currency="RUB" locale="ru-RU" />
                    <label>Цена за ночь</label>
                </FloatLabel>
            </div>
        </div>
        <Button type="submit" :label="submitButtonLabel"></Button>
    </Form>
</template>

<script setup>
import { ref, inject, onMounted, watch } from 'vue';
import { useRouter, useRoute } from 'vue-router';
import { Form } from '@primevue/forms';
import { FloatLabel } from 'primevue';
import InputNumber from 'primevue/inputnumber';
import Message from 'primevue/message';
import Button from 'primevue/button';

const router = useRouter();
const route = useRoute();
const globalVar = inject('globalVar');

const hotelId = ref(route.params.hotelId);
const roomId = ref(route.params.roomId || null);
const isEditMode = ref(!!roomId.value);
const submitButtonLabel = ref(isEditMode.value ? 'Обновить номер' : 'Создать номер');

const roomNumber = ref(null);
const capacity = ref(null);
const price = ref(null);

// Отслеживание изменений route.params.roomId
watch(
    () => route.params.roomId,
    (newId) => {
        console.log('Route params roomId:', newId);
        roomId.value = newId || null;
        isEditMode.value = !!newId;
        submitButtonLabel.value = isEditMode.value ? 'Обновить номер' : 'Создать номер';
    },
    { immediate: true }
);

// Загрузка данных номера при редактировании
onMounted(async () => {
    if (isEditMode.value && roomId.value) {
        try {
            const response = await fetch(`${globalVar.apiUrl}/Hotels/${hotelId.value}/Rooms/${roomId.value}`, {
                credentials: 'include'
            });

            if (!response.ok) {
                throw new Error('Ошибка загрузки данных номера');
            }

            const roomData = await response.json();

            roomNumber.value = roomData.roomNumber;
            capacity.value = roomData.capacity;
            price.value = roomData.price;
        } catch (error) {
            console.error('Ошибка при загрузке данных номера:', error);
        }
    }
});

async function onFormSubmit() {
    try {
        const url = isEditMode.value
            ? `${globalVar.apiUrl}/Hotels/${hotelId.value}/Rooms/${roomId.value}`
            : `${globalVar.apiUrl}/Hotels/${hotelId.value}/Rooms`;

        const method = isEditMode.value ? 'PUT' : 'POST';

        const roomData = {
            number: roomNumber.value,
            capacity: capacity.value,
            price: price.value
        };

        console.log('Submitting room data:', roomData);

        const response = await fetch(url, {
            credentials: 'include',
            method: method,
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(roomData)
        });

        if (!response.ok) {
            throw new Error(`Ошибка HTTP: ${response.status}`);
        }

        router.goBack();
    } catch (error) {
        console.error('Ошибка при сохранении номера:', error);
    }
}
</script>

<style scoped>
.roomInfo {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    min-height: 100vh;
    /* Занимает всю высоту экрана */
    max-width: 600px;
    /* Ограничиваем ширину формы */
    margin: 0 auto;
    /* Центрируем по горизонтали */
    padding: 20px;
    box-sizing: border-box;
}

.roomInfo .div {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    width: 100%;
}

.roomInfo .div .inputs {
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    /* Растягиваем поля на всю ширину */
    gap: 15px;
    width: 100%;
    max-width: 400px;
    /* Ограничиваем ширину полей */
}

.roomInfo .p-button {
    margin-top: 20px;
    width: 100%;
    max-width: 200px;
    /* Кнопка не слишком широкая */
}

/* Адаптивные стили для мобильных устройств */
@media (max-width: 600px) {
    .roomInfo {
        padding: 10px;
        /* Убедимся, что форма центрируется на всю высоту */
        justify-content: center;
        /* Центрирование по вертикали */
    }

    .roomInfo .div .inputs {
        max-width: 100%;
        /* Поля на всю ширину на мобильных */
    }

    .roomInfo .p-button {
        max-width: 100%;
        /* Кнопка на всю ширину на мобильных */
    }
}
</style>