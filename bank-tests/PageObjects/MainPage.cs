using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace BankTests.PageObjects
{
    class MainPage
    {
        private ChromeDriver driver;
        private readonly string pageURL = "https://parabank.parasoft.com/parabank/register.htm";

        public MainPage(ChromeDriver driver)
        {
            this.driver = driver;
        }


        private IWebElement usernameField => driver.FindElement(By.XPath("//input[@name='username']"));
        private IWebElement passwordField => driver.FindElement(By.XPath("//input[@name='password']"));
        private IWebElement logInButton => driver.FindElement(By.XPath("//input[@value='Log In']"));
        private IWebElement registrationLink => driver.FindElement(By.XPath("//a[text()='Register']"));


        public void NavigateOnMainPage()
        {
            driver.Navigate().GoToUrl(pageURL);
            var waitForConfirm = new WebDriverWait(driver, TimeSpan.FromSeconds(3)).Until(
               c => {
                   IWebElement e = c.FindElement(By.XPath("//img[@alt='ParaBank']"));
                   return e.Displayed;
               });
        }


        public RegPage ClickRegistrationLink()
        {
            registrationLink.Click();
            var waitForConfirm = new WebDriverWait(driver, TimeSpan.FromSeconds(3)).Until(
               c => {
                   IWebElement e = c.FindElement(By.Id("customerForm"));
                   return e.Displayed;
               });
            return new RegPage(driver);
        }

        public OverviewPage ClickLogInButton()
        {
            logInButton.Click();
            var waitForConfirm = new WebDriverWait(driver, TimeSpan.FromSeconds(3)).Until(
              c => {
                  IWebElement e = c.FindElement(By.XPath("//h1[text()='Accounts Overview']"));
                  return e.Displayed;
              });
            return new OverviewPage(driver);
        }

        public void LogInAsUserWithPassword(string nickname, string password)
        {

        }
    }
}
