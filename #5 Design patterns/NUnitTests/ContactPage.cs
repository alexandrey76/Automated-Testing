using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

public class ContactPage : BasePage
{
    private WebDriverWait wait;

    public ContactPage() : base()
    {
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    public bool IsElementPresent(By by)
    {
        try
        {
            wait.Until(ExpectedConditions.ElementIsVisible(by));
            return true;
        }
        catch
        {
            return false;
        }
    }

    public IWebElement GetElement(By by)
    {
        return wait.Until(ExpectedConditions.ElementIsVisible(by));
    }
}
