<template>
    <Toolbar class="navbar">
        <template #start>
            <Button class="button" label="Поиск" @click="goToSearch" icon="pi pi-search" iconPos="top"
                variant="link"></Button>
        </template>

        <template #center>
            <Button class="button" label="Главная" @click="goToMainPage" icon="pi pi-home" iconPos="top"
                variant="link"></Button>
        </template>

        <template #end>
            <Button class="button" label="Профиль" @click="goToProfile" icon="pi pi-user" iconPos="top"
                variant="link"></Button>
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
    width: 105%;
    height: 10%;
    margin-top: 100px;
    position: fixed;
    bottom: 0;
    z-index: 100;
}

.navbar .button {}
</style>