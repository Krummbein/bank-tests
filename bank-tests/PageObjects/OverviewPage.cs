using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace BankTests.PageObjects
{
    class OverviewPage
    {
        private ChromeDriver _driver;
        private readonly string pageURL = "https://parabank.parasoft.com/parabank/overview.htm";

        public OverviewPage(ChromeDriver driver)
        {
            _driver = driver;
        }

        private IWebElement _updateInfoLink => _driver.FindElement(By.XPath("//a[text()='Update Contact Info']"));

        public UpdateProfPage ClickUpdateInfoLink()
        {
            _updateInfoLink.Click();
            var waitForConfirm = new WebDriverWait(_driver, TimeSpan.FromSeconds(3)).Until(
               c => {
                   IWebElement e = c.FindElement(By.XPath("//h1[text()='Update Profile']"));
                   return e.Displayed;
               });
            return new UpdateProfPage(_driver);
        }
    }
}
