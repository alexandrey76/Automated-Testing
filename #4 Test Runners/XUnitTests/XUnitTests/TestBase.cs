using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace XUnitTests
{
    public class TestBase
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;

        public TestBase()
        {
            driver = new ChromeDriver(new ChromeOptions { });
            driver.Manage().Window.Maximize();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public void Dispose()
        {
            driver.Quit();
        }
    }
}