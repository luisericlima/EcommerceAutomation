using LightBDD.XUnit2;
using Xunit;
using OpenQA.Selenium;
using AutomationEcommerce.Pages;
using AutomationEcommerce.Support;
using System;

namespace AutomationEcommerce.Tests
{
    public class SignupTests : IClassFixture<WebDriverFixture>
    {
        private readonly IWebDriver _driver;
        private readonly SignupPage _signupPage;

        public SignupTests(WebDriverFixture fixture)
        {
            _driver = fixture.Driver;
            _signupPage = new SignupPage(_driver);
        }

        [Scenario]
        public void SignupWithValidDetails()
        {
            _driver.Navigate().GoToUrl("https://automationexercise.com/signup");

            var uniqueEmail = $"user_{DateTime.Now:yyyyMMddHHmmssfff}@test.com";
            _signupPage.FillInitialSignup("Test User", uniqueEmail);

            _signupPage.FillCompleteForm(
                "Password123!",
                "Test",
                "User",
                "Main Street",
                "Apt 101",
                "Test Company",
                "California",
                "Los Angeles",
                "90001",
                "1234567890"
            );

            _signupPage.SubmitCreateAccount();

            // Aguarda até que a URL contenha "/account_created"
            _signupPage.WaitForUrlContains("/account_created");

            // Verifica se a URL realmente contém o caminho esperado
            Assert.Contains("/account_created", _driver.Url);
        }

        [Scenario]
        public void SignupWithExistingEmail()
        {
            _driver.Navigate().GoToUrl("https://automationexercise.com/signup");

            _signupPage.FillInitialSignup("Test User", "tester@gmail.com");

            // Envia o formulário para testar o e-mail já existente
            _signupPage.ClickSignupButton();

            // Captura a mensagem de erro
            string errorMessage = _signupPage.GetErrorMessage();
            Assert.Equal("Email Address already exist!", errorMessage);
        }
    }
}
