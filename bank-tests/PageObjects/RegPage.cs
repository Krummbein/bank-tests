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
        private IWebElement registrationButton => driver.FindElement(By.XPath("//input[@class='button' and @value='Register']"));

        private IWebElement confirmationMessage => driver.FindElement(By.XPath("//p[text()='Your account was created successfully. You are now logged in.']"));

        public void FillField(string objectName, string input)
        {
            IWebElement neededField = (IWebElement)typeof(IWebElement).GetProperty(objectName);
            neededField.SendKeys(input);
        }

        public void ClickRegisterButton()
        {
            registrationButton.Click();
            var waitForConfirm = new WebDriverWait(driver, TimeSpan.FromSeconds(3)).Until(
                c => {
                    return confirmationMessage.Displayed;
                });
        }

        public bool LocateConfirmationMessage()
        {
            return confirmationMessage.Displayed;
        }

        public void fillFName(string input)
        {
            fnameField.SendKeys(input);
        }

        public void fillLName(string input)
        {
            lnameField.SendKeys(input);
        }

        public void fillAddress(string input)
        {
            addressField.SendKeys(input);
        }

        public void fillCity(string input)
        {
            cityField.SendKeys(input);
        }

        public void fillState(string input)
        {
            stateField.SendKeys(input);
        }

        public void fillZip(string input)
        {
            zipField.SendKeys(input);
        }

        public void fillPhone(string input)
        {
            phoneField.SendKeys(input);
        }

        public void fillSSN(string input)
        {
            ssnField.SendKeys(input);
        }

        public void fillUsername(string input)
        {
            usernameField.SendKeys(input);
        }

        public void fillPassword(string input)
        {
            passwordField.SendKeys(input);
        }

        public void confirmPassword(string input)
        {
            confirmField.SendKeys(input);
        }

    }
}
