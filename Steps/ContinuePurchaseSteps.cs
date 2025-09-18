using AutomationEcommerce.Pages;
using AutomationEcommerce.Support;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Xunit;

namespace AutomationEcommerce.Tests
{
    [Binding]
    public class ContinuePurchaseSteps
    {
        private readonly IWebDriver _driver;
        private readonly LoginPage _loginPage;
        private readonly ProductPage _productPage;
        private readonly CartPage _cartPage;
        private readonly CheckoutPage _checkoutPage;
        private readonly PaymentPage _paymentPage;

        public ContinuePurchaseSteps(WebDriverFixture fixture)
        {
            _driver = fixture.Driver;
            _loginPage = new LoginPage(_driver);
            _productPage = new ProductPage(_driver);
            _cartPage = new CartPage(_driver);
            _checkoutPage = new CheckoutPage(_driver);
            _paymentPage = new PaymentPage(_driver);
        }

        [Given(@"I am logged in to the site for Continue Purchase")]
        public void GivenIAmLoggedInToTheSiteForContinuePurchase()
        {
            _loginPage.GoTo();
            _loginPage.Login("migixe6555@bitfami.com", "123456789");
        }

        [When(@"I add a product to the cart")]
        public void WhenIAddAProductToTheCart()
        {
            _productPage.GoToProducts();
            _productPage.ClickViewProduct();
            _productPage.ClickAddToCart();
        }

        [When(@"I close the modal with ""(.*)""")]
        public void WhenICloseTheModalWithContinueShopping(string buttonText)
        {
            _cartPage.ClickContinueShopping();
        }

        [When(@"I go to the cart")]
        public void WhenIGoToTheCart()
        {
            _cartPage.GoToCart();
        }

        [When(@"I proceed to checkout")]
        public void WhenIProceedToCheckout()
        {
            _cartPage.ProceedToCheckout();
        }

        [When(@"I enter a message in the checkout")]
        public void WhenIEnterAMessageInTheCheckout()
        {
            _checkoutPage.EnterMessage("Please deliver quickly.");
        }

        [When(@"I place the order")]
        public void WhenIPlaceTheOrder()
        {
            _checkoutPage.ClickPlaceOrder();
        }

        [When(@"I fill in the payment details")]
        public void WhenIFillInThePaymentDetails()
        {
            _paymentPage.EnterCardDetails(
                EnvConfig.CardName,
                EnvConfig.CardNumber,
                EnvConfig.CardCVC,
                EnvConfig.CardMonth,
                EnvConfig.CardYear
            );
            _paymentPage.ClickPayButton();
        }

        [Then(@"I should successfully place the order")]
        public void ThenIShouldSuccessfullyPlaceTheOrder()
        {
            Assert.True(_paymentPage.IsOrderSuccessful(), "The order was not placed successfully!");
        }
    }
}
