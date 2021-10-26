using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace BankTests.PageObjects
{
    public class RegPage : Page
    {

        private readonly string _pageURL = "https://parabank.parasoft.com/parabank/register.htm";

        public RegPage(ChromeDriver driver) : base(driver)
        {
            
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
            ["ssn"] = "customer.ssn",
            ["username"] = "customer.username",
            ["password"] = "customer.password",
            ["confirm"] = "repeatedPassword"
        };

        private readonly Dictionary<string, string> _errors = new Dictionary<string, string>
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

        private IWebElement _registrationButton => _driver.FindElement(By.XPath("//input[@class='button' and @value='Register']"));
        private IWebElement _confirmationMessage => _driver.FindElement(By.XPath("//p[text()='Your account was created successfully. You are now logged in.']"));
        

        public void FillField(string fieldName, string input)
        {
            var field = _driver.FindElement(By.Id(_fields[fieldName]));
            field.SendKeys(input);
        }

        public void ClickRegisterButton()
        {
            _registrationButton.Click();
            var waitForConfirm = new WebDriverWait(_driver, TimeSpan.FromSeconds(3)).Until(
              c => {
                  IWebElement e = _confirmationMessage;
                  return e.Displayed;
              });
        }

        public bool LocateConfirmationMessage()
        {
            return _confirmationMessage.Displayed;
        }
        public bool LocateErrorMessage(string errorName)
        {
            var error = _driver.FindElement(By.Id(_errors[errorName]));
            return error.Displayed;
        }
    }
}
