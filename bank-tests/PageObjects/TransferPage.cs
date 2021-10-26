using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace BankTests.PageObjects
{
    public class TransferPage : Page
    {
        private readonly string _pageURL = "https://parabank.parasoft.com/parabank/transfer.htm";

        public TransferPage(ChromeDriver driver) : base(driver)
        {
        }


        private IWebElement SummInputField => _driver.FindElement(By.Id("amount"));
        private IWebElement FromAccountList => _driver.FindElement(By.Id("fromAccountId"));
        private IWebElement ToAccountList => _driver.FindElement(By.Id("toAccountId"));

        private IWebElement FirstAccInFromList => _driver.FindElement(By.XPath("//select[@id='fromAccountId']/option[1]"));
        private IWebElement SecondAccInFromList => _driver.FindElement(By.XPath("//select[@id='toAccountId']/option[2]"));

        private IWebElement TransferButton => _driver.FindElement(By.XPath("//input[@value='Transfer']"));
        private IWebElement TransactionCompleteMessage => _driver.FindElement(By.XPath("//h1[text()='Transfer Complete!']"));


        public void FillSummField(string inputSumm)
        {
            SummInputField.SendKeys(inputSumm);
        }


        public void PickFirstAccountInFromList()
        {
            Actions action = new Actions(_driver).MoveToElement(FromAccountList);
            action.Perform();

            var waitForElem = new WebDriverWait(_driver, TimeSpan.FromSeconds(4)).Until(
               c => {
                   IWebElement e = FirstAccInFromList;
                   return e.Displayed;
               });
            FirstAccInFromList.Click();

        }

        public void PickSecondAccountInToList()
        {
            Actions action = new Actions(_driver).MoveToElement(ToAccountList);
            action.Perform();

            var waitForElem = new WebDriverWait(_driver, TimeSpan.FromSeconds(4)).Until(
               c => {
                   IWebElement e = SecondAccInFromList;
                   return e.Displayed;
               });
            SecondAccInFromList.Click();
        }


        public void ClickTransferButton()
        {
            var waitForConfirm = new WebDriverWait(_driver, TimeSpan.FromSeconds(4)).Until(
               c => {
                   IWebElement e = TransferButton;
                   return e.Displayed;
               });

            TransferButton.Click();

            waitForConfirm = new WebDriverWait(_driver, TimeSpan.FromSeconds(4)).Until(
               c => {
                   IWebElement e = TransactionCompleteMessage;
                   return e.Displayed;
               });
        }

        public bool FindCompleteMessage()
        {
            return TransactionCompleteMessage.Displayed;
        }
    }
}
