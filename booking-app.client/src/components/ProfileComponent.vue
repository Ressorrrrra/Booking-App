<template>
    <div class="profilePage">
        <div class="profileInfo">
            <Image src="./icons/profilePic.jpg" style="margin: 10px;" />
            <div class="userData">
                <p>Александр Маслаев</p>
                <p>Эл. почта: maslayev@mail.ru</p>
                <p>Номер телефона: +7 (800) 5555525</p>
            </div>
        </div>

        <p>Ваши бронирования:</p>
        <ScrollPanel class="bookingHistory">
            <div class="item">
                <Image src="./icons/profilePic.jpg" style="margin: 10px;" />

                <div class="info">
                    <p>Axel Hotel & Hostel</p>
                    <p>19.10.2024 - 23.10.2024</p>
                    <p>Статус: ожидает оплаты</p>
                    <Button type="bookingInfo" severity="secondary" label="Информация о заказе">

                    </Button>
                </div>
            </div>

            <div class="item">
                <Image src="./icons/profilePic.jpg" style="margin: 10px;" />

                <div class="info">
                    <p>Valo</p>
                    <p>04.11.2024 - 12.11.2024</p>
                    <p>Статус: оплачено</p>
                    <Button type="bookingInfo" severity="secondary" label="Информация о заказе">

                    </Button>
                </div>
            </div>


        </ScrollPanel>
        <Navbar class="navbar"></Navbar>
    </div>



</template>

<script setup>
import { Image } from 'primevue';
import Button from 'primevue/button';
import Navbar from './NavbarComponent.vue';
import ScrollPanel from 'primevue/scrollpanel';
</script>

<style>
.profileInfo {
    display: flex;
    flex-direction: row;
    justify-content: center;
    align-items: center;
    margin: 20px;
}

.navbar {
    bottom: 0;
    justify-content: center;
    align-items: center;
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