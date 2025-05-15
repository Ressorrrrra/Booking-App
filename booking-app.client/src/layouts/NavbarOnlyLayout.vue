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