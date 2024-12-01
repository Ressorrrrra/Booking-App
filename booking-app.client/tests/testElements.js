import puppeteer from "puppeteer";
async function testApp() {
  console.log("Запустить браузер");
  const browser = await puppeteer.launch({
    headless: false,
    slowMo: 100
  });
  console.log("Открыть вкладку браузера");
  const page = await browser.newPage();
  console.log("Открыть главную страницу");
  await page.goto("https://localhost:5173/mainpage");
  console.log("Задать разрешение страницы");
  await page.setViewport({ width: 360, height: 740 });
  await page.screenshot({ path: "testApp.png" });
  const recentHotels = await page.$("#app > main > div > div.mainPage");
  if (!recentHotels) {
    console.log("Не найден элемент со спиcком недавно просмотренных отелей");
  }

  const popularHotels = await page.$("#app > main > div > div.mainPage");
  if (!popularHotels) {
    console.log("Не найден элемент со списком популярных отелей");
  }

  const navbar = await page.$(
    "#app > main > div > div.p-toolbar.p-component.navbar"
  );
  if (!navbar) {
    console.log("Не найдена панель навигации");
  }

  console.log("Открыть профиль");
  await page.goto("https://localhost:5173/profile");

  const profileInfo = await page.$("#app > main > div > div.profileInfo");
  if (!profileInfo) {
    console.log("Не найден элемент с информацией о пользователе");
  }

  const bookingHistory = await page.$(
    "#app > main > div > div.p-scrollpanel.p-component.bookingHistory"
  );
  if (!bookingHistory) {
    console.log("Не найден элемент с историей бронирований");
  }

  console.log("Открыть страницу поиска");
  await page.goto("https://localhost:5173/search");

  const searchPanel = await page.$("#app > main > form > div.div");
  if (!searchPanel) {
    console.log("Не найден элемент с панелью поиска");
  }

  console.log("Закрыть браузер");
  await browser.close();
}
testApp();
