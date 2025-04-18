using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Collections.Generic;
using System;

public class SearchPage : BasePage
{
    private WebDriverWait wait;

    public SearchPage() : base()
    {
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    public string GetCurrentUrl()
    {
        wait.Until(d => d.Url.Contains("/?s="));
        return driver.Url;
    }
}
