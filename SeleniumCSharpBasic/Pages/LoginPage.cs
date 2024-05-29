using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumCSharpBasic.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElement(By.ClassName("loader")).Displayed == false);

            // Wait for the create new account element to be enabled
            wait.Until(d => d.FindElement(By.ClassName("create-new-account")).Enabled);

        }



        public AccountPage ClickCreateAccount()
        {
            driver.FindElement(By.ClassName("create-new-account")).Click();
            return new AccountPage(driver);
        }
    }
}