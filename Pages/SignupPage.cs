using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace AutomationEcommerce.Pages
{
    public class SignupPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public SignupPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        // Campos iniciais de cadastro
        private IWebElement NameField => _driver.FindElement(By.XPath("//input[@data-qa='signup-name']"));
        private IWebElement EmailField => _driver.FindElement(By.XPath("//input[@data-qa='signup-email']"));
        private IWebElement SignupButton => _driver.FindElement(By.XPath("//button[@data-qa='signup-button']"));

        // Botão de criação de conta
        private IWebElement CreateAccountButton => _wait.Until(
            ExpectedConditions.ElementToBeClickable(By.XPath("//button[@data-qa='create-account']"))
        );

        // Campos do formulário adicional
        private IWebElement TitleMr => _driver.FindElement(By.XPath("//input[@id='id_gender1']"));
        private IWebElement PasswordField => _driver.FindElement(By.XPath("//input[@data-qa='password']"));
        private IWebElement DaySelect => _driver.FindElement(By.XPath("//select[@data-qa='days']"));
        private IWebElement MonthSelect => _driver.FindElement(By.XPath("//select[@data-qa='months']"));
        private IWebElement YearSelect => _driver.FindElement(By.XPath("//select[@data-qa='years']"));
        private IWebElement FirstNameField => _driver.FindElement(By.XPath("//input[@data-qa='first_name']"));
        private IWebElement LastNameField => _driver.FindElement(By.XPath("//input[@data-qa='last_name']"));
        private IWebElement AddressField => _driver.FindElement(By.XPath("//input[@data-qa='address']"));
        private IWebElement Address2Field => _driver.FindElement(By.XPath("//input[@data-qa='address2']"));
        private IWebElement CompanyField => _driver.FindElement(By.XPath("//input[@data-qa='company']"));
        private IWebElement CountrySelect => _driver.FindElement(By.XPath("//select[@data-qa='country']"));
        private IWebElement StateField => _driver.FindElement(By.XPath("//input[@data-qa='state']"));
        private IWebElement CityField => _driver.FindElement(By.XPath("//input[@data-qa='city']"));
        private IWebElement ZipCodeField => _driver.FindElement(By.XPath("//input[@data-qa='zipcode']"));
        private IWebElement MobileField => _driver.FindElement(By.XPath("//input[@data-qa='mobile_number']"));

        public void FillInitialSignup(string name, string email)
        {
            NameField.Clear();
            NameField.SendKeys(name);

            EmailField.Clear();
            EmailField.SendKeys(email);

            SignupButton.Click();
        }

        public void FillCompleteForm(string password, string firstName, string lastName,
                                     string address, string address2, string company, string state,
                                     string city, string zipcode, string mobile)
        {
            // Espera até que o campo "Mr." esteja visível
            _wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@id='id_gender1']")));

            TitleMr.Click();
            PasswordField.SendKeys(password);

            new SelectElement(DaySelect).SelectByValue("10");
            new SelectElement(MonthSelect).SelectByValue("5");
            new SelectElement(YearSelect).SelectByValue("2000");

            FirstNameField.SendKeys(firstName);
            LastNameField.SendKeys(lastName);
            AddressField.SendKeys(address);
            Address2Field.SendKeys(address2);
            CompanyField.SendKeys(company);

            new SelectElement(CountrySelect).SelectByText("India");
            StateField.SendKeys(state);
            CityField.SendKeys(city);
            ZipCodeField.SendKeys(zipcode);
            MobileField.SendKeys(mobile);
        }

        public void SubmitCreateAccount()
        {
            CreateAccountButton.Click();
        }

        public void ClickSignupButton()
        {
            SignupButton.Click();
        }

        public string GetErrorMessage()
        {
            try
            {
                var errorMessageElement = _wait.Until(
                    ExpectedConditions.ElementIsVisible(By.XPath("//p[contains(text(), 'Email Address already exist!')]"))
                );
                return errorMessageElement.Text.Trim();
            }
            catch (WebDriverTimeoutException)
            {
                return string.Empty;
            }
        }

        public void WaitForUrlContains(string partialUrl)
        {
            _wait.Until(ExpectedConditions.UrlContains(partialUrl));
        }
    }
}
