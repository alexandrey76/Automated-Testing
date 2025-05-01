using NUnit.Framework;
using NUnitTests.Pages;
using FluentAssertions;
using NUnitTests.Helpers;

namespace NUnitTests.Tests
{
    [TestFixture]
    public class ContactInfoTests : BaseTest
    {
        [Test]
        public void ContactInfo_ShouldBeVisibleToUser()
        {
            Logger.Instance.Information("Проверка видимости контактной информации начат");
            var contactPage = new ContactPage(driver);
            contactPage.GoToContactPage();
            
            Logger.Instance.Information("Проверка видимости Email");
            contactPage.IsEmailVisible()
                .Should()
                .BeTrue("Email должен отображаться на странице контактов");

            Logger.Instance.Information("Проверка видимости Телефон Литвы");
            contactPage.IsPhoneLTVisible()
                .Should()
                .BeTrue("Телефон Литвы должен отображаться на странице контактов");

            Logger.Instance.Information("Проверка видимости Телефон Беларуси");
            contactPage.IsPhoneBYVisible()
                .Should()
                .BeTrue("Телефон Беларуси должен отображаться на странице контактов");

            Logger.Instance.Information("Проверка видимости ссылки на Facebook");
            contactPage.IsFacebookLinkVisible()
                .Should()
                .BeTrue("Ссылка на Facebook должна быть видима на странице контактов");

            Logger.Instance.Information("Проверка видимости ссылки на Telegram");
            contactPage.IsTelegramLinkVisible()
                .Should()
                .BeTrue("Ссылка на Telegram должна быть видима на странице контактов");

            Logger.Instance.Information("Проверка видимости ссылки на VK");
            contactPage.IsVKLinkVisible()
                .Should()
                .BeTrue("Ссылка на VK должна быть видима на странице контактов");

            Logger.Instance.Information("Проверка видимости контактной информации успешно завершён");


        }
    }
}
