<template>
    <Form v-slot="$form" :initialValues :resolver @submit="onFormSubmit" class="form">
        <p class="header">Регистрация</p>
        <div class="div">
            <IftaLabel class="field">
                <InputText name="email" type="text" placeholder="ivanov@mail.com" fluid />
                <label for="email">Эл. почта: </label>
            </IftaLabel>

            <IftaLabel class="field">
                <Password name="password" :feedback="false" />
                <label for="password">Пароль: </label>
            </IftaLabel>

            <IftaLabel class="field">
                <Password name="confirm_password" :feedback="false" />
                <label for="confirm_password">Подтвердите пароль: </label>
            </IftaLabel>

            <IftaLabel class="field">
                <InputText name="name" type="text" placeholder="Иван" fluid />
                <label for="name">Имя: </label>
            </IftaLabel>

            <IftaLabel class="field">
                <InputText name="surname" type="text" placeholder="Иванов" fluid />
                <label for="surname">Фамилия: </label>
            </IftaLabel>

            <IftaLabel class="field">
                <DatePicker name="dateOfBirth" />
                <label for="dateOfBirth">Дата рождения: </label>
            </IftaLabel>

        </div>
        <Button label="Зарегистрироваться"></Button>
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
import IftaLabel from 'primevue/iftalabel';
import DatePicker from 'primevue/datepicker';
import Password from 'primevue/password';
import { useRouter } from 'vue-router';

const router = useRouter();

function onFormSubmit(values) {
    console.log('Form submitted with:', values);
    router.push({ name: 'profile' });
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
