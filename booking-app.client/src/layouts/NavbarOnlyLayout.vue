<template>
    <div class="layout">
        <main>
            <slot />
        </main>
        <Navbar />
    </div>
</template>

<script setup>
import Navbar from '@/components/NavbarComponent.vue';
</script>

<style>
main {
    margin-bottom: 80px;
}
</style>