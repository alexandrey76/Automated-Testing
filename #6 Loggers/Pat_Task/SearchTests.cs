using NUnit.Framework;
using NUnitTests.Pages;
using FluentAssertions;
using NUnitTests.Helpers;

namespace NUnitTests.Tests
{
    [TestFixture]
    public class SearchTests : BaseTest
    {
        [Test]
        public void VerifySearchFunctionality()
        {
            Logger.Instance.Information("Проверка функционала поиска начат");
            var searchPage = new SearchPage(driver);
            searchPage.GoToHomePage();
            searchPage.Search("study programs");
            Logger.Instance.Information("Проверка наличия результатов поиска");
            searchPage.IsResultVisible("The Women in Tech Project")
                .Should()
                .BeTrue("Результаты поиска должны отображаться");

            Logger.Instance.Information("Проверка функционала поиска успешно завершён");

        }
    }
}
