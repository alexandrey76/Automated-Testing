using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using NUnitTests.Helpers;

namespace NUnitTests.Pages
{
    public class SearchPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public SearchPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        private By searchIcon = By.XPath("//*[@id='masthead']/div[1]/div/div[4]/div");
        private By searchInput = By.XPath("//*[@id='masthead']/div[1]/div/div[4]/div/form/div/input");
        private By searchButton = By.XPath("//*[@id='masthead']/div[1]/div/div[4]/div/form/div/span/button");

        public void GoToHomePage()
        {
            Logger.Instance.Information("Переход на главную страницу");
            _driver.Navigate().GoToUrl("https://en.ehu.lt/");
            Logger.Instance.Information("Главная страница открыта.");
        }

        public void Search(string query)
        {
            Logger.Instance.Information($"Поиск запроса: {query}");
            _wait.Until(ExpectedConditions.ElementToBeClickable(searchIcon)).Click();
            _wait.Until(ExpectedConditions.ElementIsVisible(searchInput)).SendKeys(query);
            _wait.Until(ExpectedConditions.ElementToBeClickable(searchButton)).Click();
            Logger.Instance.Information($"Поиск по запросу '{query}' выполнен.");
        }

        public bool IsResultVisible(string partialText)
        {
            Logger.Instance.Debug($"Проверка наличия результата поиска по тексту: {partialText}");
            return _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath($"//a[contains(text(),'{partialText}')]"))).Displayed;
        }
    }
}
