<template>
    <Form v-slot="$form" :initialValues :resolver @submit="onFormSubmit" class="form">
        <div class="div">
            <div>
                <InputText name="hotelname" type="text" placeholder="Поиск" fluid icon @keyup.enter="onFormSubmit" />
                <Button text="sadsd"></Button>
            </div>

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
        <HotelList />
        <Navbar />
    </Form>



</template>


<script setup>
import { Form } from '@primevue/forms';
import InputText from 'primevue/inputtext';
import InputIcon from 'primevue/inputicon';
import IconField from 'primevue/iconfield';
import DatePicker from 'primevue/datepicker';
import AutoComplete from 'primevue/autocomplete';
import Navbar from './NavbarComponent.vue';
import HotelList from './HotelListComponent.vue';
import Button from 'primevue/button';

async function onFormSubmit(values) {
    const searchRequest = {
        name: $form.name,
        arrivalDate: values.arrivalDate,
        departureDate: values.departureDate,
        country: values.country,
        city: values.city,
        minPrice: values.minPrice,
        maxPrice: values.maxPrice
    };

    console.log('Отправка запроса:', searchRequest);

    try {
        const response = await fetch('https://localhost:7273/api/Hotels/SearchHotels', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(searchRequest)
        });

        if (!response.ok) {
            throw new Error(`Ошибка: ${response.status} ${response.statusText}`);
        }

        const hotels = await response.json();
        console.log('Полученные данные:', hotels);
    } catch (error) {
        console.error('Ошибка при выполнении запроса:', error.message);
    }
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