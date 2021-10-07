using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BankTests.Steps
{
    [Binding]
    public class BankSteps
    {
        private ChromeDriver chromeDriver;
        

        public BankSteps() => chromeDriver = new ChromeDriver();

        [Given(@"I have navigated to main bank page")]
        public void GivenIHaveNavigatedToMainBankPage()
        {
            chromeDriver.Navigate().GoToUrl("https://parabank.parasoft.com/parabank/register.htm");
            var waitForConfirm = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(3)).Until(
               c => {
                   IWebElement e = c.FindElement(By.XPath("//img[@alt='ParaBank']"));
                   return e.Displayed;
               });
        }
        
        [When(@"I click register link")]
        public void WhenIClickRegisterLink()
        {
            chromeDriver.FindElement(By.XPath("//a[text()='Register']"));
            var waitForConfirm = new WebDriverWait(chromeDriver, TimeSpan.FromSeconds(3)).Until(
               c => {
                   IWebElement e = c.FindElement(By.Id("customerForm"));
                   return e.Displayed;
               });
        }

        [Then(@"I can see registration button")]
        public void ThenICanSeeRegistrationButton()
        {
            chromeDriver.FindElement(By.XPath("//input[@class='button' and @value='Register']"));
        }
    }
}
