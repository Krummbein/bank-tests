using BankTests.Drivers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace BankTests.Hooks
{
    class TearDownHook
    {
        WebDriverContext webDriverContext;

        public TearDownHook(WebDriverContext webDriverContext)
        {
            this.webDriverContext = webDriverContext;
        }

        [AfterScenario("@withBrowserTeardown")]
        public void QuitBrowser()
        {
            webDriverContext.driver.Quit();
        }

    }
}
