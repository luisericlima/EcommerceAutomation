using AutomationEcommerce.Helpers;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace AutomationEcommerce.Support
{
    [Binding]
    public class WebDriverFixture : IDisposable
    {
        public IWebDriver Driver { get; private set; }

        public WebDriverFixture()
        {
            Driver = WebDriverHelper.InitializeDriver(); // Initialize WebDriver
        }

        [AfterScenario]
        public void Dispose()
        {
            Driver.Quit(); // Close the browser after each scenario
        }
    }
}
