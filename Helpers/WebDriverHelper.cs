using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationEcommerce.Helpers
{
    public class WebDriverHelper
    {
        public static IWebDriver InitializeDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized"); // Maximiza a janela
            return new ChromeDriver(options);
        }
    }
}
