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
            HomePage homePage = new HomePage();
            homePage.Navigate();
            SearchPage resultsPage = homePage.Search("study programs");

            string currentUrl = resultsPage.GetCurrentUrl();
            Assert.IsTrue(currentUrl.Contains("/?s=study+programs"), $"URL '{currentUrl}' не содержит ожидаемого '/?s=study+programs'.");
        }
    }
}