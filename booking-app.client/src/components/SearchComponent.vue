<template>
    <Form v-slot="$form" :initialValues :resolver @submit="onFormSubmit" class="form">
        <div class="div">
            <IconField>
                <InputText name="hotelname" type="text" placeholder="Поиск" fluid icon />
                <InputIcon class="pi pi-search" />
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
                        <AutoComplete name="bottomPrice" dropdown />
                    </div>

                    <div>
                        <p>До</p>
                        <AutoComplete name="topPrice" dropdown />
                    </div>
                </div>
            </div>

        </div>

    </Form>

    <Navbar></Navbar>

</template>

<script>
export default {
    methods: {
        goToProfile() {
            this.$router.push({ name: 'profile' });
        },
    },
}
</script>

<script setup>
import { Form } from '@primevue/forms';
import InputText from 'primevue/inputtext';
import InputIcon from 'primevue/inputicon';
import IconField from 'primevue/iconfield';
import DatePicker from 'primevue/datepicker';
import AutoComplete from 'primevue/autocomplete';
import { useRouter } from 'vue-router';
import Navbar from './NavbarComponent.vue';

const router = useRouter();

function onFormSubmit(values) {
    console.log('Form submitted with:', values);
    router.push({ name: 'profile' });
}
</script>

<style>
.form {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    padding: 10px;
    /* Добавлены отступы для лучшего восприятия */
}

/* Медиазапрос для мобильных устройств */
@media (max-width: 600px) {
    .form {
        padding: 5px;
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
    margin: 10px;
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