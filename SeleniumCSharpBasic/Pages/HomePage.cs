using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumCSharpBasic.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {

            try
            {
                // Wait for loader spinner to disappear
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(d => d.FindElement(By.ClassName("loader")).Displayed == false);

                // Wait for the logo demo element to be displayed
                wait.Until(d => d.FindElement(By.ClassName("logoDemo")));
            }
            catch (WebDriverTimeoutException)
            {
                // Throw a WebDriverTimeoutException if the logo demo element is not displayed
                throw new WebDriverTimeoutException("Logo is not displayed within the specified timeout.");
            }
        }

        public LoginPage ClickUserMenu()
        {
            driver.FindElement(By.Id("menuUser")).Click();
            return new LoginPage(driver);
        }
    }
}
