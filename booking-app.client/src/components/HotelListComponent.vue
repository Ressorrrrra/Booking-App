<template>
    <div class="hotelList">


        <div class="item">
            <Image
                src="https://lh3.googleusercontent.com/proxy/n-I_hmG1lKkkRtgs-P1jTAbsQpFP2xUBlXdISQXvNxLoV9qnLkLM5q1RgkCKSffoxNphRJ9vVrgTENz37cHxco_GkviImRaKcGxGa-5iNousWN73RfH21-Y6y8OfFbTuXySYPn3EzLEAAdNkDTYUQdjUpU6NEw=s680-w680-h510"
                width="150" height="110" />

            <div class="info">
                <p class="hotelName">The Langham Gold Coast</p>
                <p class="price">От 12 450₽ за ночь</p>
                <p class="location">Австралия, Голд-Кост</p>
                <Button label="Забронировать номер" @click="goToHotelInfo">
                </Button>

            </div>
        </div>

        <div class="item">
            <Image
                src="https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcT2plxFL7HlgsNeuH-QPBuIfTZz2S65T0pM0VESfASZ77DoVIiK"
                width="150" height="110" rounded />


            <div class="info">
                <p class="hotelName">YVE Hotel Miami</p>
                <p class="price">От 15 699₽ за ночь</p>
                <p class="location">США, Майами</p>
                <Button label="Забронировать номер">
                </Button>
            </div>
        </div>

    </div>
</template>

<script setup>
import { Button } from 'primevue';
import { useRouter } from 'vue-router';
import Image from 'primevue/image';

const router = useRouter()
function goToHotelInfo() {
    router.push({ name: 'hotelinfo' });
}
</script>

<style>
.hotelList {
    display: flex;
    flex-direction: column;
    align-items: flex-start;
    width: 100%;
    height: 200px
}

.hotelList .item {
    margin: 10px;
    display: grid;
    grid-auto-flow: column;
    grid-column-gap: 10px;
    justify-content: center;
    align-items: center;
}

.hotelList .item .image {
    margin: 100px;
    justify-content: center;
    align-items: center;
}

.bookingHistory .item .info {
    margin: 10px;
    margin-left: 50px;
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
}

.bookingHistory .item .info .hotelName {
    font-size: 20px;
    font-weight: 600;
}

.bookingHistory .item .info .price {
    font-size: 16px;
    font-weight: 500;
}

.bookingHistory .item .info .location {
    font-size: 12px;
}
</style>