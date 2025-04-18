
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using System;

namespace Tests.Base
{
    public class TestBase
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;

        [SetUp]
        public virtual void SetUp()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            driver = new ChromeDriver(options);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [TearDown]
        public virtual void TearDown()
        {
            if (driver != null)
            {
                driver.Dispose();
            }
        }
    }
}
