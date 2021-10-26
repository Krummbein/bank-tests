using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;

namespace BankTests.PageObjects
{
    public class OpenAccPage : Page
    {
        private readonly string _pageURL = "https://parabank.parasoft.com/parabank/openaccount.htm";

        public OpenAccPage(ChromeDriver driver) : base(driver)
        {
        }

        private IWebElement OpenAccountButton => _driver.FindElement(By.XPath("//input[@value='Open New Account']"));
        
        public void ClickopenAccountButton()
        {
            Thread.Sleep(3000);

            OpenAccountButton.Click();

            Thread.Sleep(3000);
            //var waitForConfirm = new WebDriverWait(_driver, TimeSpan.FromSeconds(1000)).Until(
            //   c => {
            //       IWebElement e = c.FindElement(By.XPath("//h1[text()='Account Opened!']"));
            //       return e.Displayed;
            //   });
        }

        
    }
}
