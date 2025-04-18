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
    public class LanguageTest : TestBase
    {
        [Test]
        public void EnLtLanguageSwitcherTest()
        {
            driver.Navigate().GoToUrl("https://en.ehu.lt/");

            IWebElement langSwitcher = driver.FindElement(By.CssSelector(".language-switcher"));
            langSwitcher.Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement ltLang = wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText("LT")));
            ltLang.Click();

            wait.Until(d => d.Url.StartsWith("https://lt.ehu.lt/"));
            string currentUrl = driver.Url;
            Assert.IsTrue(currentUrl.Contains("https://lt.ehu.lt/"), $"URL '{currentUrl}' не содержит ожидаемого 'https://lt.ehu.lt/'.");

        }
    }
}