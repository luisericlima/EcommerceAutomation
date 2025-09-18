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

        public AddToCartSteps(WebDriverFixture fixture)
        {
            _driver = fixture.Driver;
            _loginPage = new LoginPage(_driver);
            _productPage = new ProductPage(_driver);
        }

        [Given(@"I am logged in to the site for Add to Cart")]
        public void GivenIAmLoggedInToTheSiteForAddToCart()
        {
            _loginPage.GoTo();
            _loginPage.Login("lihag23567@ishense.com", "123456789");
        }


        [When(@"I go to the products page")]
        public void WhenIGoToTheProductsPage()
        {
            _productPage.GoToProducts();
        }

        [When(@"I click on ""(.*)"" of a specific product")]
        public void WhenIClickOnViewProductOfASpecificProduct(string button)
        {
            _productPage.ClickViewProduct();
        }

        [When(@"I click on ""(.*)""")]
        public void WhenIClickOnAddToCart(string button)
        {
            _productPage.ClickAddToCart();
        }

        [Then(@"I should see the ""(.*)"" modal")]
        public void ThenIShouldSeeTheAddedModal(string modalMessage)
        {
            Assert.True(_productPage.IsAddedModalVisible(), $"{modalMessage} modal did not appear!");
        }

        [Then(@"I close the modal")]
        public void ThenICloseTheModal()
        {
            _productPage.CloseModal();
        }
    }
}
