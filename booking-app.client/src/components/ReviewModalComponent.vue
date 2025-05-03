<template>
    <div class="form">
        <h3 class="hotelName">{{ props.order.hotel }}</h3>
        <p class="dates">
            {{ formatDate(props.order.arrivalDate) }} - {{ formatDate(props.order.departureDate) }}
        </p>

        <Rating v-model="form.rating" :cancel="false" :stars="5" />

        <TextArea v-model="form.text" :autoResize="true" rows="5" placeholder="Ваш отзыв..." class="mt-4 w-full" />

    </div>
</template>

<script setup>
import { ref } from 'vue';
import { Rating } from 'primevue/rating';
import TextArea from 'primevue/textarea';

const props = defineProps({
    order: { type: Object, required: true },
});

const form = ref({
    rating: 0,
    text: '',
    photos: []
});

const formatDate = (dateString) => {
    return new Date(dateString).toLocaleDateString();
};

// Экспортируем данные формы для родителя
defineExpose({
    form
});
</script>

<style>
.form {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    padding: 10px;
}

.form .hotelName {
    font-size: 14;
    /* Добавляем отступы для лучшего восприятия */
}

.form .dates {
    font-size: 12;
    /* Добавляем отступы для лучшего восприятия */
}


/* Медиазапрос для мобильных устройств */
@media (max-width: 600px) {
    .form {
        padding: 5px;
        /* Уменьшаем отступы на мобильных устройствах */
    }
}

/* Медиазапрос для планшетов и экранов от 600px */
@media (min-width: 600px) {}

/* Медиазапрос для экрана от 1024px */
@media (min-width: 1024px) {}
</style>
