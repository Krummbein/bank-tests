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

        private IWebElement _fnameField => _driver.FindElement(By.Id("customer.firstName"));
        private IWebElement _lnameField => _driver.FindElement(By.Id("customer.lastName"));
        private IWebElement _addressField => _driver.FindElement(By.Id("customer.address.street"));
        private IWebElement _cityField => _driver.FindElement(By.Id("customer.address.city"));
        private IWebElement _stateField => _driver.FindElement(By.Id("customer.address.state"));
        private IWebElement _zipField => _driver.FindElement(By.Id("customer.address.zipCode"));
        private IWebElement _phoneField => _driver.FindElement(By.Id("customer.phoneNumber"));

        public IWebElement FnameProp { get => _fnameField; }
        public IWebElement LnameProp { get => _lnameField; }
        public IWebElement AddressProp { get => _addressField; }
        public IWebElement CityProp { get => _cityField; }
        public IWebElement StateProp { get => _stateField; }
        public IWebElement ZipProp { get => _zipField; }
        public IWebElement PhoneProp { get => _phoneField; }

        public readonly Dictionary<string, string> errors = new Dictionary<string, string>
        {
            ["fnameErr"] = "First name is required.",
            ["lnameErr"] = "Last name is required.",
            ["addressErr"] = "Address is required.",
            ["cityErr"] = "City is required.",
            ["stateErr"] = "State is required.",
            ["zipErr"] = "Zip Code is required."
        };

        private IWebElement UpdateButton => _driver.FindElement(By.XPath("//input[@class='button' and @value='Update Profile']"));

        private IWebElement UpdateConfMessage => _driver.FindElement(By.XPath("//h1[text()='Profile Updated']"));


        public void ClearAndFillField(string newInput, IWebElement field)
        {
            field.Clear();
            field.SendKeys(newInput);
        }

        public void ClickUpdateButton()
        {
            UpdateButton.Click();
        }

        public bool LocateUpdateConfMessage()
        {
            return UpdateConfMessage.Displayed;
        }

        // VULNERABLE TO XPATH INJECTIONS
        public bool LocateErrorMessage(string errorName)
        {
            var error = _driver.FindElement(By.XPath("//span[text()='" + errors[errorName] + "']"));
            return error.Displayed;
        }

    }
}
