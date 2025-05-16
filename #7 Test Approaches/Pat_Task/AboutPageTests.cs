using NUnit.Framework;
using NUnitTests.Pages;
using FluentAssertions;
using NUnitTests.Helpers;

namespace NUnitTests.Tests
{
    [TestFixture]
    public class AboutPageTests : BaseTest
    {
        [Test]
        public void AboutPage_Header_ShouldBeVisible()
        {
            Logger.Instance.Information("Проверка отображения заголовка 'About NUnitTests' начат");
            var aboutPage = new AboutPage(driver);
            aboutPage.GoToAboutPage();
            aboutPage.IsAboutHeaderVisible()
                .Should()
                .BeTrue("Заголовок 'About NUnitTests' должен быть видим на странице");
            Logger.Instance.Information("Проверка отображения заголовка 'About NUnitTests' успешно завершён");
        
        }
    }
}
