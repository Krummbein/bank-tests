using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;

namespace BankTests.PageObjects
{
    class UpdateProfPage
    {
        private ChromeDriver _driver;
        private readonly string _pageURL = "https://parabank.parasoft.com/parabank/updateprofile.htm;jsessionid=D85D814AA1DA1D7AB162A9C5AF7D7617";

        public UpdateProfPage(ChromeDriver driver)
        {
            _driver = driver;
        }

        private readonly Dictionary<string, string> _fields = new Dictionary<string, string>
        {
            ["fname"] = "customer.firstName",
            ["lname"] = "customer.lastName",
            ["address"] = "customer.address.street",
            ["city"] = "customer.address.city",
            ["state"] = "customer.address.state",
            ["zip"] = "customer.address.zipCode",
            ["phone"] = "customer.phoneNumber",
        };

        public readonly Dictionary<string, string> _errors = new Dictionary<string, string>
        {
            ["fnameErr"] = "//span[@ng-if='customer && !customer.firstName']",
            ["lnameErr"] = "//span[@ng-if='customer && !customer.firstName']",
            ["addressErr"] = "//span[@ng-if='customer && !customer.firstName']",
            ["cityErr"] = "//span[@ng-if='customer && !customer.firstName']",
            ["stateErr"] = "//span[@ng-if='customer && !customer.firstName']",
            ["zipErr"] = "//span[@ng-if='customer && !customer.address.zipCode']",
        };

        private IWebElement UpdateButton => _driver.FindElement(By.XPath("//input[@class='button' and @value='Update Profile']"));

        private IWebElement UpdateConfMessage => _driver.FindElement(By.XPath("//h1[text()='Profile Updated']"));

        public void ClearAndFillField(string fieldName, string input)
        {
            var field = _driver.FindElement(By.Id(_fields[fieldName]));
            field.Clear();
            field.SendKeys(input);
        }

        public void ClickUpdateButton()
        {
            UpdateButton.Click();
            var waitForConfirm = new WebDriverWait(_driver, TimeSpan.FromSeconds(3)).Until(
               c => {
                   IWebElement e = c.FindElement(By.XPath("//h1[text()='Profile Updated']"));
                   return e.Displayed;
               });
        }

        public bool LocateUpdateConfMessage()
        {
            return UpdateConfMessage.Displayed;
        }

        // VULNERABLE TO XPATH INJECTIONS
        public bool LocateErrorMessage(string errorName)
        {
            var error = _driver.FindElement(By.XPath(_errors[errorName]));
            return error.Displayed;
        }
    }
}
