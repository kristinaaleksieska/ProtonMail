using BaseSupport;
using log4net;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pages.Base
{
    public abstract class BasePage
    {
        public IWebDriver Driver { get; set; }
        public abstract string PageUrl { get; set; }
        public ILog Logger { get; set; }

        public BasePage()
        {
        }

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            Logger = Log.GetLogger();
        }

        public virtual void InitializePageComponents() { 
        }
    }
}
