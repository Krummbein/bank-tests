using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace BankTests.PageObjects
{
    public class OverviewPage : Page
    {
        private readonly string pageURL = "https://parabank.parasoft.com/parabank/overview.htm";

        public OverviewPage(ChromeDriver driver) : base(driver)
        {
        }

        private IWebElement _secondAccountSumm => _driver.FindElement(By.XPath("//table[@id='accountTable']/tbody/tr[2]/td[2]"));

        public string GetSecondAccountBalance()
        {
            var waitForConfirm = new WebDriverWait(_driver, TimeSpan.FromSeconds(4)).Until(
               c => {
                   IWebElement e = _secondAccountSumm;
                   return e.Displayed;
               });

            return _secondAccountSumm.Text;
        }
    }
}
