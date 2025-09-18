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

        // Construtor para injeção do WebDriver
        public ContinuePurchaseSteps(WebDriverFixture fixture)
        {
            _driver = fixture.Driver;
            _loginPage = new LoginPage(_driver);
            _productPage = new ProductPage(_driver);
            _cartPage = new CartPage(_driver);
            _checkoutPage = new CheckoutPage(_driver);
            _paymentPage = new PaymentPage(_driver);
        }

        // Dado que o usuário está logado no site
        [Given(@"I am logged in to the site for Continue Purchase")]
        public void GivenIAmLoggedInToTheSiteForContinuePurchase()
        {
            _loginPage.GoTo();
            _loginPage.Login("lihag23567@ishense.com", "123456789");
        }

        // Quando o usuário adiciona um produto ao carrinho
        [When(@"I add a product to the cart")]
        public void WhenIAddAProductToTheCart()
        {
            _productPage.GoToProducts();
            _productPage.ClickViewProduct();
            _productPage.ClickAddToCart();
        }

        // E o usuário fecha o modal com "Continue Shopping"
        [When(@"I close the modal with ""(.*)""")]
        public void WhenICloseTheModalWithContinueShopping(string buttonText)
        {
            _cartPage.ClickContinueShopping();
        }

        // E o usuário vai para o carrinho
        [When(@"I go to the cart")]
        public void WhenIGoToTheCart()
        {
            _cartPage.GoToCart();
        }

        // E o usuário clica em "Proceed To Checkout"
        [When(@"I proceed to checkout")]
        public void WhenIProceedToCheckout()
        {
            _cartPage.ProceedToCheckout();
        }

        // E o usuário escreve uma mensagem no checkout
        [When(@"I enter a message in the checkout")]
        public void WhenIEnterAMessageInTheCheckout()
        {
            _checkoutPage.EnterMessage("Please deliver quickly.");
        }

        // E o usuário clica em "Place Order"
        [When(@"I place the order")]
        public void WhenIPlaceTheOrder()
        {
            _checkoutPage.ClickPlaceOrder();
        }

        // E o usuário preenche os dados de pagamento
        [When(@"I fill in the payment details")]
        public void WhenIFillInThePaymentDetails()
        {
            _paymentPage.EnterCardDetails(
                "Invente qualquer",
                "5552324588490628",
                "630",
                "11",
                "2026"
            );
            _paymentPage.ClickPayButton();

        }

        // Então o pedido deve ser realizado com sucesso
        [Then(@"I should successfully place the order")]
        public void ThenIShouldSuccessfullyPlaceTheOrder()
        {
            Assert.True(_paymentPage.IsOrderSuccessful(), "The order was not placed successfully!");
        }
    }
}
