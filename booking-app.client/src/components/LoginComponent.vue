<template>
    <Form v-slot="$form" :initialValues :resolver @submit="onFormSubmit" class="form">
        <div class="div">
            <InputText name="username" type="text" placeholder="Username" fluid />
            <Message v-if="$form.username?.invalid" severity="error" size="small" variant="simple">{{
                $form.username.error?.message }}</Message>
            <Password name="password" :feedback="false" />
            <Button type="submit" severity="secondary" label="Submit" />
            <p> Нет аккаунта? <span @click="goToRegistration">Зарегистрироваться</span></p>
        </div>

    </Form>

</template>

<script>
export default {
    methods: {
        goToProfile() {
            this.$router.push({ name: 'profile' });
        },
    },
}
</script>

<script setup>
import { Form } from '@primevue/forms';
import InputText from 'primevue/inputtext';
import Button from 'primevue/button';
import Message from 'primevue/message';
import Password from 'primevue/password';
import { useRouter } from 'vue-router';

const router = useRouter();

function onFormSubmit(values) {
    router.push({ name: 'profile' });
}

function goToRegistration() {
    router.push({ name: 'registration' });
}
</script>

<style>
.form {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;

}

.form .div {
    display: grid;
    grid-auto-flow: row;
    grid-row-gap: 10px;
    align-items: center;
    justify-content: center;

}
</style>
