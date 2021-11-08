using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace BankTests.PageObjects
{
    public abstract class Page
    {
        protected ChromeDriver _driver;

        public Page(ChromeDriver driver)
        {
            _driver = driver;
        }

        protected IWebElement RegistrationLink => _driver.FindElement(By.XPath("//a[text()='Register']"));
        private IWebElement TransferFundsLink => _driver.FindElement(By.XPath("//a[text()='Transfer Funds']"));
        private IWebElement OpenAccountLink => _driver.FindElement(By.XPath("//a[text()='Open New Account']"));
        private IWebElement UpdateInfoLink => _driver.FindElement(By.XPath("//a[text()='Update Contact Info']"));
        private IWebElement FindTransactionsLink => _driver.FindElement(By.XPath("//a[text()='Find Transactions']"));
        private IWebElement OverviewLink => _driver.FindElement(By.XPath("//a[text()='Accounts Overview']"));


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


        public TransferPage ClickTransferFundsLink()
        {
            TransferFundsLink.Click();

            var waitForConfirm = new WebDriverWait(_driver, TimeSpan.FromSeconds(3)).Until(
              c => {
                  IWebElement e = c.FindElement(By.XPath("//h1[text()='Transfer Funds']"));
                  return e.Displayed;
              });

            return new TransferPage(_driver);
        }


        public OpenAccPage ClickOpenAccountLink()
        {
            OpenAccountLink.Click();

            var waitForConfirm = new WebDriverWait(_driver, TimeSpan.FromSeconds(3)).Until(
              c => {
                  IWebElement e = c.FindElement(By.XPath("//h1[text()='Open New Account']"));
                  return e.Displayed;
              });

            return new OpenAccPage(_driver);
        }


        public UpdateProfPage ClickUpdateInfoLink()
        {
            UpdateInfoLink.Click();
            var waitForConfirm = new WebDriverWait(_driver, TimeSpan.FromSeconds(3)).Until(
               c => {
                   IWebElement e = c.FindElement(By.XPath("//h1[text()='Update Profile']"));
                   return e.Displayed;
               });
            return new UpdateProfPage(_driver);
        }

        public FindTransactionsPage ClickFindTransactionsLink()
        {
            FindTransactionsLink.Click();
            var waitForConfirm = new WebDriverWait(_driver, TimeSpan.FromSeconds(3)).Until(
               c => {
                   IWebElement e = c.FindElement(By.XPath("//h1[text()='Find Transactions']"));
                   return e.Displayed;
               });
            return new FindTransactionsPage(_driver);
        }

        public OverviewPage ClickOverviewLink()
        {
            OverviewLink.Click();

            var waitForConfirm = new WebDriverWait(_driver, TimeSpan.FromSeconds(3)).Until(
              c => {
                  IWebElement e = c.FindElement(By.XPath("//h1[text()='Accounts Overview']"));
                  return e.Displayed;
              });

            return new OverviewPage(_driver);
        }
    }
}
