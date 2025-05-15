<template>
    <Form :resolver @submit="onFormSubmit" class="hotelInfo">
        <div class="div">
            <div class="inputs">
                <Image :src="avatarUrl || 'https://placehold.co/300x200?text=Фото+отеля'" alt="Аватар отеля"
                    class="avatar-image" width="200" height="150" preview />
                <FloatLabel variant="on">
                    <InputText v-model="name"></InputText>
                    <label>Название отеля</label>
                    <Message v-if="name.invalid" severity="error" size="small" variant="simple">Введите название
                    </Message>
                </FloatLabel>

                <FloatLabel variant="on">
                    <InputText v-model="country"></InputText>
                    <label>Страна</label>
                    <Message v-if="country.invalid" severity="error" size="small" variant="simple">Введите страну
                    </Message>
                </FloatLabel>

                <FloatLabel variant="on">
                    <InputText v-model="city"></InputText>
                    <label>Город/населённый пункт</label>
                    <Message v-if="city.invalid" severity="error" size="small" variant="simple">Введите город
                    </Message>
                </FloatLabel>

                <FloatLabel variant="on">
                    <InputText v-model="avatarUrl"></InputText>
                    <label>Ссылка на аватарку отеля</label>
                    <Message v-if="avatarUrl.invalid" severity="error" size="small" variant="simple">Введите
                        ссылку
                    </Message>
                </FloatLabel>
            </div>
        </div>

        <FloatLabel variant="on">
            <Textarea class="description" v-model="description" rows="7" cols="30" />
            <label>Описание</label>
            <Message v-if="description.invalid" severity="error" size="small" variant="simple">Опишите отель
            </Message>
        </FloatLabel>

        <div class="tags-section">
            <h3>Теги отеля</h3>
            <div class="tags-input">
                <InputText v-model="newTag" @keydown.enter="addTag" placeholder="Введите тег и нажмите Enter">
                </InputText>
                <Button label="Добавить" @click="addTag" size="small"></Button>
            </div>
            <div class="tags-list">
                <Chip v-for="(tag, index) in tags" :key="index" :label="tag" removable @remove="removeTag(index)" />
            </div>
        </div>

        <div class="photos-section">
            <h3>Фотографии отеля</h3>
            <div class="photos-input">
                <InputText v-model="newPhotoUrl" placeholder="Введите ссылку на фото"></InputText>
                <Button label="Добавить" @click="addPhoto" size="small"></Button>
            </div>
            <div class="photos-preview">
                <img v-for="(photo, index) in photos" :key="index" :src="photo" alt="Фото отеля" class="photo-preview"
                    @click="removePhoto(index)">
                <Message v-if="photos.length === 0" severity="info" size="small" variant="simple">Добавьте фотографии
                    отеля</Message>
            </div>
        </div>

        <Button type="submit" :label="submitButtonLabel"></Button>
    </Form>
</template>

<script setup>
import { ref, inject, onMounted } from 'vue';
import { useRouter, useRoute } from 'vue-router';
import { Form } from '@primevue/forms';
import Textarea from 'primevue/textarea';
import { FloatLabel } from 'primevue';
import InputText from 'primevue/inputtext';
import Message from 'primevue/message';
import Button from 'primevue/button';
import Chip from 'primevue/chip';
import Image from 'primevue/image';

const router = useRouter();
const route = useRoute();
const globalVar = inject('globalVar');

const hotelId = ref(route.params.id || null);
const isEditMode = ref(!!hotelId.value);
const submitButtonLabel = ref(isEditMode.value ? 'Обновить отель' : 'Создать отель');

const name = ref('');
const country = ref('');
const city = ref('');
const description = ref('');
const avatarUrl = ref('');
const newTag = ref('');
const tags = ref([]);
const newPhotoUrl = ref('');
const photos = ref([]);

