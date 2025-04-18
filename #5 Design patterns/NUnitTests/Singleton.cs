using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

public sealed class WebDriverSingleton
{
    private static IWebDriver driver;
    private static readonly object padlock = new object();

    private WebDriverSingleton() { }

    public static IWebDriver Instance
    {
        get
        {
            if (driver == null)
            {
                lock (padlock)
                {
                    if (driver == null)
                    {
                        var options = new ChromeOptions();
                        options.AddArgument("--start-maximized");
                        driver = new ChromeDriver(options);
                    }
                }
            }
            return driver;
        }
    }

    public static void Quit()
    {
        if (driver != null)
        {
            driver.Quit();
            driver = null;
        }
    }
}
