using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace AutomationEcommerce.Support
{
    [Binding]
    public class WebDriverFixture : IDisposable
    {
        public IWebDriver Driver { get; private set; }

        public WebDriverFixture()
        {
            Driver = WebDriverHelper.InitializeDriver(); 
        }

        [AfterScenario]
        public void Dispose()
        {
            Driver.Quit(); 
        }
    }
}
