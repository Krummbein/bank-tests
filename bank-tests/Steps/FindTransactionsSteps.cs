using BankTests.Drivers;
using BankTests.PageObjects;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace BankTests.Steps
{
    [Binding, Scope(Feature = "FindTransaction")]
    class FindTransactionsSteps
    {
        private LoginPage _loginPage;
        private RegPage _regPage;
        private FindTransactionsPage _findTransactionsPage;
        private TransferPage _transferPage;
        private OverviewPage _overviewPage;

        private readonly WebDriverHelper _webDriverHelper;

        public FindTransactionsSteps(WebDriverHelper webDriverHelper)
        {
            _webDriverHelper = webDriverHelper;
        }


        [Given(@"I have a registered user (.*) with password (.*)")]
        public void GivenIHaveARegisteredUserPWithPassword(string username, string password)
        {
            string[] header = { "fname", "lname", "address", "city", "state", "zip", "phone", "ssn", "username", "password", "confirm" };
            string[] input = { "paul", "meme", "address", "city", "state", "zip", "phone", "ssn", username, password, password };

            _loginPage = new LoginPage(_webDriverHelper.Driver);
            _loginPage.NavigateOnMainPage();

            _regPage = _loginPage.ClickRegistrationLink();

            for (int i = 0; i < header.Length; i++) _regPage.FillField(header[i], input[i]);

            _regPage.ClickRegisterButton();
        }


        
        [Given(@"I have navigated to bank's login page")]
        public void GivenIHaveNavigatedToBankSLoginPageUpdate()
        {
            _loginPage = new LoginPage(_webDriverHelper.Driver);
            _loginPage.NavigateOnMainPage();
        }

        
        [Given(@"I have loged in as (.*) with password (.*)")]
        public void GivenIHaveLogedInAsWithPassword(string username, string password)
        {
            _loginPage.FillUsernameAndPassword(username, password);
            _overviewPage = _loginPage.ClickLogInButton();
        }


        // NOT USED
        [Given(@"I have transfered (.*) funds")]
        public void GivenIHaveTransferedFunds(string inputSumm)
        {
            _transferPage = _regPage.ClickTransferFundsLink();
            _transferPage.FillSummField(inputSumm);
            _transferPage.ClickTransferButton();
        }


        [When(@"I click Find Transactions link")]
        public void WhenIClickFindTransactionsLink()
        {
            _findTransactionsPage = _overviewPage.ClickFindTransactionsLink();
        }


        [When(@"I enter (.*) into (.*)")]
        public void WhenIEnterInto(string input, string field)
        {
            _findTransactionsPage.FillField(input, field);
        }


        [When(@"I click Find Transaction button for (.*) field")]
        public void WhenIClickFindTransactionButtonForThis(string field)
        {
            _findTransactionsPage.ClickFindButton(field);
        }


        [Then(@"the page with results should open")]
        public void ThenThePageWithResultsShouldOpen()
        {
            var result = _findTransactionsPage.LocateTransactionResult();
            result.Should().BeTrue();
        }


        [Then(@"I should see error message")]
        public void ThenIShouldSeeErrorMessage()
        {
            var result = _findTransactionsPage.LocateErrorMessage();
            result.Should().BeTrue();
        }

        
        [Then(@"I should see transactions with (.*) from the (.*)")]
        public void ThenIShouldSeeTransactionsWithFromThe(string input, string field)
        {
            var result = _findTransactionsPage.LocateTransactions(input, field);
            result.Should().BeTrue();
        }
    }
}
