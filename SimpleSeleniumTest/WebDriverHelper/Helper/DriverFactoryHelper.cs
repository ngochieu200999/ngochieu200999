using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager.Helpers;

namespace WebDriverHelper.Helper
{
    public class DriverfactoryHelper
    {
        public static IWebDriver InitDriver(string browserType)
        {
            IWebDriver driver = null;

            switch (browserType)
            {
                case "CHROME":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig(), VersionResolveStrategy.MatchingBrowser);
                    driver = new ChromeDriver();
                    break;
                case "FIREFOX":
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig(), VersionResolveStrategy.MatchingBrowser);
                    driver = new FirefoxDriver();
                    break;
                case "EDGE":
                    new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig(), VersionResolveStrategy.MatchingBrowser);
                    driver = new EdgeDriver();
                    break;
                default:
                    throw new Exception("Not suppot this driver type");
            }

            return driver;
        }
    }
}
