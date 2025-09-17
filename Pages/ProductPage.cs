using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace AutomationEcommerce.Pages
{
    public class ProductPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public ProductPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        private By ProductsLink => By.XPath("//a[@href='/products' and contains(., 'Products')]");
        private By ViewProductButton => By.XPath("//a[@href='/product_details/1' and contains(., 'View Product')]");
        private By AddToCartButton => By.XPath("//button[contains(@class, 'cart') and contains(., 'Add to cart')]");
        private By AddedModal => By.XPath("//div[@class='modal-content']//h4[contains(text(),'Added!')]");
        private By ContinueShoppingButton => By.XPath("//button[contains(@class,'close-modal')]");

        public void GoToProducts()
        {
            var productsElement = _wait.Until(ExpectedConditions.ElementToBeClickable(ProductsLink));
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", productsElement);
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", productsElement);
        }

        public void ClickViewProduct()
        {
            var viewProductElement = _wait.Until(ExpectedConditions.ElementIsVisible(ViewProductButton));
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", viewProductElement);
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", viewProductElement);
        }

        public void ClickAddToCart()
        {
            var addToCartElement = _wait.Until(ExpectedConditions.ElementIsVisible(AddToCartButton));
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", addToCartElement);
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", addToCartElement);
        }

        public bool IsAddedModalVisible()
        {
            try
            {
                _wait.Until(ExpectedConditions.ElementIsVisible(AddedModal));
                return true;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

        public void CloseModal()
        {
            var closeButton = _wait.Until(ExpectedConditions.ElementToBeClickable(ContinueShoppingButton));
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", closeButton);
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", closeButton);
        }
    }
}
