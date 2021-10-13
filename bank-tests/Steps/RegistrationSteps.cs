using TechTalk.SpecFlow;
using BankTests.PageObjects;
using BankTests.Drivers;
using FluentAssertions;

namespace BankTests.Steps
{
    [Binding, Scope(Feature = "Registration")]
    public class RegistrationSteps
    {
        private LoginPage _loginPage;
        private RegPage _regPage;

        private readonly WebDriverHelper _webDriverHelper;

        public RegistrationSteps(WebDriverHelper webDriverHelper)
        {
            _webDriverHelper = webDriverHelper;
        }

        [Given(@"I have navigated to bank's login page")]
        public void GivenIHaveNavigatedToBankSLoginPage()
        {
            _loginPage = new LoginPage(_webDriverHelper.Driver);
            _loginPage.NavigateOnMainPage();
        }


        [Given(@"I click register link")]
        public void WhenIClickRegisterLink()
        {
            _regPage = _loginPage.ClickRegistrationLink();
        }
        
        [When(@"I enter the following information")]
        public void WhenIEnterTheFollowingInformation(Table tableFieldInput)
        {
            foreach (var row in tableFieldInput.Rows) _regPage.FillField(row[0], row[1]);
        }
        
        [When(@"I click register button")]
        public void WhenIClickRegisterButton()
        {
            _regPage.ClickRegisterButton();
        }
        
        [Then(@"I should see a registration confirmation message")]
        public void ThenIShouldSeeARegistrationConfirmationMessage()
        {
            bool isMessageShown = _regPage.LocateConfirmationMessage();
            isMessageShown.Should().BeTrue();
        }
        
        [Then(@"I should see an (.*) error message")]
        public void ThenIShouldSeeAnErrorMessage(string errorName)
        {
            bool isErrorMessageShown = _regPage.LocateErrorMessage(errorName);
            isErrorMessageShown.Should().BeTrue();
        }
    }
}
