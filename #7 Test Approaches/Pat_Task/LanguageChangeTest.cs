using NUnit.Framework;
using NUnitTests.Pages;
using FluentAssertions;
using NUnitTests.Helpers;

namespace NUnitTests.Tests
{
    [TestFixture]
    public class LanguageChangeTests : BaseTest
    {
        [Test]
        public void LanguageSwitch_ShouldDisplayRussianContent()
        {
            Logger.Instance.Information("Проверка смены языка на русский начат");
            var languagePage = new LanguagePage(driver);
            Logger.Instance.Information("Переход на главную страницу");
            languagePage.GoToHomePage();
            Logger.Instance.Information("Главная страница открыта.");
            Logger.Instance.Information("Смена языка на русский");
            languagePage.SwitchToRussian();
            Logger.Instance.Information("Язык изменен на русский.");

            Logger.Instance.Information("Проверка отображения русскоязычного заголовка");
            bool isRussianHeaderVisible = languagePage.IsRussianHeaderVisible();
            Logger.Instance.Information($"Русскоязычный заголовок видим: {isRussianHeaderVisible}");
            
            isRussianHeaderVisible
                .Should()
                .BeTrue("Русскоязычный заголовок не отображается.");
            
            Logger.Instance.Information("Проверка смены языка на русский завершен");
        }
    }
}

