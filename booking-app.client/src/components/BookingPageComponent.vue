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
}

.bookingInfo .hotelInfo {
    display: flex;
    flex-direction: row;
    align-items: center;
}

.bookingInfo .hotelInfo .info {
    display: flex;
    flex-direction: column;
    margin-left: 10px;
}

.bookingInfo .hotelInfo .name {
    font-size: 24px;
    font-weight: 600;
}

.bookingInfo .hotelInfo .location {
    font-size: 12px;
}


.bookingInfo .dates {
    display: flex;
    flex-direction: row;
}

.bookingInfo .dates .item {
    display: flex;
    flex-direction: column;
    margin: 10px;
}

.bookingInfo .dates .item .header {
    font-size: 14px;
    font-weight: 600;
}

.bookingInfo .residents {
    display: flex;
    flex-direction: column;
}



.bookingInfo .residents .header {
    font-size: 16px;
    font-weight: 600;
}

.bookingInfo .residents .content {
    display: flex;
    flex-direction: row;
}

.bookingInfo .residents .content .item {
    display: flex;
    flex-direction: column;
    margin: 10px;
}

.bookingInfo .residents .content .item .header {
    font-size: 14px;
    font-weight: 600;
}

.bookingInfo .aviableRooms {
    display: flex;
    flex-direction: column;
}



.bookingInfo .aviableRooms .header {
    font-size: 16px;
    font-weight: 600;
}

.bookingInfo .aviableRooms .content {
    display: flex;
    flex-direction: row;
    align-items: center;
    justify-content: center;
}

.bookingInfo .aviableRooms .content .button {
    width: 128;
    height: 128;
    margin: 10px;
}

.bookingInfo .price {
    font-size: 20px;
}
</style>