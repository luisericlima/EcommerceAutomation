using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace AutomationEcommerce.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        private readonly By _usernameField = By.XPath("//input[@data-qa='login-email']");
        private readonly By _passwordField = By.XPath("//input[@data-qa='login-password']");
        private readonly By _loginButton = By.XPath("//button[@data-qa='login-button']");
        private readonly By _errorMessage = By.XPath("//p[@style='color: red;']");

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        public void GoTo()
        {
            _driver.Navigate().GoToUrl("https://automationexercise.com/login");
        }

        public void Login(string username, string password)
        {
            EnterUsername(username);
            EnterPassword(password);
            ClickLoginButton();
        }

        private void EnterUsername(string username)
        {
            var usernameElement = _wait.Until(ExpectedConditions.ElementIsVisible(_usernameField));
            usernameElement.Clear();
            usernameElement.SendKeys(username);
        }

        private void EnterPassword(string password)
        {
            var passwordElement = _wait.Until(ExpectedConditions.ElementIsVisible(_passwordField));
            passwordElement.Clear();
            passwordElement.SendKeys(password);
        }

        private void ClickLoginButton()
        {
            var loginButtonElement = _wait.Until(ExpectedConditions.ElementToBeClickable(_loginButton));
            loginButtonElement.Click();
        }

        public string GetErrorMessage()
        {
            try
            {
                var errorMessageElement = _wait.Until(ExpectedConditions.ElementIsVisible(_errorMessage));
                return errorMessageElement.Text.Trim();
            }
            catch (WebDriverTimeoutException)
            {
                return string.Empty;
            }
        }
    }
}
