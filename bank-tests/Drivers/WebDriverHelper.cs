using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankTests.Drivers
{
    public class WebDriverHelper : IDisposable
    {
        public ChromeDriver Driver;

        public WebDriverHelper()
        {
            Driver = new ChromeDriver();
        }

        public void Dispose()
        {
            Driver.Quit();
        }
    }
}
