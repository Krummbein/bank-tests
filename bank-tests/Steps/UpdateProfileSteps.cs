using BankTests.Drivers;
using BankTests.PageObjects;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace BankTests.Steps
{
    [Binding, Scope(Feature = "UpdateProfile")]
    class UpdateProfileSteps
    {
        private LoginPage _loginPage;
        private OverviewPage _overviewPage;
        private UpdateProfPage _updateProfPage;

        private readonly WebDriverHelper _webDriverHelper;

        public UpdateProfileSteps(WebDriverHelper webDriverHelper)
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

        [When(@"I click Update Contact Info link")]
        public void WhenIClickUpdateContactInfoLink()
        {
            _updateProfPage = _overviewPage.ClickUpdateInfoLink();
        }

        [When(@"I fill in new information")]
        public void WhenIFillInNewInformation(Table tableNewInput)
        {
            foreach (var row in tableNewInput.Rows) _updateProfPage.ClearAndFillField(row[0], row[1]);
        }

        [When(@"I click Update Profile button")]
        public void WhenIClickUpdateProfileButton()
        {
            _updateProfPage.ClickUpdateButton();
        }

        [Then(@"I should see an update confirmation message")]
        public void ThenIShouldSeeAnUpdateConfirmationMessage()
        {
            bool isUpdateMessageShown = _updateProfPage.LocateUpdateConfMessage();
            isUpdateMessageShown.Should().BeTrue();
        }

        [Then(@"I should see a (.*) error message")]
        public void ThenIShouldSeeANameErrorMessage(string errorName)
        {
            bool isErrorMessageShown = _updateProfPage.LocateErrorMessage(errorName);
            isErrorMessageShown.Should().BeTrue();
        }
    }
}
