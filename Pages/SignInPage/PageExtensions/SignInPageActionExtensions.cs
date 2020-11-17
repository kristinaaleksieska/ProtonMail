using log4net;
using Logger;
using Logger.UserSettings;
using Pages.Driver;
using Pages.SignInPage.ComponentExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pages.SignInPage.PageExtensions
{
    public static class SignInPageActionExtensions
    {
        public static SignInPage NavigateToHomePage(this SignInPage signInPage)
        {
            signInPage.Logger.Info($"Navigating to the page with the following URL: {signInPage.PageUrl}");

            signInPage.Driver.NavigateTo(signInPage.PageUrl);

            return signInPage;
        }

        public static SignInPage SignIn(this SignInPage signInPage, User user)
        {
            signInPage.Logger.Info($"Logging in with email: {user.UserName} and passsword: {user.Password}");

            signInPage
                .SignInComponent
                .FillEmailField(user.UserName)
                .FillPasswordField(user.Password)
                .ClickSignInButton();

            return signInPage;
        }
    }
}
