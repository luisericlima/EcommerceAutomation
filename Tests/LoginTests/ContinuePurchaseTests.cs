using LightBDD.XUnit2;
using Xunit;
using OpenQA.Selenium;
using AutomationEcommerce.Pages;
using AutomationEcommerce.Support;

namespace AutomationEcommerce.Tests
{
    public class ContinuePurchaseTests : IClassFixture<WebDriverFixture>
    {
        private readonly IWebDriver _driver;
        private readonly LoginPage _loginPage;
        private readonly ProductPage _productPage;
        private readonly CartPage _cartPage;
        private readonly CheckoutPage _checkoutPage;
        private readonly PaymentPage _paymentPage;

        public ContinuePurchaseTests(WebDriverFixture fixture)
        {
            _driver = fixture.Driver;
            _loginPage = new LoginPage(_driver);
            _productPage = new ProductPage(_driver);
            _cartPage = new CartPage(_driver);
            _checkoutPage = new CheckoutPage(_driver);
            _paymentPage = new PaymentPage(_driver);
        }

        [Scenario]
        public void CompletePurchaseFlow()
        {
            // 1. Loga no site
            _loginPage.GoTo();
            _loginPage.Login("lihag23567@ishense.com", "123456789");

            // 2. Adiciona produto ao carrinho
            _productPage.GoToProducts();
            _productPage.ClickViewProduct();
            _productPage.ClickAddToCart();

            // 3. Fecha o modal com Continue Shopping
            _cartPage.ClickContinueShopping();

            // 4. Vai para o carrinho
            _cartPage.GoToCart();

            // 5. Clica em Proceed To Checkout
            _cartPage.ProceedToCheckout();

            // 6. Escreve mensagem no campo Message
            _checkoutPage.EnterMessage("Por favor, entregue rapidamente.");

            // 7. Clica em Place Order
            _checkoutPage.ClickPlaceOrder();

            // 8. Preenche dados do cartão
            _paymentPage.EnterCardDetails(
                name: "Invente qualquer",
                number: "5552324588490628",
                cvc: "630",
                month: "11",
                year: "2026"
            );

            // 9. Clica em Pay and Confirm Order
            _paymentPage.ClickPayButton();

            // 10. Valida que o pedido foi realizado com sucesso
            Assert.True(_paymentPage.IsOrderSuccessful(), "O pedido não foi realizado com sucesso!");
        }
    }
}
