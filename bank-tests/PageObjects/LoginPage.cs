using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace BankTests.PageObjects
{
    class LoginPage
    {
        private ChromeDriver _driver;
        private readonly string _pageURL = "https://parabank.parasoft.com/parabank/index.htm";

        public LoginPage(ChromeDriver driver)
        {
            _driver = driver;
        }


        private IWebElement UsernameField => _driver.FindElement(By.XPath("//input[@name='username']"));
        private IWebElement PasswordField => _driver.FindElement(By.XPath("//input[@name='password']"));
        private IWebElement LogInButton => _driver.FindElement(By.XPath("//input[@value='Log In']"));
        private IWebElement RegistrationLink => _driver.FindElement(By.XPath("//a[text()='Register']"));


        public void NavigateOnMainPage()
        {
            _driver.Navigate().GoToUrl(_pageURL);
            var waitForConfirm = new WebDriverWait(_driver, TimeSpan.FromSeconds(3)).Until(
               c => {
                   IWebElement e = c.FindElement(By.XPath("//img[@alt='ParaBank']"));
                   return e.Displayed;
               });
        }

        public RegPage ClickRegistrationLink()
        {
            RegistrationLink.Click();
            var waitForConfirm = new WebDriverWait(_driver, TimeSpan.FromSeconds(3)).Until(
               c => {
                   IWebElement e = c.FindElement(By.Id("customerForm"));
                   return e.Displayed;
               });
            return new RegPage(_driver);
        }

        public OverviewPage ClickLogInButton()
        {
            LogInButton.Click();
            var waitForConfirm = new WebDriverWait(_driver, TimeSpan.FromSeconds(3)).Until(
              c => {
                  IWebElement e = c.FindElement(By.XPath("//h1[text()='Accounts Overview']"));
                  return e.Displayed;
              });
            return new OverviewPage(_driver);
        }

        public void FillUsernameAndPassword(string username, string password)
        {
            UsernameField.SendKeys(username);
            PasswordField.SendKeys(password);
        }
    }
}
