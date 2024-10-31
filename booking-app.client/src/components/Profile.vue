<template>
    <div class="frame">
        <div class="list-item">
            <div class="text-and-image">
                <div class="image" />

                <div class="content">
                    <div class="title-description">
                        <div class="column">
                            <div class="name">Александр Маслаев</div>

                            <div class="email">Эл.почта: maslayev@mail.ru</div>

                            <p class="phone-number">
                                Номер телефона: <br />
                                +7 (800) - 555 - 55 - 25
                            </p>

                            <div class="icon-button">
                                <div class="container">
                                    <div class="state-layer">
                                        <Icon class="icon-instance" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="text-wrapper">Ваши бронирования</div>

        <div class="swipeable-area">
            <div class="div">
                <div class="text-and-image-wrapper">
                    <div class="text-and-image-2">
                        <div class="image-2" />

                        <div class="content">
                            <div class="title-description-2">
                                <div class="name-2">Axel Hotel &amp; Hostel</div>

                                <div class="text-wrapper-2">19.10.2024 - 23.10.2024</div>

                                <div class="text-wrapper-2">Статус: ожидает оплаты</div>

                                <button class="button">
                                    <div class="label-text-wrapper">
                                        <div class="label-text">Информация о заказе</div>
                                    </div>
                                </button>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="text-and-image-wrapper">
                    <div class="text-and-image-2">
                        <div class="image-3" />

                        <div class="content">
                            <div class="title-description-3">
                                <div class="name-2">Valo</div>

                                <div class="date">04.10.2024 - 12.10.2024</div>

                                <div class="status">Статус: оплачено</div>

                                <button class="state-layer-wrapper">
                                    <div class="label-text-wrapper">
                                        <div class="label-text">Информация о заказе</div>
                                    </div>
                                </button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import Icon from './icons/IconCommunity.vue'
export default {
    name: 'Frame',
    components: {
        Icon
    }
};
</script>

<style>
.frame {
    align-items: flex-end;
    display: flex;
    flex-direction: column;
    position: relative;
}

.frame .list-item {
    align-items: flex-start;
    border-radius: 12px;
    display: flex;
    flex: 0 0 auto;
    flex-direction: column;
    gap: 4px;
    padding: 0px 0px 10px;
    position: relative;
    width: 430px;
}

.frame .text-and-image {
    align-items: flex-start;
    display: flex;
    flex: 0 0 auto;
    gap: 16px;
    padding: 0px 5px;
    position: relative;
    width: 430px;
}

.frame .image {
    background-image: url(./image.png);
    background-position: 50% 50%;
    background-size: cover;
    border-radius: 16px;
    height: 120px;
    position: relative;
    width: 120px;
}

.frame .content {
    align-items: flex-start;
    align-self: stretch;
    display: flex;
    flex: 1;
    flex-direction: column;
    flex-grow: 1;
    gap: 8px;
    justify-content: space-around;
    position: relative;
}

.frame .title-description {
    align-items: flex-start;
    display: flex;
    flex: 0 0 auto;
    flex-direction: column;
    gap: 4px;
    position: relative;
    width: 260px;
}

.frame .column {
    align-content: space-between;
    align-items: flex-start;
    display: flex;
    flex-wrap: wrap;
    height: 160px;
    justify-content: center;
    margin-right: -20.00px;
    position: relative;
    width: 280px;
}

.frame .name {
    color: #1d1b20;
    font-family: var(--m3-title-large-font-family);
    font-size: var(--m3-title-large-font-size);
    font-style: var(--m3-title-large-font-style);
    font-weight: var(--m3-title-large-font-weight);
    letter-spacing: var(--m3-title-large-letter-spacing);
    line-height: var(--m3-title-large-line-height);
    margin-top: -1.00px;
    position: relative;
    width: 260px;
}

.frame .email {
    color: #1d1b20;
    font-family: var(--m3-title-large-font-family);
    font-size: var(--m3-title-large-font-size);
    font-style: var(--m3-title-large-font-style);
    font-weight: var(--m3-title-large-font-weight);
    letter-spacing: var(--m3-title-large-letter-spacing);
    line-height: var(--m3-title-large-line-height);
    position: relative;
    width: 260px;
}

.frame .phone-number {
    color: #1d1b20;
    font-family: var(--m3-title-large-font-family);
    font-size: var(--m3-title-large-font-size);
    font-style: var(--m3-title-large-font-style);
    font-weight: var(--m3-title-large-font-weight);
    letter-spacing: var(--m3-title-large-letter-spacing);
    line-height: var(--m3-title-large-line-height);
    position: relative;
    width: fit-content;
}

.frame .icon-button {
    align-items: center;
    display: flex;
    flex-direction: column;
    gap: 10px;
    height: 48px;
    justify-content: center;
    padding: 4px;
    position: relative;
    width: 48px;
}

