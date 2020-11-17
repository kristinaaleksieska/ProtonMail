using DriverSettings.Driver;
using Logger.Helper;
using Logger.UserSettings;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using Pages.FoldersAndLabels;
using Pages.FoldersAndLabels.PageExtensions;
using Pages.SignInPage;
using ProtonMail.Tests.CommonTestHelper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProtonMail.TestBase
{
    public class FirefoxTestBase: TestBase
    {
        public FoldersAndLabelsPage FoldersAndLabelsPage;
        public IWebDriver Driver;
        public User User;

        public override void BeforeEach()
        {
            base.BeforeEach();

            Driver = new DriverFactory().CreateFirefoxDriver();            
            User = UserCredentials.KristinaTestUser;

            FoldersAndLabelsPage = new SignInPage(Driver)
                .SignInAndVerifyUserIsOnFoldersAndLabelsPage(User);
        }

        public override void AfterEach()
        {
            FoldersAndLabelsPage.CleanUpByDeletingAddedFoldersAndLabels();
            Driver.Quit(); 

            base.AfterEach();
        }

        public void GoToTab(int tab = 0)
        {
            Driver.SwitchTo().Window(Driver.WindowHandles[tab]);
        }
    }
}
