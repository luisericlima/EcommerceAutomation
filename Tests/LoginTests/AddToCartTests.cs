using LightBDD.XUnit2;
using Xunit;
using OpenQA.Selenium;
using AutomationEcommerce.Pages;
using AutomationEcommerce.Support;

namespace AutomationEcommerce.Tests
{
    public class AddToCartTests : IClassFixture<WebDriverFixture>
    {
        private readonly IWebDriver _driver;
        private readonly LoginPage _loginPage;
        private readonly ProductPage _productPage;

        public AddToCartTests(WebDriverFixture fixture)
        {
            _driver = fixture.Driver;
            _loginPage = new LoginPage(_driver);
            _productPage = new ProductPage(_driver);
        }

        [Scenario]
        public void AddProductToCart()
        {
            // 1. Loga no site
            _loginPage.GoTo();
            _loginPage.Login("lihag23567@ishense.com", "123456789");

            // 2. Vai para a página de produtos
            _productPage.GoToProducts();

            // 3. Clica em "View Product" do produto específico
            _productPage.ClickViewProduct();

            // 4. Clica em "Add to cart"
            _productPage.ClickAddToCart();

            // 5. Valida se o modal "Added!" apareceu
            Assert.True(_productPage.IsAddedModalVisible(), "O modal de produto adicionado não apareceu!");

            // 6. Fecha o modal
            _productPage.CloseModal();
        }
    }
}
