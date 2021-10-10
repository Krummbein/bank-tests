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
        private ChromeDriver driver;
        private readonly string pageURL = "https://parabank.parasoft.com/parabank/updateprofile.htm;jsessionid=D85D814AA1DA1D7AB162A9C5AF7D7617";

        public UpdateProfPage(ChromeDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement fnameField => driver.FindElement(By.Id("customer.firstName"));
        private IWebElement lnameField => driver.FindElement(By.Id("customer.lastName"));
        private IWebElement addressField => driver.FindElement(By.Id("customer.address.street"));
        private IWebElement cityField => driver.FindElement(By.Id("customer.address.city"));
        private IWebElement stateField => driver.FindElement(By.Id("customer.address.state"));
        private IWebElement zipField => driver.FindElement(By.Id("customer.address.zipCode"));
        private IWebElement phoneField => driver.FindElement(By.Id("customer.phoneNumber"));

        public IWebElement FnameField { get => fnameField; }
        public IWebElement LnameField { get => lnameField; }
        public IWebElement AddressField { get => addressField; }
        public IWebElement CityField { get => cityField; }
        public IWebElement StateField { get => stateField; }
        public IWebElement ZipField { get => zipField; }
        public IWebElement PhoneField { get => phoneField; }

        public readonly Dictionary<string, string> errors = new Dictionary<string, string>
        {
            ["fnameErr"] = "First name is required.",
            ["lnameErr"] = "Last name is required.",
            ["addressErr"] = "Address is required.",
            ["cityErr"] = "City is required.",
            ["stateErr"] = "State is required.",
            ["zipErr"] = "Zip Code is required."
        };

        private IWebElement updateButton => driver.FindElement(By.XPath("//input[@class='button' and @value='Update Profile']"));

        private IWebElement updateConfMessage => driver.FindElement(By.XPath("//h1[text()='Profile Updated']"));


        public void ClearAndFillField(string newInput, IWebElement field)
        {
            field.Clear();
            field.SendKeys(newInput);
        }

        public void ClickUpdateButton()
        {
            updateButton.Click();
        }

        public bool LocateUpdateConfMessage()
        {
            return updateConfMessage.Displayed;
        }

        // VULNERABLE TO XPATH INJECTIONS
        public bool LocateErrorMessage(string errorName)
        {
            var error = driver.FindElement(By.XPath("//span[text()='" + errors[errorName] + "']"));
            return error.Displayed;
        }

    }
}
