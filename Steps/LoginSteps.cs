using AutomationEcommerce.Pages;
using AutomationEcommerce.Support;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using Xunit;

namespace AutomationEcommerce.Tests
{
    [Binding]
    public class LoginSteps
    {
        private readonly IWebDriver _driver;
        private readonly LoginPage _loginPage;

        // Construtor para injeção do WebDriver
        public LoginSteps(WebDriverFixture fixture)
        {
            _driver = fixture.Driver;
            _loginPage = new LoginPage(_driver);
        }

        // Dado que o usuário está na página de login
        [Given(@"I am on the login page")]
        public void GivenIAmOnTheLoginPage()
        {
            _loginPage.GoTo();
        }

        // Quando o usuário insere credenciais inválidas
        [When(@"I enter invalid credentials")]
        public void WhenIEnterInvalidCredentials()
        {
            _loginPage.Login("invalidEmail@example.com", "invalidPassword");
        }

        // Então o sistema deve exibir uma mensagem de erro
        [Then(@"I should see an error message")]
        public void ThenIShouldSeeAnErrorMessage()
        {
            Assert.Equal("Your email or password is incorrect!", _loginPage.GetErrorMessage());
        }

        // Quando o usuário insere credenciais válidas
        [When(@"I enter valid credentials")]
        public void WhenIEnterValidCredentials()
        {
            _loginPage.Login("lihag23567@ishense.com", "123456789");
        }

        // Então o sistema deve redirecionar para a página inicial
        [Then(@"I should be redirected to the homepage")]
        public void ThenIShouldBeRedirectedToTheHomepage()
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            wait.Until(d => d.Url == "https://automationexercise.com/");

            Assert.Equal("https://automationexercise.com/", _driver.Url);
        }
    }
}
