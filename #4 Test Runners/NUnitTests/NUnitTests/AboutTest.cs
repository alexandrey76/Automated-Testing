using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using SeleniumExtras.WaitHelpers;
using Tests.Base;

namespace NUnitTests
{
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]
    [Category("Smoke")]
    public class AboutTest : TestBase
    {
        [Test]
        public void NavigationToAboutTest()
        {
            driver.Navigate().GoToUrl("https://en.ehu.lt/");

            IWebElement aboutLink = driver.FindElement(By.LinkText("About"));
            aboutLink.Click();

            string expectedUrl = "https://en.ehu.lt/about/";
            Assert.That(driver.Url, Is.EqualTo(expectedUrl), "Некорректный URL после нажатия на ссылку About");

            string expectedTitle = "About";
            Assert.That(driver.Title, Is.EqualTo(expectedTitle), "Заголовок страницы не соответствует ожидаемому");
        }
        
    }
}