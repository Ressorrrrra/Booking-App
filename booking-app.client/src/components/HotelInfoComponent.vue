<template>
    <div class="hotelInfo">
        <div class="mainInfo">
            <Image
                src="https://lh3.googleusercontent.com/proxy/n-I_hmG1lKkkRtgs-P1jTAbsQpFP2xUBlXdISQXvNxLoV9qnLkLM5q1RgkCKSffoxNphRJ9vVrgTENz37cHxco_GkviImRaKcGxGa-5iNousWN73RfH21-Y6y8OfFbTuXySYPn3EzLEAAdNkDTYUQdjUpU6NEw=s680-w680-h510"
                preview width="256" />
            <div class="info">
                <p>The Langham Gold Coast</p>
                <p>Австралия, Голд-Кост </p>
                <Button label="Забронировать номер" @click="goToBookingPage"></Button>
            </div>
        </div>

        <div class="description">
            <p class="header"></p>
            <p class="content">
                The Langham, Gold Coast and Jewel Residences — это отель с 5 звездами на первой линии города Голд-Кост.
                В распоряжении гостей открытый бассейн, фитнес-центр и ресторан.
            </p>
        </div>
        <div class="tags">
            <Tag value="Бассейн"></Tag>
            <Tag value="Wi-Fi"></Tag>
            <Tag value="Ресторан"></Tag>
            <Tag value="Спортзал"></Tag>
        </div>
        <p> </p>
        <div class="pictures">
            <p class="header">Фотографии</p>
            <div class="content">
                <Image
                    src="https://lh3.googleusercontent.com/proxy/n-I_hmG1lKkkRtgs-P1jTAbsQpFP2xUBlXdISQXvNxLoV9qnLkLM5q1RgkCKSffoxNphRJ9vVrgTENz37cHxco_GkviImRaKcGxGa-5iNousWN73RfH21-Y6y8OfFbTuXySYPn3EzLEAAdNkDTYUQdjUpU6NEw=s680-w680-h510"
                    preview width="150"></Image>
                <Image
                    src="https://lh3.googleusercontent.com/proxy/n-I_hmG1lKkkRtgs-P1jTAbsQpFP2xUBlXdISQXvNxLoV9qnLkLM5q1RgkCKSffoxNphRJ9vVrgTENz37cHxco_GkviImRaKcGxGa-5iNousWN73RfH21-Y6y8OfFbTuXySYPn3EzLEAAdNkDTYUQdjUpU6NEw=s680-w680-h510"
                    preview width="150"></Image>
                <Image
                    src="https://lh3.googleusercontent.com/proxy/n-I_hmG1lKkkRtgs-P1jTAbsQpFP2xUBlXdISQXvNxLoV9qnLkLM5q1RgkCKSffoxNphRJ9vVrgTENz37cHxco_GkviImRaKcGxGa-5iNousWN73RfH21-Y6y8OfFbTuXySYPn3EzLEAAdNkDTYUQdjUpU6NEw=s680-w680-h510"
                    preview width="150"></Image>
                <Image
                    src="https://lh3.googleusercontent.com/proxy/n-I_hmG1lKkkRtgs-P1jTAbsQpFP2xUBlXdISQXvNxLoV9qnLkLM5q1RgkCKSffoxNphRJ9vVrgTENz37cHxco_GkviImRaKcGxGa-5iNousWN73RfH21-Y6y8OfFbTuXySYPn3EzLEAAdNkDTYUQdjUpU6NEw=s680-w680-h510"
                    preview width="150"></Image>
                <Image
                    src="https://lh3.googleusercontent.com/proxy/n-I_hmG1lKkkRtgs-P1jTAbsQpFP2xUBlXdISQXvNxLoV9qnLkLM5q1RgkCKSffoxNphRJ9vVrgTENz37cHxco_GkviImRaKcGxGa-5iNousWN73RfH21-Y6y8OfFbTuXySYPn3EzLEAAdNkDTYUQdjUpU6NEw=s680-w680-h510"
                    preview width="150"></Image>
                <Image
                    src="https://lh3.googleusercontent.com/proxy/n-I_hmG1lKkkRtgs-P1jTAbsQpFP2xUBlXdISQXvNxLoV9qnLkLM5q1RgkCKSffoxNphRJ9vVrgTENz37cHxco_GkviImRaKcGxGa-5iNousWN73RfH21-Y6y8OfFbTuXySYPn3EzLEAAdNkDTYUQdjUpU6NEw=s680-w680-h510"
                    preview width="150"></Image>
            </div>
        </div>
        <Navbar></Navbar>
    </div>
</template>

<script setup>
import Button from 'primevue/button';
import Tag from 'primevue/tag';
import Image from 'primevue/image';
import Navbar from './NavbarComponent.vue';
import { useRouter } from 'vue-router';

const router = useRouter()

function goToBookingPage() {
    router.push({ name: 'bookingpage' })
}


</script>

<style>
.hotelInfo {
    display: flex;
    flex-direction: column;
}

.hotelInfo .mainInfo {
    display: flex;
    flex-direction: row;
    align-items: center;
    justify-content: center;
}

.hotelInfo .mainInfo .info {
    display: flex;
    flex-direction: column;
    margin-left: 10px;
}

.hotelInfo .mainInfo .name {
    font-size: 24px;
    font-weight: 600;
}

.hotelInfo .mainInfo .location {
    font-size: 12px;
}


.hotelInfo .description {
    display: flex;
    flex-direction: column;
}

.hotelInfo .description .header {
    font-size: 14px;
    font-weight: 600;
}

.hotelInfo .description .content {
    font-size: 12px;
    width: 350px;
}

.hotelInfo .tags {
    display: grid;
    grid-auto-flow: column;
    grid-column-gap: 10px;
    align-items: center;
    justify-content: center;
    margin: 10px;
}


.hotelInfo .pictures {
    display: flex;
    flex-direction: column;
    margin: 10px;
}

.hotelInfo .pictures .header {
    font-size: 14px;
    font-weight: 600;
}

.hotelInfo .pictures .content {
    display: grid;
    grid-column-gap: 10px;
    grid-row-gap: 10px;
    grid-template-columns: repeat(2, 150px);
    align-items: center;
    justify-content: center;
    margin: 10px;
}
</style>