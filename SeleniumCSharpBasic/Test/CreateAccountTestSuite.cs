using SeleniumCSharpBasic.Pages;

namespace SeleniumCSharpBasic.Test
{

    public class CreateAccountTestSuite : BaseTestSuite
    {
        [Test]
        public void TestMandatoryErrorMessages()
        {
            var homePage = new HomePage(driver);
            var accountPage = homePage.ClickUserMenu()
                                    .ClickCreateAccount();


            accountPage.ClickUsername();
            accountPage.ClickEmail();
            accountPage.ClickPassword();
            accountPage.ClickConfirmPassword();
            accountPage.ClickFirstName();

            Assert.Multiple(() =>
            {
                // Check if the error message is displayed for the mandatory elements
                Assert.That(accountPage.GetUsernameError(), Is.EqualTo("Username field is required"), "Error message for mandatory Username element is not displayed or does not match expected message.");
                Assert.That(accountPage.GetEmailError(), Is.EqualTo("Email field is required"), "Error message for mandatory Email element is not displayed or does not match expected message.");
                Assert.That(accountPage.GetPasswordError(), Is.EqualTo("Password field is required"), "Error message for mandatory Password element is not displayed or does not match expected message.");
                Assert.That(accountPage.GetConfirmPasswordError(), Is.EqualTo("Confirm password field is required"), "Error message for mandatory Confirm password element is not displayed or does not match expected message.");
            });

            accountPage.SetUsername("TestUser");
            accountPage.SetEmail("abc@abc.com");
            accountPage.SetPassword("Abc123");
            accountPage.SetConfirmPassword("Abc123");
            accountPage.ClickFirstName();

            Assert.Multiple(() =>
            {
                // Check if the error message is not displayed for the mandatory elements post valid value
                Assert.That(accountPage.GetUsernameError(), Is.EqualTo(""), "Error message for mandatory Username element is displayed.");
                Assert.That(accountPage.GetEmailError(), Is.EqualTo(""), "Error message for mandatory Email element is displayed.");
                Assert.That(accountPage.GetPasswordError(), Is.EqualTo(""), "Error message for mandatory Password element is displayed.");
                Assert.That(accountPage.GetConfirmPasswordError(), Is.EqualTo(""), "Error message for mandatory Confirm password element is displayed.");
            });
        }

    }
}

