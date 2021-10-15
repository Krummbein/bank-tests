using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankTests.PageObjects
{
    class FindTransactionsPage
    {
        private ChromeDriver _driver;
        private readonly string _pageURL = "https://parabank.parasoft.com/parabank/findtrans.htm";

        public FindTransactionsPage(ChromeDriver driver)
        {
            _driver = driver;
        }

        private readonly Dictionary<string, string> _fields = new Dictionary<string, string>
        {
            ["dateField"] = "criteria.onDate",
            ["amountField"] = "criteria.amount"
        };

        private readonly Dictionary<string, string> _buttons = new Dictionary<string, string>
        {
            ["dateButton"] = string.Concat("//button[@ng-click=", '"', "criteria.searchType = 'DATE'", '"', "]"),
            ["amountButton"] = string.Concat("//button[@ng-click=", '"', "criteria.searchType = 'AMOUNT'", '"', "]")
        };

        // not yet used, will be necessary in case of confirming by attribute
        private readonly Dictionary<string, string> _attributes = new Dictionary<string, string>
        {
            ["dateAttribute"] = "",
            ["amountAttribute"] = ""
        };


        private IWebElement FindByDateField => _driver.FindElement(By.Id("criteria.onDate"));
        private IWebElement FindByAmountField => _driver.FindElement(By.Id("criteria.amount"));
        private IWebElement TransactionResults => _driver.FindElement(By.XPath("//h1[text()='Transaction Results']"));
        private IWebElement ErrorMessage => _driver.FindElement(By.ClassName("error"));


        public void FillField(string input, string fieldName)
        {
            var field = _driver.FindElement(By.Id(_fields[fieldName]));
            field.SendKeys(input);
        }

        public void ClickFindButton(string buttonName)
        {
            var button = _driver.FindElement(By.XPath(_buttons[buttonName]));
            button.Click();
        }

        public bool LocateTransactionResult()
        {
            var waitForConfirm = new WebDriverWait(_driver, TimeSpan.FromSeconds(3)).Until(
               c =>
               {
                   IWebElement e = TransactionResults;
                   return e.Displayed;
               });
            return TransactionResults.Displayed;
        }

        public bool LocateErrorMessage()
        {
            var waitForConfirm = new WebDriverWait(_driver, TimeSpan.FromSeconds(3)).Until(
               c =>
               {
                   IWebElement e = ErrorMessage;
                   return e.Displayed;
               });
            return ErrorMessage.Displayed;
        }


        // not yet used, will be necessary in case of confirming by attribute
        public void LocateTransactions(string input, string attribute)
        {

        }
    }
}
