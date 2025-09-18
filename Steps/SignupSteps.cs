using AutomationEcommerce.Pages;
using AutomationEcommerce.Support;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Xunit;

namespace AutomationEcommerce.Tests
{
    [Binding]
    public class SignupSteps
    {
        private readonly IWebDriver _driver;
        private readonly SignupPage _signupPage;

        // Constructor to inject the WebDriver from WebDriverFixture
        public SignupSteps(WebDriverFixture fixture)
        {
            _driver = fixture.Driver;
            _signupPage = new SignupPage(_driver);
        }

        [Given(@"the user is on the signup page")]
        public void GivenTheUserIsOnTheSignupPage()
        {
            _driver.Navigate().GoToUrl("https://automationexercise.com/signup");
        }

        [When(@"the user fills in the valid details")]
        public void WhenTheUserFillsInTheValidDetails()
        {
            // Gerar e-mail único para o teste
            var uniqueEmail = $"user_{DateTime.Now:yyyyMMddHHmmssfff}@test.com";
            _signupPage.FillInitialSignup("Test User", uniqueEmail);

            // Recuperando a senha do GitHub Secret (variável de ambiente)


            // Preenche o formulário com as credenciais
            _signupPage.FillCompleteForm(
                "Password123!",  // Usando a senha do segredo
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
        }

        [Then(@"the system should display a success message")]
        public void ThenTheSystemShouldDisplayASuccessMessage()
        {
            _signupPage.WaitForUrlContains("/account_created");
            Assert.Contains("/account_created", _driver.Url);
        }

        [When(@"the user tries to register with an existing email")]
        public void WhenTheUserTriesToRegisterWithAnExistingEmail()
        {
            _signupPage.FillInitialSignup("Test User", "tester@gmail.com");
            _signupPage.ClickSignupButton();
        }

        [Then(@"the system should display the message ""(.*)""")]
        public void ThenTheSystemShouldDisplayTheMessage(string message)
        {
            string errorMessage = _signupPage.GetErrorMessage();
            Assert.Equal(message, errorMessage);
        }
    }
}
