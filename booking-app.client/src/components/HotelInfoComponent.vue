<template>
    <div class="hotelInfo">
        <div class="mainInfo">
            <Image src="./icons/profilePic.jpg" preview />
            <div class="info">
                <p>The Langham Gold Coast</p>
                <p>Австралия, Голд-Кост </p>
                <Button label="Забронировать номер" aut></Button>
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
                <Image src="/hotelInside.jpg" preview></Image>
                <Image src="/hotelInside.jpg" preview></Image>
                <Image src="/hotelInside.jpg" preview></Image>
                <Image src="/hotelInside.jpg" preview></Image>
                <Image src="/hotelInside.jpg" preview></Image>
                <Image src="/hotelInside.jpg" preview></Image>
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


</script>

<style>
.hotelInfo {
    display: flex;
    flex-direction: column;
}

.hotelInfo .mainInfo {
    display: flex;
    flex-direction: row;
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
    grid-template-columns: repeat(2, 200px);
    align-items: center;
    justify-content: center;
    margin: 10px;
}
</style>