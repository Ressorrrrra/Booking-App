import { inject, ref } from "vue";

const userState = ref({
  userName: "Гость",
  roles: ["guest"],
  isAuthorized: false
});

export const userStatePlugin = {
  install(app) {
    app.provide("userState", userState);
  }
};

export function useUser() {
  return inject("userState");
}

export function onUserLogin(model) {
  userState.value = {
    userName: model.userName,
    roles: model.roles,
    isAuthorized: true
  };
}

export async function checkAuth() {
  try {
    const url = `https://localhost:7273/api/Accounts/isauthenticated`;

    const response = await fetch(url, {
      credentials: "include",
      method: "POST",
      headers: {
        "Content-Type": "application/json"
      }
    });

    if (response.ok) {
      const data = await response.json();
      onUserLogin({ userName: data.userName, roles: data.userRole });
    }
  } catch (error) {}
}
