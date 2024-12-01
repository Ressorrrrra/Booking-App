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
  await page.goto("https://localhost:5173/");
  console.log("Задать разрешение страницы");
  await page.setViewport({ width: 360, height: 740 });
  await page.screenshot({ path: "testApp.png" });
  console.log("Закрыть браузер");
  await browser.close();
}
testApp();
