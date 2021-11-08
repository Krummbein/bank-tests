using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace BankTests.PageObjects
{
    public class FindTransactionsPage : Page
    {
        private readonly string _pageURL = "https://parabank.parasoft.com/parabank/findtrans.htm";

        public FindTransactionsPage(ChromeDriver driver) : base(driver)
        {
        }

        private readonly Dictionary<string, string> _fields = new Dictionary<string, string>
        {
            ["FindByDate"] = "criteria.onDate",
            ["FindByAmount"] = "criteria.amount"
        };


        private IWebElement ButtonFindByDate => 
            _driver.FindElement(By.XPath(string.Concat("//button[@ng-click=", '"', "criteria.searchType = 'DATE'", '"', "]")));
        private IWebElement ButtonFindByAmount =>
            _driver.FindElement(By.XPath(string.Concat("//button[@ng-click=", '"', "criteria.searchType = 'AMOUNT'", '"', "]")));

        private IWebElement TransactionResults => _driver.FindElement(By.XPath("//h1[text()='Transaction Results']"));
        private IWebElement ErrorMessage => _driver.FindElement(By.ClassName("error"));


        public void FillField(string input, string fieldName)
        {
            var field = _driver.FindElement(By.Id(_fields[fieldName]));
            field.SendKeys(input);
        }

        public void ClickFindButton(string fieldName)
        {
            switch (fieldName)
            {
                case "FindByDate":
                    ButtonFindByDate.Click();
                    break;
                case "FindByAmount":
                    ButtonFindByAmount.Click();
                    break;
            }

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

        
        // method not yet working with double funds amount
        public bool LocateTransactions(string input, string fieldName)
        {

            IWebElement colomn;
            bool waitForConfirm;
            switch (fieldName)
            {
                case "FindByDate":
                    colomn = _driver.FindElement(By.XPath("//*[text()='"+input+"']"));
                    waitForConfirm = new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(
                    c =>
                    {
                        IWebElement e = colomn;
                        return e.Displayed;
                    });
                    return colomn.Displayed;

                case "FindByAmount":
                    colomn = _driver.FindElement(By.XPath("//*[text()='$" + input + ".00']"));
                    waitForConfirm = new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(
                    c =>
                    {
                        IWebElement e = colomn;
                        return e.Displayed;
                    });
                    return colomn.Displayed;
                default:
                    return false;
            }
        }
    }
}
