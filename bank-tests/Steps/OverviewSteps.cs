using BankTests.Drivers;
using BankTests.PageObjects;
using TechTalk.SpecFlow;
using FluentAssertions;

namespace BankTests.Steps
{
    [Binding, Scope(Feature = "Overview")]
    class OverviewSteps
    {
        private LoginPage _loginPage;
        private RegPage _regPage;
        private OpenAccPage _openAccPage;
        private TransferPage _transferPage;
        private FindTransactionsPage _findTransactionsPage;

        private OverviewPage _overviewPage;

        private readonly WebDriverHelper _webDriverHelper;

        public OverviewSteps(WebDriverHelper webDriverHelper)
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


        [Given(@"I have created second account on this user")]
        public void GivenIHaveCreatedSecondAccountOnThisUser()
        {
            _openAccPage = _regPage.ClickOpenAccountLink();
            _openAccPage.ClickopenAccountButton();
        }



        [Given(@"I have navigated to Transfer Page")]
        public void GivenIHaveNavigatedToTransferPage()
        {
            _transferPage = _openAccPage.ClickTransferFundsLink();
        }


        [When(@"I transfer (.*) from the first account to the second")]
        public void WhenITransferFromTheFirstAccountToTheSecond(string inputSumm)
        {
            _transferPage.FillSummField(inputSumm);
            _transferPage.PickFirstAccountInFromList();
            _transferPage.PickSecondAccountInToList();
            _transferPage.ClickTransferButton();
        }

        [When(@"I navigate to Overview Page")]
        public void WhenINavigateToOverviewPage()
        {
            _overviewPage = _transferPage.ClickOverviewLink();
        }


        [Then(@"I should see (.*) on the second account")]
        public void ThenIShouldSeeOnTheSecondAccount(string newSumm)
        {
            var result = _overviewPage.GetSecondAccountBalance();
            result.Should().BeEquivalentTo(newSumm);
        }

        [When(@"I navigate to Find Transaction Page")]
        public void WhenINavigateToFindTransactionPage()
        {
            _findTransactionsPage = _overviewPage.ClickFindTransactionsLink();
        }

        [When(@"I enter (.*) into (.*) field")]
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


        [Then(@"I should see transactions with (.*) from the (.*)")]
        public void ThenIShouldSeeTransactionsWithFromThe(string input, string field)
        {
            var result = _findTransactionsPage.LocateTransactions(input, field);
            result.Should().BeTrue();
        }

    }
}
