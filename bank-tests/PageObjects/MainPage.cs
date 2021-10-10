using System;
using System.Collections.Generic;
using System.Text;
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
            driver.FindElement(By.XPath("//a[text()='Register']")).Click();
            var waitForConfirm = new WebDriverWait(driver, TimeSpan.FromSeconds(3)).Until(
               c => {
                   IWebElement e = c.FindElement(By.Id("customerForm"));
                   return e.Displayed;
               });
            return new RegPage(driver);
        }


    }
}
