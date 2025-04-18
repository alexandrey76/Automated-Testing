using OpenQA.Selenium;

public abstract class BasePage
{
    protected IWebDriver driver;

    public BasePage()
    {
        driver = WebDriverSingleton.Instance;
    }
}
