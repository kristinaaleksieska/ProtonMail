using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pages.Base
{
    public class BaseComponent
    {
        public IWebDriver Driver { get; set; }

        public BaseComponent(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}
