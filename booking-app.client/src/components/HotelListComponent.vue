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
    height: auto;
    /* Убираем фиксированную высоту, чтобы контейнер подстраивался под контент */
    padding: 10px;
}

.hotelList .item {
    margin: 10px;
    display: grid;
    grid-auto-flow: row;
    /* Переводим в ряд для мобильных устройств */
    grid-gap: 10px;
    justify-items: center;
    align-items: center;
    width: 100%;
    /* Делает каждый элемент растягивающимся по ширине */
}

.hotelList .item .image {
    width: 100%;
    /* Сделаем изображения адаптивными */
    max-width: 300px;
    /* Ограничим максимальную ширину */
    margin: 0 auto;
    display: block;
}

.bookingHistory .item .info {
    margin: 10px;
    margin-left: 0;
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: flex-start;
}

.bookingHistory .item .info .hotelName {
    font-size: 1.2rem;
    /* Используем относительные единицы для адаптивности */
    font-weight: 600;
}

.bookingHistory .item .info .price {
    font-size: 1rem;
    /* Также используем относительные единицы */
    font-weight: 500;
}

.bookingHistory .item .info .location {
    font-size: 0.9rem;
    color: #777;
}

/* Медиазапросы для мобильных устройств */
@media (max-width: 600px) {
    .hotelList .item {
        grid-template-columns: 1fr;
        /* Строки, а не колонки на маленьких экранах */
    }

    .hotelList .item .image {
        max-width: 100%;
        /* На мобильных устройствах изображение будет растягиваться */
        margin: 0;
    }

    .bookingHistory .item .info {
        align-items: flex-start;
        margin-left: 0;
        /* Убираем отступ слева на маленьких экранах */
    }
}

/* Медиазапросы для планшетов и экранов больше 600px */
@media (min-width: 600px) {
    .hotelList .item {
        grid-template-columns: 1fr 1fr;
        /* Два элемента в строке на экранах больше 600px */
    }

    .hotelList .item .image {
        max-width: 50%;
        /* Ограничиваем максимальную ширину изображения */
    }
}

/* Для экранов шириной больше 1024px */
@media (min-width: 1024px) {
    .hotelList .item {
        grid-template-columns: 1fr 1fr 1fr;
        /* Три элемента в строке */
    }

    .hotelList .item .image {
        max-width: 100%;
        /* Изображения для больших экранов */
    }

    .bookingHistory .item .info {
        margin-left: 20px;
        /* Добавляем отступы для большего экрана */
    }

    .bookingHistory .item .info .hotelName {
        font-size: 1.5rem;
        /* Увеличиваем размер шрифта для названия отеля */
    }

    .bookingHistory .item .info .price {
        font-size: 1.2rem;
    }

    .bookingHistory .item .info .location {
        font-size: 1rem;
    }
}
</style>