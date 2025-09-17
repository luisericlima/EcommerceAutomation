using AutomationEcommerce.Helpers;
using OpenQA.Selenium;
using System;

namespace AutomationEcommerce.Support
{
    public class WebDriverFixture : IDisposable
    {
        public IWebDriver Driver { get; private set; }

        public WebDriverFixture()
        {
            Driver = WebDriverHelper.InitializeDriver(); // Inicializa o WebDriver
        }

        public void Dispose()
        {
            Driver.Quit(); // Fecha o navegador
        }
    }
}