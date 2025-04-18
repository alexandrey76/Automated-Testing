using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.ComponentModel.DataAnnotations;
using Tests.Base;

namespace NUnitTests
{
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]
    [Category("Regression")]
    public class ContactFormTest : TestBase
    {
        [Test]
        [TestCase("//*[@id='post-49257']/div/ul/li[1]/a", "Email")]
        [TestCase("//*[@id='post-49257']/div/ul/li[2]", "Phone (LT)")]
        [TestCase("//*[@id='post-49257']/div/ul/li[3]", "Phone (BY)")]
        [TestCase("//*[@id='post-49257']/div/ul/li[4]/a[1]", "Facebook")]
        [TestCase("//*[@id='post-49257']/div/ul/li[4]/a[2]", "Telegram")]
        [TestCase("//*[@id='post-49257']/div/ul/li[4]/a[3]", "VK")]

        public void ContactElementSearching(string xpath, string name)
        {
            HomePage homePage = new HomePage();
            ContactPage contactPage = homePage.NavigateToContactPage();
            IWebElement element = contactPage.GetElement(By.XPath(xpath));
            string actualText = element.Text;
            Assert.IsTrue(actualText.Contains(name), $"{name} не отображается на странице контактов.");

        }
    }
}