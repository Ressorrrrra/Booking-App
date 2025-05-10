<template>
    <div class="div">
        <h3 class="hotelName">{{ props.order.hotel.name }}</h3>
        <p class="dates">
            {{ formatDate(props.order.arrivalDate) }} - {{ formatDate(props.order.departureDate) }}
        </p>

        <Rating v-model="form.rating" class="rating"></Rating>
        <TextArea class="textarea" v-model="form.text" :autoResize="true" rows="5" placeholder="Ваш отзыв..." />
    </div>
</template>

<script setup>
import { ref } from 'vue';
import Rating from 'primevue/rating';
import TextArea from 'primevue/textarea';

const props = defineProps({
    order: { type: Object, required: true },
});

const form = ref({
    rating: 0,
    text: '',
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
.div {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    padding: 10px;
}

.div .hotelName {
    font-size: 14;
    /* Добавляем отступы для лучшего восприятия */
}

.div .dates {
    font-size: 12;
    /* Добавляем отступы для лучшего восприятия */
}

.div .rating {
    font-size: 12;
    /* Добавляем отступы для лучшего восприятия */
}

.div .textarea {
    font-size: 12;
    margin: 10%;
    width: 90%;
    /* Добавляем отступы для лучшего восприятия */
}


/* Медиазапрос для мобильных устройств */
@media (max-width: 600px) {
    .div {
        padding: 5px;
        /* Уменьшаем отступы на мобильных устройствах */
    }
}

/* Медиазапрос для планшетов и экранов от 600px */
@media (min-width: 600px) {}

/* Медиазапрос для экрана от 1024px */
@media (min-width: 1024px) {}
</style>
