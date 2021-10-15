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
    [Binding, Scope(Feature = "Transaction")]
    class FindTransactionsSteps
    {
        private LoginPage _loginPage;
        private OverviewPage _overviewPage;
        private FindTransactionsPage _findTransactionsPage;

        private readonly WebDriverHelper _webDriverHelper;

        public FindTransactionsSteps(WebDriverHelper webDriverHelper)
        {
            _webDriverHelper = webDriverHelper;
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

        [When(@"I click Find Transactions link")]
        public void WhenIClickFindTransactionsLink()
        {
            _findTransactionsPage = _overviewPage.ClickFindTransactionsLink();
            Thread.Sleep(3000);
        }

        [When(@"I enter (.*) into (.*)")]
        public void WhenIEnterInto(string input, string field)
        {
            _findTransactionsPage.FillField(input, field);
        }

        [When(@"I click (.*) button")]
        public void WhenIClickButton(string button)
        {
            _findTransactionsPage.ClickFindButton(button);
        }

        [Then(@"I should see transaction results")]
        public void ThenIShouldSeeTransactionResults()
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

    }
}
