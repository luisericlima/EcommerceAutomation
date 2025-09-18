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

        private By MessageField => By.XPath("//textarea[@name='message']");

        private By PlaceOrderButton => By.XPath("//a[@href='/payment' and contains(@class,'check_out') and contains(.,'Place Order')]");

        public void EnterMessage(string message)
        {
            var messageElement = _wait.Until(ExpectedConditions.ElementIsVisible(MessageField));
            messageElement.Clear();
            messageElement.SendKeys(message);
        }

        public void ClickPlaceOrder()
        {
            var placeOrderElement = _wait.Until(ExpectedConditions.ElementToBeClickable(PlaceOrderButton));
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", placeOrderElement);
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", placeOrderElement);
        }
    }
}
