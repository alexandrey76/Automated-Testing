using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using NUnitTests.Helpers;

namespace NUnitTests.Pages
{
    public class ContactPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public ContactPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public void GoToContactPage()
        {
            Logger.Instance.Information("Переход на страницу контактов");
            _driver.Navigate().GoToUrl("https://en.ehu.lt/contact/");
            Logger.Instance.Information("Страница контактов открыта.");
        }

        private By emailText => By.XPath("//*[@id='post-49257']/div/ul/li[1]/a");
        private By phoneLT => By.XPath("//*[@id='post-49257']/div/ul/li[2]");
        private By phoneBY => By.XPath("//*[@id='post-49257']/div/ul/li[3]");
        private By facebookLink => By.XPath("//*[@id='post-49257']/div/ul/li[4]/a[1]");
        private By telegramLink => By.XPath("//*[@id='post-49257']/div/ul/li[4]/a[2]");
        private By vkLink => By.XPath("//*[@id='post-49257']/div/ul/li[4]/a[3]");

        public bool IsEmailVisible() => _wait.Until(ExpectedConditions.ElementIsVisible(emailText)).Displayed;
        public bool IsPhoneLTVisible() => _wait.Until(ExpectedConditions.ElementIsVisible(phoneLT)).Displayed;
        public bool IsPhoneBYVisible() => _wait.Until(ExpectedConditions.ElementIsVisible(phoneBY)).Displayed;
        public bool IsFacebookLinkVisible() => _wait.Until(ExpectedConditions.ElementIsVisible(facebookLink)).Displayed;
        public bool IsTelegramLinkVisible() => _wait.Until(ExpectedConditions.ElementIsVisible(telegramLink)).Displayed;
        public bool IsVKLinkVisible() => _wait.Until(ExpectedConditions.ElementIsVisible(vkLink)).Displayed;
    }
}
