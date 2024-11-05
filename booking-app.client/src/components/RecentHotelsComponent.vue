<template>
    <div class="mainPage">
        <p class="header">Недавно просмотренные</p>
        <div class="recentHotels">
            <div class="item">
                <p>Axel Hotel & Hostel</p>
                <Avatar image="/icons/profilePic.jpg" shape="circle"></Avatar>
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
}

.mainPage .header {
    font-size: 18;
    font-weight: 700;
}

.mainPage .recentHotels {
    display: flex;
    flex-direction: row;
    align-items: center;
    justify-content: center;
}


.mainPage .recentHotels .item {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
}
</style>