.frame .container {
    align-items: center;
    background-color: #65558f;
    border-radius: 100px;
    display: inline-flex;
    flex: 0 0 auto;
    gap: 10px;
    justify-content: center;
    overflow: hidden;
    position: relative;
}

.frame .state-layer {
    align-items: center;
    display: inline-flex;
    flex: 0 0 auto;
    gap: 10px;
    justify-content: center;
    padding: 8px;
    position: relative;
}

.frame .icon-instance {
    height: 24px !important;
    position: relative !important;
    width: 24px !important;
}

.frame .text-wrapper {
    color: #1d1b20;
    font-family: var(--m3-title-large-font-family);
    font-size: var(--m3-title-large-font-size);
    font-style: var(--m3-title-large-font-style);
    font-weight: var(--m3-title-large-font-weight);
    height: 28px;
    letter-spacing: var(--m3-title-large-letter-spacing);
    line-height: var(--m3-title-large-line-height);
    position: relative;
    white-space: nowrap;
    width: 420px;
}

.frame .swipeable-area {
    align-items: flex-start;
    align-self: stretch;
    display: flex;
    flex: 0 0 auto;
    gap: 16px;
    padding: 10px;
    position: relative;
    width: 100%;
}

.frame .div {
    align-items: flex-start;
    display: flex;
    flex: 1;
    flex-direction: column;
    flex-grow: 1;
    gap: 8px;
    position: relative;
}

.frame .text-and-image-wrapper {
    align-items: flex-start;
    align-self: stretch;
    border-radius: 12px;
    display: flex;
    flex-direction: column;
    gap: 4px;
    height: 120px;
    position: relative;
    width: 100%;
}

.frame .text-and-image-2 {
    align-items: flex-start;
    align-self: stretch;
    display: flex;
    flex: 0 0 auto;
    gap: 16px;
    position: relative;
    width: 100%;
}

.frame .image-2 {
    background-image: url(./image-2.png);
    background-position: 50% 50%;
    background-size: cover;
    border-radius: 16px;
    height: 120px;
    position: relative;
    width: 120px;
}

.frame .title-description-2 {
    align-items: flex-start;
    align-self: stretch;
    display: flex;
    flex: 0 0 auto;
    flex-direction: column;
    gap: 4px;
    position: relative;
    width: 100%;
}

.frame .name-2 {
    align-self: stretch;
    color: #1d1b20;
    font-family: var(--m3-title-large-font-family);
    font-size: var(--m3-title-large-font-size);
    font-style: var(--m3-title-large-font-style);
    font-weight: var(--m3-title-large-font-weight);
    letter-spacing: var(--m3-title-large-letter-spacing);
    line-height: var(--m3-title-large-line-height);
    margin-top: -1.00px;
    position: relative;
}

.frame .text-wrapper-2 {
    -webkit-box-orient: vertical;
    -webkit-line-clamp: 2;
    align-self: stretch;
    color: #49454f;
    display: -webkit-box;
    font-family: var(--m3-body-medium-font-family);
    font-size: var(--m3-body-medium-font-size);
    font-style: var(--m3-body-medium-font-style);
    font-weight: var(--m3-body-medium-font-weight);
    letter-spacing: var(--m3-body-medium-letter-spacing);
    line-height: var(--m3-body-medium-line-height);
    overflow: hidden;
    position: relative;
    text-overflow: ellipsis;
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

.frame .label-text {
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

.frame .image-3 {
    background-image: url(./image-3.png);
    background-position: 50% 50%;
    background-size: cover;
    border-radius: 16px;
    height: 120px;
    position: relative;
    width: 120px;
}

.frame .title-description-3 {
    align-items: flex-start;
    align-self: stretch;
    display: flex;
    flex-direction: column;
    gap: 4px;
    height: 113px;
    position: relative;
    width: 100%;
}

.frame .date {
    align-self: stretch;
    color: #49454f;
    font-family: var(--m3-body-medium-font-family);
    font-size: var(--m3-body-medium-font-size);
    font-style: var(--m3-body-medium-font-style);
    font-weight: var(--m3-body-medium-font-weight);
    letter-spacing: var(--m3-body-medium-letter-spacing);
    line-height: var(--m3-body-medium-line-height);
    position: relative;
}

.frame .status {
    -webkit-box-orient: vertical;
    -webkit-line-clamp: 1;
    color: #49454f;
    display: -webkit-box;
    font-family: var(--m3-body-medium-font-family);
    font-size: var(--m3-body-medium-font-size);
    font-style: var(--m3-body-medium-font-style);
    font-weight: var(--m3-body-medium-font-weight);
    height: 20px;
    letter-spacing: var(--m3-body-medium-letter-spacing);
    line-height: var(--m3-body-medium-line-height);
    overflow: hidden;
    position: relative;
    text-overflow: ellipsis;
    white-space: nowrap;
    width: 244px;
}

.frame .state-layer-wrapper {
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
    margin-bottom: -7.00px;
    overflow: hidden;
    position: relative;
}
</style>