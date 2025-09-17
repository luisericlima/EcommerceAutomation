using AutomationEcommerce.Pages;
using AutomationEcommerce.Support;
using LightBDD.XUnit2;  // LightBDD com xUnit
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Xunit;

namespace AutomationEcommerce.Tests
{
    public class LoginTests : IClassFixture<WebDriverFixture>
    {
        private readonly IWebDriver _driver;
        private readonly LoginPage _loginPage;

        public LoginTests(WebDriverFixture fixture)
        {
            _driver = fixture.Driver;
            _loginPage = new LoginPage(_driver);
        }

        [Scenario]
        public void InvalidLogin()
        {
            Given_I_am_on_the_login_page();
            When_I_enter_invalid_credentials();
            Then_I_should_see_an_error_message();
        }

        public void Given_I_am_on_the_login_page()
        {
            _loginPage.GoTo();
        }

        public void When_I_enter_invalid_credentials()
        {
            _loginPage.Login("invalidEmail@example.com", "invalidPassword");
        }

        public void Then_I_should_see_an_error_message()
        {
            Assert.Equal("Your email or password is incorrect!", _loginPage.GetErrorMessage());
        }

        [Scenario]
        public void LoginWithValidCredentials()
        {
            // Navega até a página de login
            _loginPage.GoTo();

            // Faz login com credenciais válidas
            _loginPage.Login("lihag23567@ishense.com", "123456789");

            // Espera até que a URL seja a página inicial (https://automationexercise.com)
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            wait.Until(d => d.Url == "https://automationexercise.com/");

            // Valida se o login foi bem-sucedido
            Assert.Equal("https://automationexercise.com/", _driver.Url);
        }
    }
}
