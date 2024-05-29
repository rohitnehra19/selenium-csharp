using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumCSharpBasic.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
            // Wait for the username element to be displayed
            new WebDriverWait(driver, TimeSpan.FromSeconds(20)).
             Until(d => d.FindElement(By.ClassName("create-new-account")).Enabled);
        }

        public AccountPage ClickCreateAccount()
        {
            driver.FindElement(By.ClassName("create-new-account")).Click();
            return new AccountPage(driver);
        }
    }
}