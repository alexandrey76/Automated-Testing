using OpenQA.Selenium;

public class AboutPage : BasePage
{
    public AboutPage() : base() { }

    public string GetPageUrl()
    {
        return driver.Url;
    }

    public string GetPageTitle()
    {
        return driver.Title;
    }

    public string GetContentHeader()
    {
        return driver.FindElement(By.TagName("h1")).Text;
    }
}
