import puppeteer from "puppeteer";
async function testApp() {
  console.log("Запустить браузер");
  const browser = await puppeteer.launch({
    headless: false,
    slowMo: 100
  });
  console.log("Открыть вкладку браузера");
  const page = await browser.newPage();
  console.log("Открыть страницу");
  await page.goto("https://localhost:5173/search");
  console.log("Задать разрешение страницы");
  await page.setViewport({ width: 360, height: 740 });

  const searchField = await page.$(
    "#app > main > form > div.div > div.p-iconfield > input"
  );
  await searchField.type("Axel");
  console.log("Клик по кнопке");
  await page.$eval(
    "#app > main > form > div.div > div.p-iconfield > span",
    elem => elem.click()
  );
  console.log("Поиск элемента с названием 'Результаты поиска'");
  const resultContent = await page.$("#app > main > form > div.hotelList");
  if (!resultContent) {
    console.log("Модуль результатов поиска не найден!");
  }

  console.log("Закрыть браузер");
  await browser.close();
}
testApp();
