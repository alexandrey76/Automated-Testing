using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using Xunit;

namespace XUnitTests
{
    public class SearchTests : TestBase
    {
        public SearchTests() : base() { }

        [Fact]
        [Trait("Category", "Regression")]
        public void VerifySearchFunctionality()
        {
            driver.Navigate().GoToUrl("https://en.ehu.lt/");

            
            var searchIcon = driver.FindElement(By.XPath("//*[@id='masthead']/div[1]/div/div[4]/div"));

            
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20)); 
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(searchIcon));

            
            new Actions(driver).MoveToElement(searchIcon).Perform();

            
            var searchInput = driver.FindElement(By.XPath("//*[@id='masthead']/div[1]/div/div[4]/div/form/div/input"));
            searchInput.SendKeys("study programs");

        
            var searchButton = driver.FindElement(By.XPath("//*[@id='masthead']/div[1]/div/div[4]/div/form/div/span/button"));

            
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(searchButton));

            
            var jsExecutor = (IJavaScriptExecutor)driver;
            jsExecutor.ExecuteScript("arguments[0].click();", searchButton);

            
            var resultLink = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//a[contains(text(),'The Women in Tech Project')]")));

            
            Assert.True(resultLink.Displayed, "Результаты поиска не отображаются!");
        }
    }
}
