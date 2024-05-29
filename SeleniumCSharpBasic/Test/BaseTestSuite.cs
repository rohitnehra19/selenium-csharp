using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace SeleniumCSharpBasic.Test
{

    [TestFixture]
    public class BaseTestSuite
    {
        protected IWebDriver driver;

        [SetUp]
        public void Setup()
        {

            string browser = Environment.GetEnvironmentVariable("SELENIUM_BROWSER") ?? "chrome";
            bool headless = bool.TryParse(Environment.GetEnvironmentVariable("SELENIUM_HEADLESS"), out var result) && result;
            int waitTime = int.TryParse(Environment.GetEnvironmentVariable("SELENIUM_WAIT"), out var wait) ? wait : 10;
            string baseUrl = Environment.GetEnvironmentVariable("SELENIUM_URL") ?? "https://www.advantageonlineshopping.com/#/";

            driver = InitWebDriver(browser, headless);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(waitTime);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(baseUrl);
        }

        private static IWebDriver InitWebDriver(string browser, bool headless)
        {
            switch (browser.ToLower())
            {
                case "firefox":
                    var firefoxOptions = new FirefoxOptions();
                    if (headless) firefoxOptions.AddArgument("--headless");
                    return new FirefoxDriver(firefoxOptions);

                case "chrome":
                default:
                    var chromeOptions = new ChromeOptions();
                    if (headless) chromeOptions.AddArgument("--headless");
                    return new ChromeDriver(chromeOptions);
            }
        }

        [TearDown]
        public void TearDown()
        {
            Dispose();
        }

        public void Dispose()
        {
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
            }
        }
    }
}