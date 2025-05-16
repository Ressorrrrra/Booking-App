<template>
    <div class="layout">
        <TopBar />
        <main>
            <slot />
        </main>
        <Navbar />
    </div>
</template>

<script setup>
import TopBar from '@/components/TopBarComponent.vue';
import Navbar from '@/components/NavbarComponent.vue';
</script>

<style>
main {
    margin-bottom: 80px;
    margin-top: 60px;
}
</style>