using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BankTests.PageObjects
{
    class OverviewPage
    {
        private ChromeDriver driver;
        private readonly string pageURL = "https://parabank.parasoft.com/parabank/overview.htm";

        public OverviewPage(ChromeDriver driver)
        {
            this.driver = driver;
        }
    }
}
