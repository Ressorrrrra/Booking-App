<template>
    <div class="profilePage">
        <div class="profileInfo">
            <Image src="https://wallpapers.com/images/hd/placeholder-profile-icon-20tehfawxt5eihco.jpg" width="128" />
            <div class="userData">
                <p>Александр Маслаев</p>
                <p>Эл. почта: maslayev@mail.ru</p>
                <p>Номер телефона: +7 (800) 5555525</p>
            </div>
        </div>

        <p>Ваши бронирования:</p>
        <ScrollPanel class="bookingHistory">
            <div class="item">
                <Image
                    src="https://lh3.googleusercontent.com/p/AF1QipO2-6qABWRwxzyj7WtM_s2aFmRYtZodpw5DVBiC=s1360-w1360-h1020"
                    width="190" />

                <div class="info">
                    <p>Axel Hotel & Hostel</p>
                    <p>19.10.2024 - 23.10.2024</p>
                    <p>Статус: ожидает оплаты</p>
                    <Button type="bookingInfo" severity="secondary" label="Информация о заказе"
                        @click="goToBookingInfo">

                    </Button>
                </div>
            </div>

            <div class="item">
                <Image
                    src="https://dynamic-media-cdn.tripadvisor.com/media/photo-o/1c/c1/34/9d/valo-hotel-city.jpg?w=700&h=-1&s=1"
                    width="190" />

                <div class="info">
                    <p>Valo</p>
                    <p>04.11.2024 - 12.11.2024</p>
                    <p>Статус: оплачено</p>
                    <Button type="bookingInfo" severity="secondary" label="Информация о заказе">

                    </Button>
                </div>
            </div>


        </ScrollPanel>
        <Navbar></Navbar>
    </div>



</template>

<script setup>
import { Image } from 'primevue';
import Button from 'primevue/button';
import Navbar from './NavbarComponent.vue';
import ScrollPanel from 'primevue/scrollpanel';
import { useRouter } from 'vue-router';

const router = useRouter();

function goToBookingInfo() {
    router.push({ name: 'bookinginfo' })
}
</script>

<style>
.profileInfo {
    display: flex;
    flex-direction: row;
    justify-content: center;
    align-items: center;
    margin: 20px;
}

.profileInfo .userData {
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    margin: 10px;
}

.profilePage {
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
}

.bookingHistory {
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    width: 100%;
    height: 200px
}

.bookingHistory .item {
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
</style>