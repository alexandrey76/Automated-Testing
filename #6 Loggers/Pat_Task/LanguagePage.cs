using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Interactions;


namespace NUnitTests.Pages
{
    public class LanguagePage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public LanguagePage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        private By languageSwitcher => By.XPath("//*[@id='masthead']/div[1]/div/div[4]/ul/li/a");
        private By russianLanguageOption => By.XPath("//*[@id='masthead']/div[1]/div/div[4]/ul/li/ul/li[1]/a");
        private By russianHeader => By.XPath("//*[@id='logo']");

        public void GoToHomePage()
        {
            _driver.Navigate().GoToUrl("https://en.ehu.lt/");

        }

        public void SwitchToRussian()
        {
               
            var switcherElement = _wait.Until(ExpectedConditions.ElementToBeClickable(languageSwitcher));

            
            var actions = new Actions(_driver);
            actions.MoveToElement(switcherElement).Perform(); 

            
            var russianLanguageElement = _wait.Until(ExpectedConditions.ElementToBeClickable(russianLanguageOption));
            russianLanguageElement.Click();
            
            
            _wait.Until(driver => driver.Url.Contains("ru.ehu.lt"));
        }

        public bool IsRussianHeaderVisible()
        {
            return _wait.Until(ExpectedConditions.ElementIsVisible(russianHeader)).Displayed;
        }
    }
}
