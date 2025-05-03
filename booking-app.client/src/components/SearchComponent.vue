<template>
    <Form :initialValues="initialValues" @submit="onFormSubmit" class="form">
        <div class="div">
            <IconField>
                <InputText name="name" type="text" placeholder="Поиск" fluid icon @keyup.enter="requestSubmit" />
                <InputIcon class="pi pi-search" @click="requestSubmit"></InputIcon>
            </IconField>

            <div class="optionsDiv">
                <p>Время проживания</p>

                <div class="options">
                    <div>
                        <p>Дата прибытия</p>
                        <DatePicker name="arrivalDate" showIcon fluid iconDisplay="input" />
                    </div>

                    <div>
                        <p>Дата отбытия</p>
                        <DatePicker name="departureDate" showIcon fluid iconDisplay="input" />
                    </div>
                </div>
            </div>

            <div class="optionsDiv">
                <p>Местоположение</p>

                <div class="options">
                    <div>
                        <p>Страна</p>
                        <AutoComplete name="country" dropdown />
                    </div>

                    <div>
                        <p>Город/населённый пункт</p>
                        <AutoComplete name="city" dropdown />
                    </div>
                </div>
            </div>

            <div class="optionsDiv">
                <p>Цена</p>

                <div class="options">
                    <div>
                        <p>От</p>
                        <AutoComplete name="minPrice" dropdown />
                    </div>

                    <div>
                        <p>До</p>
                        <AutoComplete name="maxPrice" dropdown />
                    </div>


                </div>
            </div>

        </div>
        <HotelList :criteria="searchRequest" />
        <Navbar />
    </Form>



</template>


<script setup>
import { ref } from 'vue';
import { Form } from '@primevue/forms';
import InputText from 'primevue/inputtext';
import InputIcon from 'primevue/inputicon';
import IconField from 'primevue/iconfield';
import DatePicker from 'primevue/datepicker';
import AutoComplete from 'primevue/autocomplete';
import Navbar from './NavbarComponent.vue';
import HotelList from './HotelListComponent.vue';

const initialValues = {
    name: '',
    arrivalDate: null, // Начальное значение для даты
    departureDate: null, // Начальное значение для даты
    country: '',
    city: '',
    minPrice: null,
    maxPrice: null
};

const searchRequest = ref({
    name: '',
    arrivalDate: null,
    departureDate: null,
    country: '',
    city: '',
    minPrice: null,
    maxPrice: null
})

async function requestSubmit() {
    const myForm = document.querySelector("form");
    myForm.requestSubmit();
}

async function onFormSubmit(form) {
    searchRequest.value =
    {
        name: form.states.name.value,
        arrivalDate: form.states.arrivalDate.value,
        departureDate: form.states.departureDate.value,
        country: form.states.country.value,
        city: form.states.city.value,
        minPrice: form.states.minPrice.value,
        maxPrice: form.states.maxPrice.value
    };
}

</script>

<style>
.form {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    /* Добавлены отступы для лучшего восприятия */
}

/* Медиазапрос для мобильных устройств */
@media (max-width: 600px) {
    .form {
        /* Уменьшаем отступы на мобильных устройствах */
    }

    .form .div {
        grid-row-gap: 5px;
        /* Уменьшаем отступы между строками на мобильных устройствах */
    }

    .form .optionsDiv {
        margin: 5px;
        /* Уменьшаем отступы */
    }

    .form .optionsDiv .options {
        grid-column-gap: 20px;
        /* Уменьшаем расстояние между опциями */
        grid-template-columns: 1fr 1fr;
        /* Располагаем опции по два в ряд на мобильных */
    }
}

/* Медиазапрос для планшетов и экранов от 600px */
@media (min-width: 600px) {
    .form .optionsDiv .options {
        grid-column-gap: 50px;
        /* Увеличиваем отступ между опциями для планшетов */
        grid-template-columns: 1fr 1fr 1fr;
        /* Для планшетов расположение опций по 3 в ряд */
    }
}

/* Медиазапрос для экрана от 1024px */
@media (min-width: 1024px) {
    .form .optionsDiv .options {
        grid-column-gap: 50px;
        /* Для десктопов оставляем большие отступы */
        grid-template-columns: 1fr 1fr 1fr 1fr;
        /* Для десктопов 4 опции в ряд */
    }
}

.form .div {
    display: grid;
    grid-auto-flow: row;
    grid-row-gap: 10px;
    align-items: center;
    justify-content: center;
}

.form .optionsDiv {

    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
}

.form .optionsDiv .options {
    margin: 10px;
    display: grid;
    grid-auto-flow: column;
    grid-column-gap: 50px;
    align-items: center;
    justify-content: center;
}
</style>