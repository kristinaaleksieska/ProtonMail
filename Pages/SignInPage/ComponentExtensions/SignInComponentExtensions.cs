using Pages.SignInPage.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pages.SignInPage.ComponentExtensions
{
    public static class SignInComponentExtensions
    {
        public static SignInComponent FillEmailField(this SignInComponent signInComponent, string email)
        {
            signInComponent.EmailField.SendKeys(email);

            return signInComponent;
        }

        public static SignInComponent FillPasswordField(this SignInComponent signInComponent, string password)
        {
            signInComponent.PasswordField.SendKeys(password);

            return signInComponent;
        }

        public static SignInComponent ClickSignInButton(this SignInComponent signInComponent)
        {
            signInComponent.SignInButton.Click();

            return signInComponent;
        }
    }
}
