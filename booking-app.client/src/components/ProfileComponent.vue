<template>
    <div class="profilePage">
        <div class="profileInfo">
            <Image src="https://wallpapers.com/images/hd/placeholder-profile-icon-20tehfawxt5eihco.jpg" width="128" />
            <div class="userData">
                <p>Эл. почта: {{ userData.userName }}</p>
            </div>

            <Button label="Выйти из аккаунта" @click="logOut"></Button>
        </div>

        <p>Ваши бронирования:</p>
        <ScrollPanel>
            <BookingHistoryComponent></BookingHistoryComponent>
        </ScrollPanel>
    </div>
</template>

<script setup>
import BookingHistoryComponent from './BookingHistoryComponent.vue';
import { ref, inject } from 'vue';
import { Image } from 'primevue';
import Button from 'primevue/button';
import ScrollPanel from 'primevue/scrollpanel';
import { useRouter } from 'vue-router';
import { checkAuth } from '@/plugins/userStatePlugin';
import { onMounted } from 'vue';

const router = useRouter();
const globalVar = inject('globalVar')
var userData = ref(checkAuth())



async function logOut() {
    try {
        const url = `${globalVar.apiUrl}/Accounts/logoff`;

        const response = await fetch(url, {
            credentials: "include",
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
        });

        if (response.ok) {
            goToLogin()
        }
        else if (response.status === 401) {
            throw new Error('Ошибка при попытке авторизации');
        }
    } catch (error) {
        console.error('Ошибка:', error);
    }
}

async function _checkAuth() {
    const auth = await checkAuth()
    console.log(auth)
    if (auth === undefined || !auth.isAuthorized) {
        goToLogin()
    }
    else {
        userData.value = auth;
    }
}

function goToLogin() {
    router.push({ name: 'login' })
}


onMounted(_checkAuth)

</script>

<style>
.profileInfo {
    display: flex;
    flex-direction: row;
    justify-content: center;
    align-items: center;
    margin: 20px;
}

/* Стиль для мобильных устройств */
@media (max-width: 600px) {
    .profileInfo {
        flex-direction: column;
        /* На мобильных устройствах элементы будут вертикально */
        margin: 15px;
        /* Уменьшаем отступы */
    }
}

/* Стиль для планшетов и экранов больше 600px */
@media (min-width: 600px) {
    .profileInfo {
        flex-direction: row;
        /* Для планшетов возвращаем горизонтальное расположение */
        margin: 20px;
        /* Стандартные отступы */
    }
}

/* Стиль для десктопов */
@media (min-width: 1024px) {
    .profileInfo {
        margin: 30px;
        /* Увеличиваем отступы для больших экранов */
    }
}

.profileInfo .userData {
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    margin: 10px;
}

/* Стиль для мобильных устройств */
@media (max-width: 600px) {
    .profileInfo .userData {
        margin: 5px;
        /* Уменьшаем отступы на мобильных устройствах */
    }
}

.profilePage {
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
}

/* Стиль для мобильных устройств */
@media (max-width: 600px) {
    .profilePage {
        padding: 10px;
        /* Уменьшаем отступы на мобильных устройствах */
    }
}

/* Стиль для экрана шириной больше 600px */
@media (min-width: 600px) {
    .profilePage {
        padding: 20px;
        /* Увеличиваем отступы для планшетов и больших экранов */
    }
}

.bookingHistory {
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
    width: 100%;
}

/* Стиль для мобильных устройств */
@media (max-width: 600px) {
    .bookingHistory {
        height: auto;
        /* Для мобильных устройств делаем высоту авто */
    }
}

/* Стиль для планшетов и больших экранов */
@media (min-width: 600px) {
    .bookingHistory {
        height: auto;
        /* Для планшетов и десктопов устанавливаем фиксированную высоту */
    }
}

.bookingHistory .item {
    margin: 10px;
    display: flex;
    flex-direction: row;
    justify-content: center;
    align-items: center;
}

/* Стиль для мобильных устройств */
@media (max-width: 600px) {
    .bookingHistory .item {
        flex-direction: column;
        /* На мобильных устройствах элементы будут вертикально */
    }
}

.bookingHistory .item .info {
    margin: 10px;
    display: flex;
    flex-direction: column;
    justify-content: center;
    align-items: center;
}

/* Стиль для мобильных устройств */
@media (max-width: 600px) {
    .bookingHistory .item .info {
        margin: 5px;
        /* Уменьшаем отступы для мобильных устройств */
    }
}
</style>