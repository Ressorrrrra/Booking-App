<template>
    <Toolbar class="navbar">
        <template #start>
            <Button label="Поиск" @click="goToSearch"></Button>
        </template>

        <template #center>
            <Button label="Главная" @click="goToMainPage"></Button>
        </template>

        <template #end>
            <Button label="Мой профиль" @click="goToProfile"></Button>
        </template>
    </Toolbar>
</template>

<script setup>
import { Toolbar } from 'primevue';
import Button from 'primevue/button';
import { useRouter } from 'vue-router';

const router = useRouter();

function goToMainPage() {
    router.push({ name: 'mainpage' });
}

function goToSearch() {
    router.push({ name: 'search' });
}

function goToProfile() {
    router.push({ name: 'profile' });
}
</script>

<style>
.navbar {
    justify-content: center;
    align-items: center;
    margin-top: 20px;
}
</style>