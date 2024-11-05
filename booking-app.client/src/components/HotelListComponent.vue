<template>
    <div class="hotelList">
        <div class="item">
            <Image src="./icons/profilePic.jpg" />

            <div class="info">
                <p class="hotelName">YVE Hotel Miami</p>
                <p class="price">От 15 699₽ за ночь</p>
                <p class="location">США, Майами</p>
                <Button label="Забронировать номер" @click="goToHotelInfo">
                </Button>
            </div>
        </div>


        <div class="item">
            <Image src="./icons/profilePic.jpg" />

            <div class="info">
                <p class="hotelName">The Langham Gold Coast</p>
                <p class="price">От 12 450₽ за ночь</p>
                <p class="location">Австралия, Голд-Кост</p>
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
    display: flex;
    flex-direction: row;
    justify-content: center;
    align-items: center;
}

.bookingHistory .item .info {
    margin: 10px;
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