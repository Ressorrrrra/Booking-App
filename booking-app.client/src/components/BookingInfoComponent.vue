<template>
    <div class="bookingInfo">
        <div class="hotelInfo">
            <Image
                src="https://lh3.googleusercontent.com/proxy/n-I_hmG1lKkkRtgs-P1jTAbsQpFP2xUBlXdISQXvNxLoV9qnLkLM5q1RgkCKSffoxNphRJ9vVrgTENz37cHxco_GkviImRaKcGxGa-5iNousWN73RfH21-Y6y8OfFbTuXySYPn3EzLEAAdNkDTYUQdjUpU6NEw=s680-w680-h510"
                preview width="256" />
            <div class="info">
                <p>Axel Hotel & Hostel</p>
                <p>Австралия, Голд-Кост </p>
                <Button label="Оплатить"></Button>
            </div>
        </div>

        <div class="orderInfo">
            <p>Дата прибытия: 19.10.2024</p>
            <p>Дата отбытия: 23.10.2024</p>
            <p>Цена: 36 890 ₽</p>
            <p>Дата оформления заказа: 02.10.2024</p>
            <p>Количество персон: 2</p>
            <p>Статус: ожидает оплаты</p>
        </div>
        <Navbar></Navbar>
    </div>
</template>

<script setup>
import Button from 'primevue/button';
import Image from 'primevue/image';
import Navbar from './NavbarComponent.vue';


</script>

<style>
.bookingInfo {
    display: flex;
    flex-direction: column;
}

.bookingInfo .hotelInfo {
    display: flex;
    flex-direction: row;
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

.bookingInfo .orderInfo {
    margin: 10px;
    display: flex;
    flex-direction: column;
}
</style>