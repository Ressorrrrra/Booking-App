<template>
    <Form v-slot="$form" :initialValues :resolver @submit="onFormSubmit" class="form">
        <p class="headerForm">Авторизация</p>
        <div class="div">
            <IftaLabel>
                <label>Логин</label>
                <InputText name="username" type="text" fluid />
            </IftaLabel>
            <IftaLabel>
                <Password name="password" :feedback="false" fluid />
                <label>Пароль</label>
            </IftaLabel>

            <Button type="submit" label="Войти" />
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
import Password from 'primevue/password';
import IftaLabel from 'primevue/iftalabel';
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

.headerForm {
    font-size: large;
    font-weight: 700;
}

.form .div {
    display: grid;
    grid-auto-flow: row;
    grid-row-gap: 10px;
    align-items: center;
    justify-content: center;

}
</style>
