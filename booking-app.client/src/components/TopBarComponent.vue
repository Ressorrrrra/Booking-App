<template>
    <Toolbar class="navbar">
        <template #start>
            <Button class="button" @click="router.goBack" icon="pi pi-arrow-left" iconPos="top" variant="link"></Button>
        </template>
    </Toolbar>
</template>

<script setup>
import { Toolbar } from 'primevue';
import Button from 'primevue/button';
import { useRouter } from 'vue-router';

const router = useRouter();
</script>

<style scoped>
.navbar {
    position: fixed;
    top: 0;
    left: -0.5%;
    right: 0;
    width: 101%;
    height: 9%;
    background-color: white;
    border-top: 1px solid #e5e7eb;
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