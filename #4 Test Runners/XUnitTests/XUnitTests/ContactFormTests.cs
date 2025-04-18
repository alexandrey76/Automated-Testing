using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using Xunit;

namespace XUnitTests
{
    public class ContactFormTests : TestBase
    {
        public ContactFormTests() : base() { }

        [Theory]
        [InlineData("//a[contains(@href, 'mailto:franciskscarynacr@gmail.com')]", "Email не найден!")]
        [InlineData("//*[contains(text(), '+370 68 771365')]", "Телефон +370 68 771365 не найден!")]
        [InlineData("//*[contains(text(), '+375 29 5781488')]", "Телефон +375 29 5781488 не найден!")]
        [InlineData("//a[contains(@href, 'https://www.facebook.com/EHUOfficial')]", "Facebook ссылка не найдена!")]
        [InlineData("//a[contains(@href, 'https://t.me/EHUOfficial')]", "Telegram ссылка не найдена!")]
        [InlineData("//a[contains(@href, 'https://vk.com/ehuofficial')]", "VK ссылка не найдена!")]
        [Trait("Category", "Regression")]
        public void VerifyContactInformation(string xpath, string errorMessage)
        {
            driver.Navigate().GoToUrl("https://en.ehu.lt/contact/");

           
            Assert.True(IsElementVisible(By.XPath(xpath)), errorMessage);
        }

        private bool IsElementVisible(By by)
        {
            try
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));  
                var element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
                return element.Displayed;
            }
            catch (Exception ex)
            {
                
                Console.WriteLine("Ошибка при поиске элемента: " + ex.Message);
                return false;
            }
        }
    }
}
