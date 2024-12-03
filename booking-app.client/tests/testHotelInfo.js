import puppeteer from "puppeteer";

function delay(time) {
  return new Promise(function(resolve) {
    setTimeout(resolve, time);
  });
}

async function testApp() {
  console.log("Запустить браузер");
  const browser = await puppeteer.launch({
    headless: false,
    slowMo: 100
  });
  console.log("Открыть вкладку браузера");
  const page = await browser.newPage();
  console.log("Открыть страницу");
  await page.goto("https://localhost:5173/mainpage");
  console.log("Задать разрешение страницы");
  await page.setViewport({ width: 360, height: 740 });

  console.log("Клик по кнопке");
  await page.$eval(
    "#pv_id_1_content > div > div > div:nth-child(1) > div > button",
    elem => elem.click()
  );

  await delay(500);
  const currentUrl = page.url();
  console.log(`Текущий URL: ${currentUrl}`);

  if (!currentUrl.includes("https://localhost:5173/hotelinfo/")) {
    console.log("Не был произведён переход на другую страницу");
  }

  console.log("Закрыть браузер");
  await browser.close();
}
testApp();
