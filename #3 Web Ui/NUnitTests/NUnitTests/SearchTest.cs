using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using Tests.Base;

namespace NUnitTests
{

    [TestFixture]
    [Parallelizable(ParallelScope.Self)]
    [Category("Regression")]
    public class SearchTest : TestBase
    {

        [Test]
        public void SearchFunctionalityTest()
        {
            driver.Navigate().GoToUrl("https://en.ehu.lt/");

            IWebElement searchIcon = driver.FindElement(By.CssSelector(".header-search"));
            searchIcon.Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement searchInput = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("input[placeholder='Enter search phrase']")));

            string searchTerm = "study programs";
            searchInput.SendKeys(searchTerm);

            IWebElement searchButton = driver.FindElement(By.CssSelector("button.btn.btn-info[type='submit']"));
            searchButton.Click();

            wait.Until(d => d.Url.Contains("/?s="));
            string currentUrl = driver.Url;
            Assert.IsTrue(currentUrl.Contains("/?s=study+programs"), $"URL '{currentUrl}' не содержит ожидаемого '/?s=study+programs'.");
        }
    }
}