using OpenQA.Selenium;
using Pages.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pages.FoldersAndLabels.Components
{
    public class NotificationComponent : BaseComponent
    {
        public NotificationComponent(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement NotificationContainer => Driver.FindElement(By.CssSelector(".notifications-container.flex.flex-column.flex-items-center"));
        public IWebElement Notification => Driver.FindElements(By.CssSelector("div[role='alert']")).LastOrDefault();
    }
}
