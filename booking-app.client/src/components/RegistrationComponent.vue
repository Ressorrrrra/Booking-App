<template>
    <Form :initialValues="initialValues" :resolver @submit="onFormSubmit" class="form">
        <p class="header">Регистрация</p>
        <div class="div">
            <IftaLabel class="field">
                <InputText name="email" type="text" placeholder="ivanov@mail.com" fluid :invalid="failedReg" />
                <label for="email">Эл. почта: </label>
            </IftaLabel>

            <IftaLabel class="field">
                <Password name="password" :feedback="false" :invalid="failedReg" fluid />
                <label for="password">Пароль: </label>
            </IftaLabel>

            <IftaLabel class="field">
                <Password name="confirmPassword" :feedback="false" fluid :invalid="failedReg" />
                <label for="confirm_password">Подтвердите пароль: </label>
            </IftaLabel>

        </div>
        <Message v-if="failedReg">{{ errorMessage }}</Message>
        <Button label="Зарегистрироваться" type="submit"></Button>
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
import { ref } from 'vue';
import { Form } from '@primevue/forms';
import InputText from 'primevue/inputtext';
import Button from 'primevue/button';
import IftaLabel from 'primevue/iftalabel';
import { Message } from 'primevue';
import Password from 'primevue/password';
import { useRouter } from 'vue-router';

const router = useRouter();

var failedReg = ref(false);

var regRequest = {
    email: "",
    password: ""
}

const initialValues = {
    email: "",
    password: "",
    confirmPassword: ""
}

var errorMessage = ref("");

async function onFormSubmit(form) {
    if (form.states.password.value != form.states.confirmPassword.value) {
        failedReg.value = true;
        errorMessage.value = "Пароли не совпадают"
    }
    else if (form.states.password.value === "" || form.states.email.value === "" || form.states.confirmPassword.value === "") {
        failedReg.value = true;
        errorMessage.value = "Пожалуйста, заполните все поля"
    }
    else {
        try {
            const url = `https://localhost:7273/api/Accounts/register`;

            regRequest = {
                email: form.states.email.value,
                password: form.states.password.value
            }

            const response = await fetch(url, {
                method: 'POST', // Метод POST для поиска, GET для всех
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(regRequest)
            });

            if (response.ok) {
                goToLogin();
            }
            else {
                failedReg.value = true;
                errorMessage.value = "Не удалось зарегистрироватьcя."
                throw new Error('Ошибка при попытке авторизации');
            }
        } catch (error) {
            console.error('Ошибка:', error);
        }
    }
}

function goToLogin() {
    router.push({ name: 'login' });
}
</script>

<style>
.form {
    display: flex;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    padding: 10px;
    /* Добавляем отступы для лучшего восприятия */
}

/* Медиазапрос для мобильных устройств */
@media (max-width: 600px) {
    .form {
        padding: 5px;
        /* Уменьшаем отступы на мобильных устройствах */
    }

    .form .header {
        font-size: 18px;
        /* Уменьшаем размер шрифта для мобильных устройств */
        text-align: center;
        /* Выравниваем заголовок по центру */
    }

    .form .div {
        margin: 5px;
        /* Уменьшаем отступы на мобильных */
    }

    .form .div .field {
        grid-template-columns: 1fr;
        /* Элементы в поле формы будут расположены по одному столбцу */
    }
}

/* Медиазапрос для планшетов и экранов от 600px */
@media (min-width: 600px) {
    .form .header {
        font-size: 24px;
        /* Стандартный размер шрифта для планшетов */
    }

    .form .div .field {
        grid-template-columns: 1fr 1fr;
        /* На устройствах больше 600px элементы будут располагаться по два в ряд */
    }
}

/* Медиазапрос для экрана от 1024px */
@media (min-width: 1024px) {
    .form .header {
        font-size: 28px;
        /* Увеличиваем размер шрифта на десктопах */
    }

    .form .div {
        margin: 20px;
        /* Увеличиваем отступы на десктопах */
    }

    .form .div .field {
        grid-template-columns: 1fr 1fr 1fr;
        /* Для десктопов расположение в три столбца */
    }
}

.form .header {
    font-size: 24px;
    font-weight: 600;
    margin-bottom: 20px;
    /* Добавляем отступ снизу для отделения заголовка от содержимого */
}

.form .div {
    display: grid;
    grid-auto-flow: row;
    grid-row-gap: 10px;
    align-items: center;
    justify-content: center;
    margin: 10px;
}

.form .div .field {
    display: grid;
    grid-auto-flow: column;
    grid-column-gap: 10px;
    margin: 10px;
}
</style>
