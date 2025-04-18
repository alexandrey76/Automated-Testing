using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using SeleniumExtras.WaitHelpers;

namespace XUnitTests
{
    public class AboutTest : TestBase
    {
        [Fact]
        [Trait("Category", "Smoke")]
        public void NavigationToAboutTest()
        {
            driver.Navigate().GoToUrl("https://en.ehu.lt/");

            driver.FindElement(By.LinkText("About")).Click();

            wait.Until(d => d.Url.Contains("/about"));

            Assert.Contains("/about", driver.Url);
            Assert.Equal("About", driver.Title);

            var heading = driver.FindElement(By.TagName("h1"));
            Assert.Contains("About", heading.Text);
        }   
    }
}