using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankTests.Drivers
{
    public class WebDriverContext
    {
        public ChromeDriver driver;

        public WebDriverContext()
        {
            driver = new ChromeDriver();
        }
    }
}
