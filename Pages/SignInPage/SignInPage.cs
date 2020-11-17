using OpenQA.Selenium;
using Pages.Base;
using Pages.SignInPage.Components;

namespace Pages.SignInPage
{
    public class SignInPage : BasePage
    {
        public override string PageUrl { get; set; } = "https://beta.protonmail.com/settings/u/0/labels";
        public SignInComponent SignInComponent { get; set; }

        public SignInPage(IWebDriver driver) : base(driver)
        {
            SignInComponent = new SignInComponent(driver);
        }


    }
}
