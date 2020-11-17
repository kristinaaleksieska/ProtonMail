using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using Pages.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverSettings.Driver
{
    public class DriverFactory
    {
        public IWebDriver Driver {get;set;}

        public IWebDriver CreateChromeDriver(int implicitChromeDriverTimeout = 15, int implicitChromePageLoadTimeOut = 10)
        {
            Driver = new ChromeDriver()
                .ApplyDriverSettings(implicitChromeDriverTimeout, implicitChromePageLoadTimeOut);

            return Driver;
        }

        public IWebDriver CreateFirefoxDriver(int implicitChromeDriverTimeout = 15, int implicitChromePageLoadTimeOut = 10)
        {
            Driver = new FirefoxDriver()
                .ApplyDriverSettings(implicitChromeDriverTimeout, implicitChromePageLoadTimeOut);

            return Driver;
        }
    }
}
