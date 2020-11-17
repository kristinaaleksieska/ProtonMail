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
    public class ChromeTestBase : TestBase
    {
        public FoldersAndLabelsPage FoldersAndLabelsPage;
        public User User;
        public IWebDriver Driver;

        public override void BeforeEach()
        {
            base.BeforeEach();

            Driver = new DriverFactory().CreateChromeDriver();
            User = UserCredentials.KristinaTestUser;

            FoldersAndLabelsPage = new SignInPage(Driver)
                .SignInAndVerifyUserIsOnFoldersAndLabelsPage(User);
        }

        public override void AfterEach()
        {
            //try
            //{
                
            //}
            //catch(Exception e)
            //{
            //    Console.WriteLine(e.Me);
            //}
            //finally
            //{
            //    Driver.Quit();
            //}
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
