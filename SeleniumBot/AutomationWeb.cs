using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI; // para WebDriverWait
using OpenQA.Selenium.Interactions; // para utilização do Actions
using System;

namespace SeleniumBot
{
    public class AutomationWeb
    {
        public IWebDriver driver;

        public AutomationWeb()
        {
            // iniciar o ChromeDriver e maximiza a janela
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        public string TestWeb()
        {
            // navega no Google
            driver.Navigate().GoToUrl("https://www.google.com");

            // espera até o campo da pesquisa sempre estar visível e inserir o texto
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement searchBox = wait.Until(driver => driver.FindElement(By.Name("q")));
            searchBox.SendKeys("Hello World");

            // usa Js para clicar fora da caixa de sugestão e garanti que o botão esta clicável
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("document.activeElement.blur();"); // tira o foco campo de pesquisa

            // aguarda que o botão esteja visível
            IWebElement searchButton = wait.Until(driver => driver.FindElement(By.Name("btnK")));

            // clica no botão de pesquisa usando Js - evita o problema de sobreposição
            js.ExecuteScript("arguments[0].click();", searchButton);

            // espera o resultado de pesquisa aparecer
            IWebElement result = wait.Until(driver => driver.FindElement(By.XPath("//*[@id='rso']/div[3]/div/div/div/div[2]/div")));

            // retorna o texto do resultado
            var text = result.Text;

            return text;
        }

        public void CloseBrowser()
        {
            // fecha o navegador
            driver.Quit();
        }
    }
}