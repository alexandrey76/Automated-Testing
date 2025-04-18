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
            HomePage homePage = PageObjectFactory.Create<HomePage>();
            homePage.Navigate();
            AboutPage aboutPage = homePage.ClickAboutLink();

            string expectedUrl = "https://en.ehu.lt/about/";
            Assert.That(aboutPage.GetPageUrl(), Is.EqualTo(expectedUrl), "Некорректный URL после перехода на страницу About EHU");

            string expectedTitle = "About";
            Assert.That(aboutPage.GetPageTitle(), Is.EqualTo(expectedTitle), "Заголовок страницы не соответствует ожидаемому");
        }
        
    }
}