// Загрузка данных отеля при редактировании
onMounted(async () => {
    console.log(route.params)
    if (isEditMode.value) {
        try {
            const response = await fetch(`${globalVar.apiUrl}/Hotels/${hotelId.value}`, {
                credentials: "include"
            });

            if (!response.ok) {
                throw new Error('Ошибка загрузки данных отеля');
            }

            const hotelData = await response.json();

            // Заполняем поля данными отеля
            name.value = hotelData.name;
            country.value = hotelData.country;
            city.value = hotelData.city;
            description.value = hotelData.description;
            tags.value = [...hotelData.tags || []];

            // Обрабатываем фотографии
            if (hotelData.pictureLinks && hotelData.pictureLinks.length > 0) {
                avatarUrl.value = hotelData.pictureLinks[0];
                photos.value = [...hotelData.pictureLinks.slice(1)];
            }

        } catch (error) {
            console.error('Ошибка при загрузке данных отеля:', error);
        }
    }
});

function addTag() {
    if (newTag.value.trim() && !tags.value.includes(newTag.value.trim())) {
        tags.value.push(newTag.value.trim());
        newTag.value = '';
    }
}

function removeTag(index) {
    tags.value.splice(index, 1);
}

function addPhoto() {
    if (newPhotoUrl.value.trim() && !photos.value.includes(newPhotoUrl.value.trim())) {
        photos.value.push(newPhotoUrl.value.trim());
        newPhotoUrl.value = '';
    }
}

function removePhoto(index) {
    photos.value.splice(index, 1);
}

async function onFormSubmit() {
    try {
        const url = isEditMode.value
            ? `${globalVar.apiUrl}/Hotels/${hotelId.value}`
            : `${globalVar.apiUrl}/Hotels`;

        const method = isEditMode.value ? 'PUT' : 'POST';

        const hotelData = {
            name: name.value,
            country: country.value,
            city: city.value,
            description: description.value,
            tags: [...tags.value],
            pictureLinks: [avatarUrl.value, ...photos.value]
        };

        console.log(JSON.stringify(hotelData));

        const response = await fetch(url, {
            credentials: "include",
            method: method,
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(hotelData)
        });

        console.log(response);

        if (!response.ok) {
            throw new Error(`Ошибка HTTP: ${response.status}`);
        }

        router.goBack();

    } catch (error) {
        console.error('Ошибка при сохранении отеля:', error);
    }
}
</script>

<style>
.hotelInfo {
    display: flex;
    gap: 20px;
    flex-direction: column;
    align-items: center;
    justify-content: center;
    max-width: 800px;
    margin: 0 auto;
    padding: 20px;
}

.hotelInfo .div {
    display: flex;
    flex-direction: row;
    align-items: center;
}

.hotelInfo .div .avatar-image {
    width: 200px;
    height: 150px;
    object-fit: cover;
    border-radius: 8px;
    border: 1px solid #ddd;
}

.hotelInfo .div .inputs {
    display: flex;
    flex-direction: column;
    gap: 10px;
}

.hotelInfo .description {
    width: 100%;
}

.tags-section,
.photos-section {
    width: 100%;
    display: flex;
    flex-direction: column;
    gap: 10px;
}

.tags-input,
.photos-input {
    display: flex;
    gap: 10px;
    align-items: center;
}

.tags-list {
    display: flex;
    flex-wrap: wrap;
    gap: 8px;
}

.photos-preview {
    display: grid;
    grid-template-columns: repeat(auto-fill, minmax(150px, 1fr));
    gap: 10px;
    margin-top: 10px;
}

.photo-preview {
    width: 100%;
    height: 150px;
    object-fit: cover;
    border-radius: 4px;
    cursor: pointer;
    transition: opacity 0.2s;
}

.photo-preview:hover {
    opacity: 0.8;
}

/* Адаптивные стили */
@media (max-width: 600px) {

    .tags-input,
    .photos-input {
        flex-direction: column;
        align-items: stretch;
    }

    .photos-preview {
        grid-template-columns: repeat(2, 1fr);
    }
}
</style>