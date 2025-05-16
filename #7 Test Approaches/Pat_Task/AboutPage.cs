using NUnitTests.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace NUnitTests.Pages
{
    public class AboutPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public AboutPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        private By aboutLink => By.LinkText("About");
        private By aboutHeader => By.CssSelector("h1");


        public void GoToAboutPage()
        {
            Logger.Instance.Information("Открытие главной страницы NUnitTests");
            _driver.Navigate().GoToUrl("https://en.ehu.lt/");
            Logger.Instance.Information("Ожидание кликабельности ссылки About");
            _wait.Until(ExpectedConditions.ElementToBeClickable(aboutLink)).Click();
            Logger.Instance.Information("Клик по ссылке About выполнен");

        }

        public bool IsAboutHeaderVisible()
        {
            return _wait.Until(ExpectedConditions.ElementIsVisible(aboutHeader)).Displayed;
        }
    }
}
