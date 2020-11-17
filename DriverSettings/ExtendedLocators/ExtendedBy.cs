using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DriverSettings.ExtendedLocators
{
    public static class ExtendedBy
    {
        public static By Type(string type)
        {
            return By.CssSelector($"button[type='{type}']");
        }

        public static By ButtonText(string buttonName)
        {
            return By.XPath($"//button[text()='{buttonName}']");
        }

        public static By ButtonTitle(string title)
        {
            return By.CssSelector($"button[title='{title}']");
        }

        public static By DataTestId(string dataTestId)
        {
            return By.CssSelector($"button[data-test-id='{dataTestId}']");
        }
    }
}
