using NUnit.Framework;
using OpenQA.Selenium;
using NUnitTests.Helpers;
using NUnitTests.Pages;
using NUnitTests.Drivers;
using Reqnroll;

namespace NUnitTests.Steps
{
    [Binding]
    public class SiteEndToEndSteps
    {
        private readonly IWebDriver _driver;
        private readonly SearchPage _searchPage;
        private readonly AboutPage _aboutPage;
        private readonly LanguagePage _languagePage;
        private readonly ContactPage _contactPage;

        public SiteEndToEndSteps()
        {
            _driver = WebDriverSingleton.GetDriver();
            _searchPage = new SearchPage(_driver);
            _aboutPage = new AboutPage(_driver);
            _languagePage = new LanguagePage(_driver);
            _contactPage = new ContactPage(_driver);
        }

        [Given(@"Пользователь на главной странице")]
        public void GivenUserOnHomePage()
        {
            Logger.Instance.Information("Шаг: открыть главную страницу");
            _searchPage.GoToHomePage();
        }

        [When(@"Выполнить поиск по запросу ""(.*)""")]
        public void WhenSearchFor(string query)
        {
            Logger.Instance.Information($"Шаг: поиск '{query}'");
            _searchPage.Search(query);
        }

        [Then(@"В результатах должен отображаться текст ""(.*)""")]
        public void ThenResultShouldContain(string partialText)
        {
            Logger.Instance.Information($"Шаг: проверка результата '{partialText}'");
            Assert.IsTrue(_searchPage.IsResultVisible(partialText),
                $"Ожидали увидеть '{partialText}' в результатах");
        }

        [When(@"Перейти на страницу About")]
        public void WhenGoToAboutPage()
        {
            Logger.Instance.Information("Шаг: переход на About");
            _aboutPage.GoToAboutPage();
        }

        [Then(@"Заголовок About должен быть видим")]
        public void ThenAboutHeaderVisible()
        {
            Logger.Instance.Information("Шаг: проверка заголовка About");
            Assert.IsTrue(_aboutPage.IsAboutHeaderVisible(), "Заголовок About не виден");
        }

        [When(@"Переключить язык на русский")]
        public void WhenSwitchToRussian()
        {
            Logger.Instance.Information("Шаг: смена языка на русский");
            _languagePage.GoToHomePage();
            _languagePage.SwitchToRussian();
        }

        [Then(@"Русскоязычный заголовок должен отображаться")]
        public void ThenRussianHeaderVisible()
        {
            Logger.Instance.Information("Шаг: проверка русского заголовка");
            Assert.IsTrue(_languagePage.IsRussianHeaderVisible(), "Русский заголовок не виден");
        }

        [When(@"Перейти на страницу контактов")]
        public void WhenGoToContactPage()
        {
            Logger.Instance.Information("Шаг: переход на контакты");
            _contactPage.GoToContactPage();
        }

        [Then(@"Должны быть видимы Email, телефон Литвы, телефон Беларуси и ссылки на Facebook, Telegram, VK")]
        public void ThenContactInfoVisible()
        {
            Logger.Instance.Information("Шаг: проверка контактной информации");
            Assert.Multiple(() =>
            {
                Assert.IsTrue(_contactPage.IsEmailVisible(), "Email не виден");
                Assert.IsTrue(_contactPage.IsPhoneLTVisible(), "Телефон Литвы не виден");
                Assert.IsTrue(_contactPage.IsPhoneBYVisible(), "Телефон Беларуси не виден");
                Assert.IsTrue(_contactPage.IsFacebookLinkVisible(), "Facebook-ссылка не видна");
                Assert.IsTrue(_contactPage.IsTelegramLinkVisible(), "Telegram-ссылка не видна");
                Assert.IsTrue(_contactPage.IsVKLinkVisible(), "VK-ссылка не видна");
            });
        }
    }
}
