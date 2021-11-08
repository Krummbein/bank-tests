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
        private RegPage _regPage;

        private Page _currentPage;

        private readonly WebDriverHelper _webDriverHelper;

        public UpdateProfileSteps(WebDriverHelper webDriverHelper)
        {
            _webDriverHelper = webDriverHelper;
        }

        // NOT USED
        [Given(@"I have navigated to bank's login page")]
        public void GivenIHaveNavigatedToBankSLoginPageUpdate()
        {
            _loginPage = new LoginPage(_webDriverHelper.Driver);
            _loginPage.NavigateOnMainPage();
        }

        // NOT USED
        [Given(@"I have loged in as (.*) with password (.*)")]
        public void GivenIHaveLogedInAsWithPassword(string username, string password)
        {
            _loginPage.FillUsernameAndPassword(username, password);
            _overviewPage = _loginPage.ClickLogInButton();
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

        [When(@"I click Update Contact Info link")]
        public void WhenIClickUpdateContactInfoLink()
        {
            _updateProfPage = _regPage.ClickUpdateInfoLink();
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
