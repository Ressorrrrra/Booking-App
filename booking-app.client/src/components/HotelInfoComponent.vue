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
    padding: 10px;
}

.hotelInfo .mainInfo {
    display: flex;
    flex-direction: column;
    align-items: flex-start;
    margin-bottom: 20px;
}

.hotelInfo .mainInfo .info {
    display: flex;
    flex-direction: column;
    margin-left: 0;
    margin-top: 10px;
}

.hotelInfo .mainInfo .name {
    font-size: 1.5rem;
    /* Используем относительный размер */
    font-weight: 600;
}

.hotelInfo .mainInfo .location {
    font-size: 1rem;
    color: #777;
}

.hotelInfo .description {
    display: flex;
    flex-direction: column;
    margin-bottom: 20px;
}

.hotelInfo .description .header {
    font-size: 1rem;
    font-weight: 600;
}

.hotelInfo .description .content {
    font-size: 1rem;
    width: 100%;
    /* Убираем фиксированную ширину для гибкости */
    max-width: 350px;
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
    font-size: 1rem;
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

/* Медиазапросы для более крупных экранов */
@media (min-width: 600px) {
    .hotelInfo .mainInfo {
        flex-direction: row;
        /* Меняем расположение на экранах шире 600px */
    }

    .hotelInfo .mainInfo .info {
        margin-left: 10px;
    }

    .hotelInfo .description .content {
        width: 100%;
        /* Ширина текста на экранах больше 600px */
    }

    .hotelInfo .pictures .content {
        grid-template-columns: repeat(3, 150px);
        /* Увеличиваем количество столбцов */
    }
}

/* Для экрана больше 1024px */
@media (min-width: 1024px) {
    .hotelInfo .mainInfo .name {
        font-size: 2rem;
        /* Увеличиваем шрифт для больших экранов */
    }

    .hotelInfo .mainInfo .location {
        font-size: 1.2rem;
    }

    .hotelInfo .description .header {
        font-size: 1.2rem;
    }

    .hotelInfo .tags {
        grid-template-columns: repeat(4, auto);
        /* Используем больше колонок для тегов */
    }

    .hotelInfo .pictures .content {
        grid-template-columns: repeat(4, 1fr);
        /* Для больших экранов показываем больше картинок в строке */
    }
}
</style>