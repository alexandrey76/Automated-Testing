using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

public class HomePage : BasePage
{
    private WebDriverWait wait;

    public HomePage() : base()
    {
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    public HomePage Navigate()
    {
        driver.Navigate().GoToUrl("https://en.ehu.lt/");
        return this;
    }

    public AboutPage ClickAboutLink()
    {
        IWebElement aboutLink = driver.FindElement(By.LinkText("About"));
        aboutLink.Click();
        return new AboutPage();
    }

    public ContactPage NavigateToContactPage()
    {
        driver.Navigate().GoToUrl("https://en.ehu.lt/contact/");
        return new ContactPage();
    }

    public HomePage ClickLanguageSwitcher()
    {
        IWebElement langSwitcher = driver.FindElement(By.CssSelector(".language-switcher"));
        langSwitcher.Click();
        return this;
    }

    public HomePage SwitchToLanguage(string lang)
    {
        IWebElement langOption = wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText(lang)));
        langOption.Click();
        return this;
    }

    public SearchPage Search(string searchTerm)
    {
        IWebElement searchIcon = driver.FindElement(By.CssSelector(".header-search"));
        searchIcon.Click();
        IWebElement searchInput = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("input[placeholder='Enter search phrase']")));
        searchInput.SendKeys(searchTerm);
        IWebElement searchButton = driver.FindElement(By.CssSelector("button.btn.btn-info[type='submit']"));
        searchButton.Click();
        return new SearchPage();
    }

    public string GetPageUrl()
    {
        return driver.Url;
    }
}
