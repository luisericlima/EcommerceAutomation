using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace AutomationEcommerce.Pages
{
    public class PaymentPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public PaymentPage(IWebDriver driver)
        {
            _driver = driver;
            // Tempo de espera padrão 10s
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        private By NameOnCardField => By.XPath("//input[@name='name_on_card']");
        private By CardNumberField => By.XPath("//input[@name='card_number']");
        private By CVCField => By.XPath("//input[@name='cvc']");
        private By ExpiryMonthField => By.XPath("//input[@name='expiry_month']");
        private By ExpiryYearField => By.XPath("//input[@name='expiry_year']");
        private By PayButton => By.XPath("//button[@data-qa='pay-button']");

        private By OrderPlacedText => By.XPath("//b[text()='Order Placed!']");

        // Preenche os dados do cartão
        public void EnterCardDetails(string name, string number, string cvc, string month, string year)
        {
            _wait.Until(ExpectedConditions.ElementIsVisible(NameOnCardField)).SendKeys(name);
            _driver.FindElement(CardNumberField).SendKeys(number);
            _driver.FindElement(CVCField).SendKeys(cvc);
            _driver.FindElement(ExpiryMonthField).SendKeys(month);
            _driver.FindElement(ExpiryYearField).SendKeys(year);
        }

        // Clica no botão Pay and Confirm Order
        public void ClickPayButton()
        {
            var payButton = _wait.Until(ExpectedConditions.ElementToBeClickable(PayButton));
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", payButton);
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", payButton);
        }


        // Valida se o pedido foi realizado com sucesso
        public bool IsOrderSuccessful()
        {
            try
            {
                // Espera 10 segundos antes de verificar o elemento
                var shortWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
                shortWait.Until(ExpectedConditions.ElementIsVisible(OrderPlacedText));
                return true;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }
    }
}
