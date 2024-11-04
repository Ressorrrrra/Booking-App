<template>
    <Form v-slot="$form" :initialValues :resolver @submit="onFormSubmit" class="flex flex-col gap-4 w-full sm:w-56">
        <div>
            <InputText name="username" type="text" placeholder="Username" fluid />
            <Message v-if="$form.username?.invalid" severity="error" size="small" variant="simple">{{
                $form.username.error?.message }}</Message>
            <Password name="password1" :feedback="false" />
            <Button type="submit" severity="secondary" label="Submit" />
        </div>
        <Fieldset legend="Form States" class="h-80 overflow-auto">
            <pre class="whitespace-pre-wrap">{{ $form }}</pre>
        </Fieldset>
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
    console.log('Form submitted with:', values);
    router.push({ name: 'profile' });
}
</script>
