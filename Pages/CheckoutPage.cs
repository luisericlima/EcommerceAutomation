using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace AutomationEcommerce.Pages
{
    public class CheckoutPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public CheckoutPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        // Campo de mensagem
        private By MessageField => By.XPath("//textarea[@name='message']");

        // Botão Place Order
        private By PlaceOrderButton => By.XPath("//a[@href='/payment' and contains(@class,'check_out') and contains(.,'Place Order')]");

        // Escreve mensagem no checkout
        public void EnterMessage(string message)
        {
            var messageElement = _wait.Until(ExpectedConditions.ElementIsVisible(MessageField));
            messageElement.Clear();
            messageElement.SendKeys(message);
        }

        // Clica no Place Order
        public void ClickPlaceOrder()
        {
            var placeOrderElement = _wait.Until(ExpectedConditions.ElementToBeClickable(PlaceOrderButton));
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", placeOrderElement);
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", placeOrderElement);
        }
    }
}
