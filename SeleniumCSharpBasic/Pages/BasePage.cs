using OpenQA.Selenium;

namespace SeleniumCSharpBasic.Pages
{
    public class BasePage
    {
        protected readonly IWebDriver driver;

        protected BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }


    }
}
