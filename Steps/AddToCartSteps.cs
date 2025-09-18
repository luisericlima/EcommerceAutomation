using AutomationEcommerce.Pages;
using AutomationEcommerce.Support;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Xunit;

namespace AutomationEcommerce.Tests.CartTests
{
    [Binding]
    public class AddToCartSteps
    {
        private readonly IWebDriver _driver;
        private readonly LoginPage _loginPage;
        private readonly ProductPage _productPage;

        // Construtor para injeção do WebDriver
        public AddToCartSteps(WebDriverFixture fixture)
        {
            _driver = fixture.Driver;
            _loginPage = new LoginPage(_driver);
            _productPage = new ProductPage(_driver);
        }

        // Dado que o usuário está logado no site
        [Given(@"I am logged in to the site for Add to Cart")]
        public void GivenIAmLoggedInToTheSiteForAddToCart()
        {
            _loginPage.GoTo();
            _loginPage.Login("lihag23567@ishense.com", "123456789");
        }


        // Quando o usuário vai para a página de produtos
        [When(@"I go to the products page")]
        public void WhenIGoToTheProductsPage()
        {
            _productPage.GoToProducts();
        }

        // E o usuário clica em "View Product" do produto específico
        [When(@"I click on ""(.*)"" of a specific product")]
        public void WhenIClickOnViewProductOfASpecificProduct(string button)
        {
            _productPage.ClickViewProduct();
        }

        // E o usuário clica em "Add to cart"
        [When(@"I click on ""(.*)""")]
        public void WhenIClickOnAddToCart(string button)
        {
            _productPage.ClickAddToCart();
        }

        // Então o sistema deve exibir o modal "Added!"
        [Then(@"I should see the ""(.*)"" modal")]
        public void ThenIShouldSeeTheAddedModal(string modalMessage)
        {
            Assert.True(_productPage.IsAddedModalVisible(), $"{modalMessage} modal did not appear!");
        }

        // E o usuário fecha o modal
        [Then(@"I close the modal")]
        public void ThenICloseTheModal()
        {
            _productPage.CloseModal();
        }
    }
}
