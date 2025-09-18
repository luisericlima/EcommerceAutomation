using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationEcommerce.Support
{
    public class WebDriverHelper
    {
        public static IWebDriver InitializeDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized"); 
            return new ChromeDriver(options);
        }
    }
}


