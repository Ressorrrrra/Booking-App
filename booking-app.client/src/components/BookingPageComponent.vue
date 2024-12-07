<template>
    <Form class="bookingInfo" v-if="hotel" @submit="bookRoom">
        <div class="hotelInfo">
            <Image :src="hotel.pictureLinks[0]" preview width="256" />
            <div class="info">
                <p class="name">{{ hotel.name }}</p>
                <p class="location"> {{ hotel.country }}, {{ hotel.city }} </p>
                <Button label="Забронировать номер" aut></Button>
            </div>
        </div>

        <div class="dates">
            <div class="item">
                <p class="header">Дата прибытия:</p>
                <DatePicker showIcon iconDisplay="input" name="arrivalDate" @update:modelValue="GetPrice"></DatePicker>
            </div>
            <div class="item">
                <p class="header">Дата отбытия:</p>
                <DatePicker showIcon iconDisplay="input" name="departureDate" @update:modelValue="GetPrice">
                </DatePicker>
            </div>
        </div>

        <div class="residents">
            <p class="header">Количество проживающих</p>
            <div class="content">
                <div class="item">
                    <p class="header">Взрослых:</p>
                    <AutoComplete name="adultsAmount" dropdown :suggestions="itemsAdults" />
                </div>
                <div class="item">
                    <p class="header">Детей:</p>
                    <AutoComplete name="childrenAmount" dropdown :suggestions="itemsChildren" />
                </div>
            </div>
        </div>

        <div class="aviableRooms">
            <p class="header">Доступные номера</p>
            <div class="items">

                <div v-for="room in hotel.rooms" :key="room.id" class="item">
                    <Button class="button" :style="{ backgroundColor: room.id === chosenRoomId ? 'lightgreen' : '' }"
                        :label="room.number.toString()" rounded severity="secondary"
                        @click="chooseRoom(room.id)"></Button>
                </div>
            </div>

        </div>

        <p class="price">{{ totalPrice }}
        </p>

        <Navbar></Navbar>
    </Form>
</template>

<script setup>
import { onMounted, ref } from 'vue';
import Button from 'primevue/button';
import Image from 'primevue/image';
import Navbar from './NavbarComponent.vue';
import DatePicker from 'primevue/datepicker';
import AutoComplete from 'primevue/autocomplete';
import { Form } from '@primevue/forms';
import { useRoute, useRouter } from 'vue-router';
import { useUser } from '@/plugins/userStatePlugin';

const itemsAdults = [1, 2, 3, 4, 5, 6, 7, 8, 9]
const itemsChildren = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]
const hotel = ref(null);
const router = useRouter();
const route = useRoute();
var chosenRoomId = ref(-1);
var totalPrice = ref(0);
var priceRequest = {
    roomId: -1,
    arrivalDate: Date.now(),
    departureDate: Date.now(),
    childrenAmount: 0,
    adultsAmount: 0,
}



async function fetchHotelData() {
    if (!useUser().value.isAuthorized) goToLogin()
    else {
        try {
            const hotelId = route.params.id; // Предполагаем, что ID передаётся в параметрах маршрута
            const response = await fetch(`https://localhost:7273/api/Hotels/${hotelId}`);
            if (!response.ok) throw new Error('Ошибка при загрузке данных');
            hotel.value = await response.json();
            console.log(hotel.value)
        } catch (error) {
            console.error('Ошибка:', error);
        }
    }
}

async function GetPrice(form) {
    console.log(form, "putis")
    const url = `https://localhost:7273/api/Orders/GetPrice_${chosenRoomId.value}`

    priceRequest =
    {
        roomId: chosenRoomId,
        arrivalDate: form.states.arrivalDate.value,
        departureDate: form.states.departureDate.value,
        childrenAmount: form.states.childrenAmount.value,
        adultsAmount: form.states.adultsAmount.value,
    }

    const response = await fetch(url, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(priceRequest)
    });

    if (response.ok) {
        const data = await response.json()
        totalPrice.value = data.totalPrice
    }
}

