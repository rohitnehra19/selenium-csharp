using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SeleniumCSharpBasic.Pages
{
    public class AccountPage : BasePage
    {
        public AccountPage(IWebDriver driver) : base(driver)
        {
            // Wait for the username element to be displayed
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.FindElement(By.Name("usernameRegisterPage")).Displayed);
        }

        private IWebElement GetUsernameElement()
        {
            return this.driver.FindElement(By.Name("usernameRegisterPage"));
        }

        private IWebElement GetEmailElement()
        {
            return this.driver.FindElement(By.Name("emailRegisterPage"));
        }

        private IWebElement GetPasswordElement()
        {
            return this.driver.FindElement(By.Name("passwordRegisterPage"));
        }

        private IWebElement GetConfirmPasswordElement()
        {
            return this.driver.FindElement(By.Name("confirm_passwordRegisterPage"));
        }

        private IWebElement GetFirstNameElement()
        {
            return this.driver.FindElement(By.Name("first_nameRegisterPage"));
        }


        public AccountPage SetUsername(string username)
        {
            GetUsernameElement().SendKeys(username);
            return this;
        }

        public AccountPage ClickUsername()
        {
            GetUsernameElement().Click();
            return this;
        }

        public AccountPage SetEmail(string email)
        {
            GetEmailElement().SendKeys(email);
            return this;
        }

        public AccountPage ClickEmail()
        {
            GetEmailElement().Click();
            return this;
        }

        public AccountPage SetPassword(string password)
        {
            GetPasswordElement().SendKeys(password);
            return this;
        }

        public AccountPage ClickPassword()
        {
            GetPasswordElement().Click();
            return this;
        }

        public AccountPage SetConfirmPassword(string confirmPassword)
        {
            GetConfirmPasswordElement().SendKeys(confirmPassword);
            return this;
        }

        public AccountPage ClickConfirmPassword()
        {
            GetConfirmPasswordElement().Click();
            return this;
        }

        public string GetUsernameError()
        {
            return GetErrorText(By.CssSelector("input[name='usernameRegisterPage'] + label.invalid"));
        }

        public string GetEmailError()
        {
            return GetErrorText(By.CssSelector("input[name='emailRegisterPage'] + label.invalid"));
        }

        public string GetPasswordError()
        {
            return GetErrorText(By.CssSelector("input[name='passwordRegisterPage'] + label.invalid"));
        }

        public string GetConfirmPasswordError()
        {
            return GetErrorText(By.CssSelector("input[name='confirm_passwordRegisterPage'] + label.invalid"));
        }

        public AccountPage ClickFirstName()
        {
            GetFirstNameElement().Click();
            return this;
        }

        private string GetErrorText(By locator)
        {
            IReadOnlyCollection<IWebElement> elements = this.driver.FindElements(locator);
            return elements.Count == 0 ? "" : elements.ElementAt(0).Text;

        }
    }
}