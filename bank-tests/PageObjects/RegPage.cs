using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;

namespace BankTests.PageObjects
{
    class RegPage
    {
        private ChromeDriver driver;
        private readonly string pageURL = "https://parabank.parasoft.com/parabank/register.htm";

        public RegPage(ChromeDriver driver)
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
        private IWebElement ssnField => driver.FindElement(By.Id("customer.ssn"));
        private IWebElement usernameField => driver.FindElement(By.Id("customer.username"));
        private IWebElement passwordField => driver.FindElement(By.Id("customer.password"));
        private IWebElement confirmField => driver.FindElement(By.Id("repeatedPassword"));

        public IWebElement FnameField { get => fnameField; }
        public IWebElement LnameField { get => lnameField; }
        public IWebElement AddressField { get => addressField; }
        public IWebElement CityField { get => cityField; }
        public IWebElement StateField { get => stateField; }
        public IWebElement ZipField { get => zipField; }
        public IWebElement PhoneField { get => phoneField; }
        public IWebElement SsnField { get => ssnField; }
        public IWebElement UsernameField { get => usernameField; }
        public IWebElement PasswordField { get => passwordField; }
        public IWebElement ConfirmField { get => confirmField; }

        public readonly Dictionary<string, string> errors = new Dictionary<string, string>
        {
            ["fnameErr"] = "customer.firstName.errors",
            ["lnameErr"] = "customer.lastName.errors",
            ["addressErr"] = "customer.address.street.errors",
            ["cityErr"] = "customer.address.city.errors",
            ["stateErr"] = "customer.address.state.errors",
            ["zipErr"] = "customer.address.zipCode.errors",
            ["phoneErr"] = "customer.phoneNumber.errors",
            ["ssnErr"] = "customer.ssn.errors",
            ["usernameErr"] = "customer.username.errors",
            ["passwordErr"] = "customer.password.errors",
            ["confirmErr"] = "repeatedPassword.errors"
        };

        private IWebElement registrationButton => driver.FindElement(By.XPath("//input[@class='button' and @value='Register']"));

        private IWebElement confirmationMessage => driver.FindElement(By.XPath("//p[text()='Your account was created successfully. You are now logged in.']"));

       
        public void FillField(string input, IWebElement field)
        {
            field.SendKeys(input);
        }

        public void ClickRegisterButton()
        {
            registrationButton.Click();
        }

        public bool LocateConfirmationMessage()
        {
            return confirmationMessage.Displayed;
        }

        public bool LocateErrorMessage(string errorName)
        {
            var error = driver.FindElement(By.Id(errors[errorName]));
            return error.Displayed;
        }
    }
}
