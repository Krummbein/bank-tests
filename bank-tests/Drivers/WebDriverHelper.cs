using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankTests.Drivers
{
    public class WebDriverHelper : IDisposable
    {
        public ChromeDriver driver;

        public WebDriverHelper()
        {
            driver = new ChromeDriver();
        }

        public void Dispose()
        {
            driver.Quit();
        }
    }
}
