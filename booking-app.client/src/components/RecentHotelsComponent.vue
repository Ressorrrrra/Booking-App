<template>
    <div class="mainPage">
        <p class="header">Недавно просмотренные</p>
        <div class="recentHotels">
            <div class="item">
                <p>Axel Hotel & Hostel</p>
                <Avatar
                    image="https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcT2plxFL7HlgsNeuH-QPBuIfTZz2S65T0pM0VESfASZ77DoVIiK"
                    shape="circle" size="xlarge"></Avatar>
            </div>
        </div>
    </div>

</template>

<script setup>
import Avatar from 'primevue/avatar';
</script>

<style>
.mainPage {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    padding: 10px;
    /* Добавляем отступы для лучшего восприятия */
}

/* Медиазапрос для мобильных устройств */
@media (max-width: 600px) {
    .mainPage {
        padding: 5px;
        /* Уменьшаем отступы для мобильных */
    }

    .mainPage .header {
        font-size: 16px;
        /* Уменьшаем размер шрифта для мобильных */
    }

    .mainPage .recentHotels {
        flex-direction: column;
        /* На мобильных устройствах элементы будут вертикально */
        margin-top: 10px;
        /* Добавляем отступ между блоками */
    }
}

/* Медиазапрос для планшетов и экранов от 600px */
@media (min-width: 600px) {
    .mainPage .header {
        font-size: 18px;
        /* Стандартный размер шрифта для планшетов */
    }

    .mainPage .recentHotels {
        flex-direction: row;
        /* Элементы расположены горизонтально для планшетов */
    }
}

/* Медиазапрос для экранов от 1024px */
@media (min-width: 1024px) {
    .mainPage .header {
        font-size: 20px;
        /* Увеличиваем размер шрифта для десктопов */
    }

    .mainPage .recentHotels {
        justify-content: flex-start;
        /* Для больших экранов выравнивание элементов по левому краю */
    }
}

.mainPage .header {
    font-size: 18px;
    font-weight: 700;
    margin-bottom: 20px;
    /* Добавляем отступ снизу для отделения от контента */
}

.mainPage .recentHotels {
    display: flex;
    flex-direction: row;
    align-items: center;
    justify-content: center;
    width: 100%;
}

.mainPage .recentHotels .item {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    margin: 10px;
    /* Добавляем отступы между элементами */
}

/* Медиазапрос для мобильных устройств */
@media (max-width: 600px) {
    .mainPage .recentHotels .item {
        margin: 5px;
        /* Уменьшаем отступы между элементами на мобильных */
    }
}
</style>