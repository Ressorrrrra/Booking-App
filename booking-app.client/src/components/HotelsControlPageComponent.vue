<template>
    <div class="hotelsControlPage">
        <p class="header">Ваши отели</p>
        <Button label="Создать отель" @click="router.goTo({ name: 'createHotel' })"></Button>
        <ScrollPanel>
            <CreatorHotelsList></CreatorHotelsList>
        </ScrollPanel>
    </div>
</template>

<script setup>
import CreatorHotelsList from './CreatorHotelsListComponent.vue'
import ScrollPanel from 'primevue/scrollpanel';
import { checkAuth } from '@/plugins/userStatePlugin';
import { onMounted, ref } from 'vue';
import { useRouter } from 'vue-router';
import Button from 'primevue/button';
var userData = ref(null)
var router = useRouter()

onMounted(checkUser)

async function checkUser() {
    userData.value = await checkAuth()
    if (!userData.value.isAuthorized)
        router.goTo({ name: 'login' })
}
</script>



<style>
.hotelsControlPage {
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    column-gap: 100px;
    padding: 20px;
    height: auto;
}


.hotelsControlPage .header {
    font-size: 1.5rem;
    /* Используем относительные единицы */
    font-weight: 600;
    margin-bottom: 20px;
    align-items: center;
}


/* Медиазапросы для мобильных устройств */
@media (max-width: 600px) {
    .hotelsControlPage {
        column-gap: 20px;
        /* Уменьшаем расстояние между колонками на мобильных устройствах */
        padding: 10px;
        /* Уменьшаем отступы */
    }

    .hotelsControlPage .header {
        font-size: 1.2rem;
        /* Уменьшаем размер шрифта заголовка */
        margin-bottom: 10px;
    }
}

/* Для планшетов и экранов больше 600px */
@media (min-width: 600px) {
    .hotelsControlPage {
        column-gap: 50px;
        /* Среднее расстояние между колонками для планшетов */
    }
}

/* Для экранов шириной больше 1024px */
@media (min-width: 1024px) {
    .hotelsControlPage {
        column-gap: 100px;
        /* Оставляем большое расстояние между колонками для десктопов */
    }

    .hotelsControlPage .header {
        font-size: 2rem;
        /* Увеличиваем размер шрифта для десктопов */
    }
}
</style>