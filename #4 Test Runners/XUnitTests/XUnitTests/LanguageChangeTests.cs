using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Xunit;

namespace XUnitTests
{
    public class LanguageChangeTests : TestBase
    {
        [Fact]
        [Trait("Category", "Smoke")]
        public void VerifyLanguageChangeFunctionality()
        {
            driver.Navigate().GoToUrl("https://en.ehu.lt/");

            var englishBtn = driver.FindElement(By.XPath("//a[text()='en']"));
            new Actions(driver).MoveToElement(englishBtn).Perform();

            var lithuanianBtn = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//a[text()='lt']")));
            lithuanianBtn.Click();

            Assert.Equal("https://lt.ehu.lt/", driver.Url);

            var bodyText = driver.FindElement(By.TagName("body")).Text;
            Assert.Contains("Europos humanitarinis universitetas", bodyText);
        }
    }
}
