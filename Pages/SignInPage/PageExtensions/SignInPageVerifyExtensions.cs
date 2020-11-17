using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using Pages.Driver;
using Pages.FoldersAndLabels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pages.SignInPage.PageExtensions
{
    public static class SignInPageVerifyExtensions
    {
        public static FoldersAndLabelsPage VerifyUserIsSignedIn(this SignInPage signInPage)
        {
            FoldersAndLabelsPage FoldersAndLabelsPage = new FoldersAndLabelsPage(signInPage.Driver);

            string ExpectedPageUrl = FoldersAndLabelsPage.PageUrl;            

            signInPage.Logger.Info($"Verifying that user is logged in and successfully navigated to: {ExpectedPageUrl}");

            signInPage.Driver.WaitUntil(Driver => Driver.Url.Equals(ExpectedPageUrl));

            Assert.AreEqual(ExpectedPageUrl, signInPage.Driver.Url, $"The actual page url is not {ExpectedPageUrl}");

            return FoldersAndLabelsPage;
        }
    }
}