async function bookRoom(form) {
    try {
        const url = 'https://localhost:7273/api/Orders';

        request =
        {
            roomId: chosenRoomId,
            arrivalDate: form.states.arrivalDate.value,
            departureDate: form.states.departureDate.value,
            childrenAmount: form.states.childrenAmount.value,
            adultsAmount: form.states.adultsAmount.value,
        }

        const response = await fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(request)
        });


        if (response.status != 404 && response.status != 201) {
            throw new Error(`Ошибка HTTP: ${response.status}`);
        }
        if (response.status === 201) {
            goToProfile();
        }

    } catch (error) {
        console.error('Ошибка при оформлении заказа отелей:', error);
    }
}

function chooseRoom(roomId) {
    chosenRoomId.value = roomId

    console.log(chosenRoomId)
}

function goToProfile() {

}

function goToLogin() {
    router.push({ name: 'login' });
}

onMounted(fetchHotelData)
</script>

<style>
.bookingInfo {
    display: flex;
    flex-direction: column;
    padding: 10px;
}

.bookingInfo .hotelInfo {
    display: flex;
    flex-direction: column;
    align-items: flex-start;
    margin-bottom: 20px;
}

.bookingInfo .hotelInfo .info {
    display: flex;
    flex-direction: column;
    margin-left: 0;
    margin-top: 10px;
}

.bookingInfo .hotelInfo .name {
    font-size: 1.5rem;
    /* Используем относительный размер */
    font-weight: 600;
}

.bookingInfo .hotelInfo .location {
    font-size: 1rem;
    color: #777;
}

.bookingInfo .dates {
    display: flex;
    flex-direction: column;
    margin-top: 20px;
}

.bookingInfo .dates .item {
    display: flex;
    flex-direction: column;
    margin: 10px;
}

.bookingInfo .dates .item .header {
    font-size: 1rem;
    font-weight: 600;
}

.bookingInfo .residents {
    display: flex;
    flex-direction: column;
    margin-top: 20px;
}

.bookingInfo .residents .header {
    font-size: 1.2rem;
    font-weight: 600;
}

.bookingInfo .residents .content {
    display: flex;
    flex-direction: row;
    gap: 15px;
    flex-wrap: wrap;
}

.bookingInfo .residents .content .item {
    display: flex;
    flex-direction: column;
    margin: 10px;
}

.bookingInfo .residents .content .item .header {
    font-size: 1rem;
    font-weight: 600;
}

.bookingInfo .aviableRooms {
    display: flex;
    flex-direction: column;
    align-items: center;
    margin-top: 20px;
}

.bookingInfo .aviableRooms .header {
    font-size: 1.2rem;
    font-weight: 600;
}

.bookingInfo .aviableRooms .items {
    display: flex;
    flex-direction: row;
    align-items: center;
    justify-content: center;
    flex-wrap: wrap;
    gap: 10px;
}

.bookingInfo .aviableRooms .items .button {
    width: 64px;
    height: 64px;
    margin: 10px;
}

.bookingInfo .price {
    font-size: 1.5rem;
    /* Используем относительный размер */
    margin-top: 20px;
}

/* Медиазапросы для экранов шириной больше 600px */
@media (min-width: 600px) {
    .bookingInfo .hotelInfo {
        flex-direction: row;
    }

    .bookingInfo .hotelInfo .info {
        margin-left: 10px;
    }

    .bookingInfo .dates {
        flex-direction: row;
    }

    .bookingInfo .dates .item {
        margin: 10px;
    }

    .bookingInfo .residents .content {
        flex-direction: row;
    }

    .bookingInfo .aviableRooms .content {
        flex-direction: row;
    }
}

/* Для экранов больше 1024px */
@media (min-width: 1024px) {
    .bookingInfo .hotelInfo .name {
        font-size: 2rem;
    }

    .bookingInfo .hotelInfo .location {
        font-size: 1.2rem;
    }

    .bookingInfo .price {
        font-size: 2rem;
    }
}
</style>