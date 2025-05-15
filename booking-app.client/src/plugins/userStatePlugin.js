import { inject, ref } from "vue";

const userState = ref({
  userName: "Гость",
  roles: ["guest"],
  isAuthorized: false,
  id: ""
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
    id: model.id,
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

      await onUserLogin({ userName: data.userName, roles: data.userRole });
      return {
        userName: data.userName,
        roles: data.userRole,
        isAuthorized: true,
        id: data.id
      };
    }
  } catch (error) {
    console.log(error);
  }
}
