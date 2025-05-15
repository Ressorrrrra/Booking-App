<template>
    <Form :initialValues="initialValues" :validateOnSubmit="true" :validateOnValueUpdate="false" :validateOnBlur="true"
        @submit="onFormSubmit" class="form">
        <p class="headerForm">Авторизация</p>
        <div class="div">
            <FormField v-slot="$fieldEmail" :resolver="zodUserNameResolver" initialValue="">
                <IftaLabel>
                    <label>Логин</label>
                    <InputText name="email" type="text" fluid :invalid="failedLogin" />
                </IftaLabel>
                <Message v-if="$fieldEmail?.invalid" severity="error" size="small" variant="simple">{{
                    $fieldEmail.error?.message }}</Message>
            </FormField>
            <FormField v-slot="$fieldPassword">
                <IftaLabel>
                    <Password name="password" :feedback="false" fluid :invalid="failedLogin" />
                    <label>Пароль</label>
                </IftaLabel>
                <Message v-if="$fieldPassword?.invalid" severity="error" size="small" variant="simple">{{
                    $fieldPassword.error?.message }}</Message>
            </FormField>

            <Button type="submit" label="Войти" />
            <Message v-if="failedLogin">{{ errorMessage }}</Message>
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
import { onMounted, ref, inject } from 'vue';
import { Form } from '@primevue/forms';
import InputText from 'primevue/inputtext';
import Button from 'primevue/button';
import Password from 'primevue/password';
import IftaLabel from 'primevue/iftalabel';
import { useRouter } from 'vue-router';
import { Message } from 'primevue';
import { checkAuth, onUserLogin } from '@/plugins/userStatePlugin';

var failedLogin = ref(false);
var errorMessage = ref("");

const router = useRouter();
const globalVar = inject('globalVar')

const loginRequest = {
    userName: "",
    password: "",
    rememberMe: true
}

const initialValues = {
    email: "",
    password: "",
}

async function onFormSubmit(form) {
    loginRequest.email = form.states.email.value
    loginRequest.password = form.states.password.value
    try {
        const url = `${globalVar.apiUrl}/Accounts/login`;

        const response = await fetch(url, {
            credentials: "include",
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(loginRequest)
        });

        if (response.ok) {
            const data = await response.json();
            console.log(data)
            onUserLogin({ userName: data.userName, roles: data.userRole })
            console.log(response)
            goToMainPage()
        }
        else if (response.status === 401) {
            failedLogin.value = true;
            errorMessage.value = "Неправильно указан логин и/или пароль"
        }
        else throw new Error('Ошибка при попытке авторизации');
    } catch (error) {
        console.error('Ошибка:', error);
        errorMessage.value = error;
    }

}

function goToMainPage() {
    router.push({ name: 'mainpage' });
}

function goToRegistration() {
    router.push({ name: 'registration' });
}

async function _checkAuth() {
    console.log(54)
    const auth = await checkAuth()
    if (auth.isAuthorized) {

        await goToMainPage()
    }
}

onMounted(_checkAuth)
</script>

<style>
.form {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    padding: 20px;
    min-height: 100vh;
}

.headerForm {
    font-size: 1.5rem;
    font-weight: 700;
    margin-bottom: 20px;
}

.form .div {
    display: grid;
    grid-template-columns: 1fr;
    gap: 15px;
    width: 100%;
    align-items: center;
    justify-content: center;
}

@media (min-width: 600px) {
    .form .div {
        grid-template-columns: 1fr 1fr;
    }
}

@media (min-width: 768px) {
    .headerForm {
        font-size: 2rem;
    }
}
</style>
