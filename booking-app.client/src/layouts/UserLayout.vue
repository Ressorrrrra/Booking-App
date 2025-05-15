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