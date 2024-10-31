<template>
    <div class="frame">
        <div class="name">Вход</div>

        <div class="div">
            <p class="p">
                <span class="span">Электронная почта:</span>
            </p>

            <input v-model="password" placeholder="" class="rounded-input" />
        </div>

        <div class="div">
            <p class="p">
                <span class="span">Пароль:</span>
            </p>

            <input v-model="password" placeholder="" class="rounded-input" />
        </div>

        <button class="button">
            <div class="label-text-wrapper">
                <div class="label-text-2">Войти</div>
            </div>
        </button>

        <p class="name-2">
            <span class="text-wrapper-3">Нет аккаунта? </span>
            <span class="text-wrapper-4">Зарегистрироваться</span>
        </p>
    </div>
</template>

<script>
export default {
    name: "Frame"
};
</script>


<style>
.frame {
    align-items: center;
    display: flex;
    flex-direction: column;
    justify-content: center;
    position: relative;
}

.div {
    display: flex;
    align-items: baseline;
    gap: 8px;
}

.rounded-input {
    padding: 10px;
    border-radius: 20px;
    border: 1px solid #ccc;
    outline: none;
    width: 50%;
    box-sizing: border-box;
}

.rounded-input:focus {
    border-color: #66afe9;
    box-shadow: 0 0 5px rgba(102, 175, 233, 0.5);
}

.frame .name {
    color: #1d1b20;
    font-family: var(--m3-title-large-font-family);
    font-size: var(--m3-title-large-font-size);
    font-style: var(--m3-title-large-font-style);
    font-weight: var(--m3-title-large-font-weight);
    letter-spacing: var(--m3-title-large-letter-spacing);
    line-height: var(--m3-title-large-line-height);
    position: relative;
    white-space: nowrap;
    width: fit-content;
}

.frame .column {
    align-items: center;
    align-self: stretch;
    display: flex;
    flex: 0 0 auto;
    flex-wrap: wrap;
    gap: 38px 20px;
    justify-content: center;
    padding: 15px 20px;
    position: relative;
    width: 100%;
}

.frame .text-wrapper {
    color: #1d1b20;
    font-family: var(--m3-title-small-font-family);
    font-size: var(--m3-title-small-font-size);
    font-style: var(--m3-title-small-font-style);
    font-weight: var(--m3-title-small-font-weight);
    letter-spacing: var(--m3-title-small-letter-spacing);
    line-height: var(--m3-title-small-line-height);
    position: relative;
    white-space: nowrap;
    width: fit-content;
}

.frame .input-chip {
    align-items: center;
    border: 1px solid;
    border-color: #cac4d0;
    border-radius: 8px;
    display: flex;
    height: 32px;
    justify-content: space-around;
    overflow: hidden;
    padding: 10px;
    position: relative;
    width: 150px;
}

.frame .state-layer {
    align-items: center;
    display: inline-flex;
    flex: 0 0 auto;
    gap: 8px;
    justify-content: center;
    margin-bottom: -10.00px;
    margin-top: -10.00px;
    padding: 6px 12px;
    position: relative;
}

.frame .label-text {
    color: #49454f;
    font-family: var(--m3-label-large-font-family);
    font-size: var(--m3-label-large-font-size);
    font-style: var(--m3-label-large-font-style);
    font-weight: var(--m3-label-large-font-weight);
    letter-spacing: var(--m3-label-large-letter-spacing);
    line-height: var(--m3-label-large-line-height);
    margin-right: -1.00px;
    margin-top: -1.00px;
    position: relative;
    text-align: center;
    white-space: nowrap;
    width: fit-content;
}

.frame .div {
    align-items: baseline;

    align-self: stretch;
    display: flex;
    flex: 0 0 auto;
    flex-wrap: wrap;
    gap: 38px 10px;
    justify-content: center;
    padding: 15px 20px 15px 110px;
    position: relative;
    width: 100%;
}


.frame .p {
    color: #1d1b20;
    font-family: "Roboto-Medium", Helvetica;
    font-size: 14px;
    font-weight: 400;
    line-height: 14px;
    margin-top: -1.00px;
    position: relative;
    width: fit-content;
}

.frame .span {
    font-family: var(--m3-title-small-font-family);
    font-size: var(--m3-title-small-font-size);
    font-style: var(--m3-title-small-font-style);
    font-weight: var(--m3-title-small-font-weight);
    letter-spacing: var(--m3-title-small-letter-spacing);
    line-height: var(--m3-title-small-line-height);
}

.frame .text-wrapper-2 {
    font-family: var(--m3-title-large-font-family);
    font-size: var(--m3-title-large-font-size);
    font-style: var(--m3-title-large-font-style);
    font-weight: var(--m3-title-large-font-weight);
    letter-spacing: var(--m3-title-large-letter-spacing);
    line-height: var(--m3-title-large-line-height);
}

.frame .button {
    all: unset;
    align-items: center;
    background-color: #65558f;
    border-radius: 100px;
    box-sizing: border-box;
    display: inline-flex;
    flex-direction: column;
    gap: 8px;
    height: 40px;
    justify-content: center;
    overflow: hidden;
    position: relative;
}

.frame .label-text-wrapper {
    align-items: center;
    align-self: stretch;
    display: flex;
    flex: 1;
    flex-grow: 1;
    gap: 8px;
    justify-content: center;
    padding: 10px 24px;
    position: relative;
    width: 100%;
}

.frame .label-text-2 {
    color: #ffffff;
    font-family: var(--m3-label-large-font-family);
    font-size: var(--m3-label-large-font-size);
    font-style: var(--m3-label-large-font-style);
    font-weight: var(--m3-label-large-font-weight);
    letter-spacing: var(--m3-label-large-letter-spacing);
    line-height: var(--m3-label-large-line-height);
    margin-top: -1.00px;
    position: relative;
    text-align: center;
    white-space: nowrap;
    width: fit-content;
}

.frame .name-2 {
    margin-top: 20px;
    color: transparent;
    font-family: var(--m3-body-medium-font-family);
    font-size: var(--m3-body-medium-font-size);
    font-style: var(--m3-body-medium-font-style);
    font-weight: var(--m3-body-medium-font-weight);
    height: 40px;
    letter-spacing: var(--m3-body-medium-letter-spacing);
    line-height: var(--m3-body-medium-line-height);
    position: relative;
    width: 241px;
}

.frame .text-wrapper-3 {
    color: #1d1b20;
    font-family: var(--m3-body-medium-font-family);
    font-size: var(--m3-body-medium-font-size);
    font-style: var(--m3-body-medium-font-style);
    font-weight: var(--m3-body-medium-font-weight);
    letter-spacing: var(--m3-body-medium-letter-spacing);
    line-height: var(--m3-body-medium-line-height);
}

.frame .text-wrapper-4 {
    color: #3c2d63;
    font-family: var(--m3-body-medium-font-family);
    font-size: var(--m3-body-medium-font-size);
    font-style: var(--m3-body-medium-font-style);
    font-weight: var(--m3-body-medium-font-weight);
    letter-spacing: var(--m3-body-medium-letter-spacing);
    line-height: var(--m3-body-medium-line-height);
    text-decoration: underline;
}
</style>