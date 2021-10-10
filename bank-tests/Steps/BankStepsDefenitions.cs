using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using BankTests.PageObjects;
using BankTests.Drivers;
using FluentAssertions;
using System.Threading;
using TechTalk.SpecFlow.Assist;
using TechTalk.SpecFlow.Assist.ValueRetrievers;

namespace BankTests.Steps
{
    [Binding]
    public class BankSteps
    {
        private MainPage mainPage;
        private RegPage regPage;

        private readonly WebDriverHelper webDriverHelper;

        public BankSteps(WebDriverHelper webDriverContext)
        {
            this.webDriverHelper = webDriverContext;
        }
       

        [Given(@"I have navigated to main bank page")]
        public void GivenIHaveNavigatedToMainBankPage()
        {
            mainPage = new MainPage(webDriverHelper.driver);
            mainPage.NavigateOnMainPage();
        }
        
        [Given(@"I click register link")]
        public void WhenIClickRegisterLink()
        {
            regPage = mainPage.ClickRegistrationLink();
        }


        [When(@"I enter (.*) in fname field")]
        public void WhenIEnterInFnameField(string p0)
        {
            regPage.FillField(p0, regPage.FnameField);
        }

        [When(@"I enter (.*) in lname field")]
        public void WhenIEnterInLnameField(string p0)
        {
            regPage.FillField(p0, regPage.LnameField);
        }

        [When(@"I enter (.*) in address field")]
        public void WhenIEnterInAddressField(string p0)
        {
            regPage.FillField(p0, regPage.AddressField);
        }

        [When(@"I enter (.*) in city field")]
        public void WhenIEnterInCityField(string p0)
        {
            regPage.FillField(p0, regPage.CityField);
        }

        [When(@"I enter (.*) in state field")]
        public void WhenIEnterInStateField(string p0)
        {
            regPage.FillField(p0, regPage.StateField);
        }

        [When(@"I enter (.*) in zip field")]
        public void WhenIEnterInZipField(string p0)
        {
            regPage.FillField(p0, regPage.ZipField);
        }

        [When(@"I enter (.*) in phone field")]
        public void WhenIEnterInPhoneField(string p0)
        {
            regPage.FillField(p0, regPage.PhoneField);
        }

        [When(@"I enter (.*) in ssn field")]
        public void WhenIEnterInSsnField(string p0)
        {
            regPage.FillField(p0, regPage.SsnField);
        }

        [When(@"I enter (.*) in username field")]
        public void WhenIEnterInUsernameField(string p0)
        {
            regPage.FillField(p0, regPage.UsernameField);
        }

        [When(@"I enter (.*) in password and confirm fields")]
        public void WhenIEnterInPasswordAndConfirmFields(string p0)
        {
            regPage.FillField(p0, regPage.PasswordField);
            regPage.FillField(p0, regPage.ConfirmField);
        }

        [When(@"I click register button")]
        public void WhenIClickRegisterButton()
        {
            regPage.ClickRegisterButton();
        }

        [Then(@"I should see a confirmation message")]
        public void ThenIShouldSeeAConfirmationMessage()
        {
            bool isMessageShown = regPage.LocateConfirmationMessage();
            isMessageShown.Should().BeTrue();
        }

        [Then(@"I should see an (.*) message")]
        public void ThenIShouldSeeAnMessage(string p0)
        {
            bool isErrorMessageShown = regPage.LocateErrorMessage(p0);
            isErrorMessageShown.Should().BeTrue();
        }

    }
}
