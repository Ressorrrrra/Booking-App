<template>
    <div class="bookingInfo">
        <div class="hotelInfo">
            <Image
                src="https://lh3.googleusercontent.com/proxy/n-I_hmG1lKkkRtgs-P1jTAbsQpFP2xUBlXdISQXvNxLoV9qnLkLM5q1RgkCKSffoxNphRJ9vVrgTENz37cHxco_GkviImRaKcGxGa-5iNousWN73RfH21-Y6y8OfFbTuXySYPn3EzLEAAdNkDTYUQdjUpU6NEw=s680-w680-h510"
                preview width="256" />
            <div class="info">
                <p>The Langham Gold Coast</p>
                <p>Австралия, Голд-Кост </p>
                <Button label="Забронировать номер" aut></Button>
            </div>
        </div>

        <div class="dates">
            <div class="item">
                <p class="header">Дата прибытия:</p>
                <DatePicker showIcon iconDisplay="input"></DatePicker>
            </div>
            <div class="item">
                <p class="header">Дата отбытия:</p>
                <DatePicker showIcon iconDisplay="input"></DatePicker>
            </div>
        </div>

        <div class="residents">
            <p class="header">Количество проживающих</p>
            <div class="content">
                <div class="item">
                    <p class="header">Взрослых:</p>
                    <AutoComplete v-model="value" dropdown :suggestions="itemsAdults" />
                </div>
                <div class="item">
                    <p class="header">Детей:</p>
                    <AutoComplete v-model="value" dropdown :suggestions="itemsChildren" />
                </div>
            </div>
        </div>

        <div class="aviableRooms">
            <p class="header">Доступные номера</p>
            <div class="content">
                <Button class="button" label="1" rounded severity="secondary"></Button>
                <Button class="button" label="2" rounded severity="secondary"></Button>
                <Button class="button" label="3" rounded severity="secondary"></Button>
            </div>

        </div>

        <p class="price">Итого: 36 890 ₽</p>

        <Navbar></Navbar>
    </div>
</template>

<script setup>
import Button from 'primevue/button';
import Image from 'primevue/image';
import Navbar from './NavbarComponent.vue';
import DatePicker from 'primevue/datepicker';
import AutoComplete from 'primevue/autocomplete';

const itemsAdults = [1, 2, 3, 4, 5, 6, 7, 8, 9]
const itemsChildren = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]


</script>

<style>
.bookingInfo {
    display: flex;
    flex-direction: column;
    padding: 10px;
}

.bookingInfo .hotelInfo {
    display: flex;
    flex-direction: column;
    align-items: flex-start;
    margin-bottom: 20px;
}

.bookingInfo .hotelInfo .info {
    display: flex;
    flex-direction: column;
    margin-left: 0;
    margin-top: 10px;
}

.bookingInfo .hotelInfo .name {
    font-size: 1.5rem;
    /* Используем относительный размер */
    font-weight: 600;
}

.bookingInfo .hotelInfo .location {
    font-size: 1rem;
    color: #777;
}

.bookingInfo .dates {
    display: flex;
    flex-direction: column;
    margin-top: 20px;
}

.bookingInfo .dates .item {
    display: flex;
    flex-direction: column;
    margin: 10px;
}

.bookingInfo .dates .item .header {
    font-size: 1rem;
    font-weight: 600;
}

.bookingInfo .residents {
    display: flex;
    flex-direction: column;
    margin-top: 20px;
}

.bookingInfo .residents .header {
    font-size: 1.2rem;
    font-weight: 600;
}

.bookingInfo .residents .content {
    display: flex;
    flex-direction: row;
    gap: 15px;
    flex-wrap: wrap;
}

.bookingInfo .residents .content .item {
    display: flex;
    flex-direction: column;
    margin: 10px;
}

.bookingInfo .residents .content .item .header {
    font-size: 1rem;
    font-weight: 600;
}

.bookingInfo .aviableRooms {
    display: flex;
    flex-direction: column;
    margin-top: 20px;
}

.bookingInfo .aviableRooms .header {
    font-size: 1.2rem;
    font-weight: 600;
}

.bookingInfo .aviableRooms .content {
    display: flex;
    flex-direction: row;
    align-items: center;
    justify-content: center;
    flex-wrap: wrap;
    gap: 10px;
}

.bookingInfo .aviableRooms .content .button {
    width: 128px;
    height: 128px;
    margin: 10px;
}

.bookingInfo .price {
    font-size: 1.5rem;
    /* Используем относительный размер */
    margin-top: 20px;
}

/* Медиазапросы для экранов шириной больше 600px */
@media (min-width: 600px) {
    .bookingInfo .hotelInfo {
        flex-direction: row;
    }

    .bookingInfo .hotelInfo .info {
        margin-left: 10px;
    }

    .bookingInfo .dates {
        flex-direction: row;
    }

    .bookingInfo .dates .item {
        margin: 10px;
    }

    .bookingInfo .residents .content {
        flex-direction: row;
    }

    .bookingInfo .aviableRooms .content {
        flex-direction: row;
    }
}

/* Для экранов больше 1024px */
@media (min-width: 1024px) {
    .bookingInfo .hotelInfo .name {
        font-size: 2rem;
    }

    .bookingInfo .hotelInfo .location {
        font-size: 1.2rem;
    }

    .bookingInfo .price {
        font-size: 2rem;
    }
}
</style>