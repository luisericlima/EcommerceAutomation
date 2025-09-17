using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace AutomationEcommerce.Pages
{
    public class CartPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public CartPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        // Botões
        private By ContinueShoppingButton => By.XPath("//button[contains(@class,'close-modal') and contains(., 'Continue Shopping')]");
        private By CartMenu => By.XPath("//li/a[@href='/view_cart' and contains(., 'Cart')]");
        private By ProceedToCheckoutButton => By.XPath("//a[contains(@class,'check_out') and contains(., 'Proceed To Checkout')]");

        // Clica no botão Continue Shopping do modal
        public void ClickContinueShopping()
        {
            var continueButton = _wait.Until(ExpectedConditions.ElementToBeClickable(ContinueShoppingButton));
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", continueButton);
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", continueButton);
        }

        // Clica no menu Cart
        public void GoToCart()
        {
            var cartElement = _wait.Until(ExpectedConditions.ElementToBeClickable(CartMenu));
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", cartElement);
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", cartElement);
        }

        // Clica no botão Proceed To Checkout
        public void ProceedToCheckout()
        {
            var checkoutButton = _wait.Until(ExpectedConditions.ElementToBeClickable(ProceedToCheckoutButton));
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", checkoutButton);
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", checkoutButton);
        }
    }
}
