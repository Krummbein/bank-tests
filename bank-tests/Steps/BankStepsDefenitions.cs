using TechTalk.SpecFlow;
using BankTests.PageObjects;
using BankTests.Drivers;
using FluentAssertions;

namespace BankTests.Steps
{
    [Binding]
    public class BankSteps
    {
        private MainPage _mainPage;
        private RegPage _regPage;

        private readonly WebDriverHelper _webDriverHelper;

        public BankSteps(WebDriverHelper webDriverContext)
        {
            _webDriverHelper = webDriverContext;
        }


        [Given(@"I have navigated to main bank page")]
        public void GivenIHaveNavigatedToMainBankPage()
        {
            _mainPage = new MainPage(_webDriverHelper.Driver);
            _mainPage.NavigateOnMainPage();
        }
        
        [Given(@"I click register link")]
        public void WhenIClickRegisterLink()
        {
            _regPage = _mainPage.ClickRegistrationLink();
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
        
        [Then(@"I should see an (.*) message")]
        public void ThenIShouldSeeAnMessage(string errorName)
        {
            bool isErrorMessageShown = _regPage.LocateErrorMessage(errorName);
            isErrorMessageShown.Should().BeTrue();
        }
    }
}
