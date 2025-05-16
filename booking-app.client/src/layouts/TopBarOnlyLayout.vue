<template>
    <div class="layout">
        <TopBar />
        <main>
            <slot />
        </main>
    </div>
</template>

<script setup>
import TopBar from '@/components/TopBarComponent.vue';
</script>

<style>
main {
    margin-top: 60px;
}
</style>