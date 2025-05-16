<template>
    <Toolbar class="navbar">
        <template #start>
            <Button v-if="searchIsVisible" class="button" label="Поиск" @click="goToSearch" icon="pi pi-search"
                iconPos="top" variant="link"></Button>
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
import { onMounted, ref } from 'vue';
import { useRouter } from 'vue-router';
import { Toolbar } from 'primevue';
import Button from 'primevue/button';
import { checkAuth } from '@/plugins/userStatePlugin';

const searchIsVisible = ref(true);
const router = useRouter()

function goToMainPage() {
    router.push({ name: 'mainpage' });
}

function goToSearch() {
    router.push({ name: 'search' });
}

function goToProfile() {
    router.push({ name: 'profile' });
}

async function checkUser() {
    var user = await checkAuth()
    if (user.roles.includes("hotelRepresentative"))
        searchIsVisible.value = false;
}

onMounted(checkUser)
</script>

<style scoped>
.navbar {
    position: fixed;
    bottom: 0;
    left: -0.5%;
    right: 0;
    width: 101%;
    background-color: white;
    border-top: 1px solid #e5e7eb;
    padding: 0.5rem 1rem;
    display: flex;
    justify-content: space-between;
    align-items: center;
    z-index: 1000;
}

.navbar ::v-deep(.p-toolbar) {
    width: 100%;
    padding: 0;
    background: transparent;
    border-radius: 0;
}

.button {
    flex: 1;
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    padding: 0.5rem 0;
    margin: 0;
    min-width: 0;
}

.button:hover {
    color: #3b82f6;
}

.button ::v-deep(.p-button-label) {
    font-size: 0.75rem;
    margin-top: 0.25rem;
}
</style>