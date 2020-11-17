using DriverSettings.ExtendedLocators;
using OpenQA.Selenium;
using Pages.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pages.SignInPage.Components
{
    public class SignInComponent : BaseComponent
    {
        public SignInComponent(IWebDriver driver) : base(driver)
        {

        }

        public IWebElement EmailField => Driver.FindElement(By.Id("login"));
        public IWebElement PasswordField => Driver.FindElement(By.Id("password"));
        public IWebElement SignInButton => Driver.FindElement(ExtendedBy.Type("submit"));

    }
}
