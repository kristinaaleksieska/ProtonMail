using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pages.Driver
{
    public static class DriverExtensions
    {
        public static T MaximizeDriver<T>(this T webDriver) where T : IWebDriver
        {
            webDriver.Manage().Window.Maximize();

            return webDriver;
        }

        public static T SetImplicitWebDriverTimeout<T>(this T webDriver, TimeSpan timeSpanWait) where T : IWebDriver
        {
            webDriver.Manage().Timeouts().ImplicitWait = timeSpanWait;

            return webDriver;
        }

        public static T SetImplicitPageLoadTimeout<T>(this T webDriver, TimeSpan pageLoadWait) where T : IWebDriver
        {
            webDriver.Manage().Timeouts().PageLoad = pageLoadWait;

            return webDriver;
        }

        public static T ApplyDriverSettings<T>(this T webDriver, int implicitChromeDriverTimeout = 15, int implicitChromePageLoadTimeOut = 10) where T : IWebDriver
        {
            return webDriver.MaximizeDriver()
                .SetImplicitWebDriverTimeout(TimeSpan.FromSeconds(implicitChromeDriverTimeout))
                .SetImplicitPageLoadTimeout(TimeSpan.FromSeconds(implicitChromePageLoadTimeOut));
        }

        public static void WaitForDocumentReadyState<T>(this T webDriver) where T : IWebDriver
        {
            for (int i = 0; i < 30; i++)
            {
                string documentReady = (webDriver as IJavaScriptExecutor).ExecuteScript("return document.readyState") as string;
                if (!documentReady.Equals("complete"))
                {
                    Thread.Sleep(1000);
                }
            }
        }

        public static void NavigateTo<T>(this T webDriver, string url) where T : IWebDriver
        {
            webDriver.Navigate().GoToUrl(url);
            webDriver.WaitForDocumentReadyState();
        }

        public static void RefreshPage<T>(this T webDriver) where T : IWebDriver
        {
            webDriver.Navigate().Refresh();
            webDriver.WaitForDocumentReadyState();
        }

        public static void WaitUntil<T>(this T webDriver, Func<IWebDriver, bool> waitCondition, int waitSeconds = 10) where T : IWebDriver
        {
            var wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(waitSeconds));

            wait.Until(waitCondition);
        }

        public static IWebElement WaitUntilElement<T>(this T element, By by, int waitSeconds = 10) where T : IWebElement
        {
            var wait = new DefaultWait<IWebElement>(element)
            {
                PollingInterval = TimeSpan.FromMilliseconds(500),
                Timeout = TimeSpan.FromSeconds(waitSeconds)
            };

            return wait.Until(e => e.FindElement(by));
        }
    }
}
