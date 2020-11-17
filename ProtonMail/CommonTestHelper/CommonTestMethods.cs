using BaseSupport.RandomDataGenerator;
using Logger.Helper;
using Logger.UserSettings;
using NUnit.Framework.Internal;
using Pages.FoldersAndLabels;
using Pages.FoldersAndLabels.PageExtensions;
using Pages.SignInPage;
using Pages.SignInPage.PageExtensions;
using System.Collections.Generic;
using System.Linq;

namespace ProtonMail.Tests.CommonTestHelper
{
    public static class TestMethods
    {
        public static FoldersAndLabelsPage SignInAndVerifyUserIsOnFoldersAndLabelsPage(this SignInPage signInPage, User user)
        {
            FoldersAndLabelsPage FoldersAndLabelsPage = signInPage
                .NavigateToHomePage()
                .SignIn(user)
                .VerifyUserIsSignedIn()
                .CloseModalWindow();

            return FoldersAndLabelsPage;
        }        

        public static void CleanUpByDeletingAddedFoldersAndLabels(this FoldersAndLabelsPage foldersAndLabelsPage)
        {
            List<string> folderNames = TestExecutionContext.CurrentContext.CurrentTest.Properties.GetValue<List<string>>(FoldersAndLabelsConstants.ADDED_FOLDERS_LIST) ?? new List<string>();
            List<string> labelNames = TestExecutionContext.CurrentContext.CurrentTest.Properties.GetValue<List<string>>(FoldersAndLabelsConstants.ADDED_LABELS_LIST) ?? new List<string>();

            folderNames = folderNames.Where(x => !x.Contains("/")).ToList();

            foreach (string folderName in folderNames)
            {
                foldersAndLabelsPage.DeleteFolderFromFoldersList(folderName);
            }
            foldersAndLabelsPage.VerifyThereAreNoFoldersAvailable();

            foreach (string label in labelNames)
            {
                foldersAndLabelsPage.DeleteLabelFromLabelsList(label);
            }
            foldersAndLabelsPage.VerifyThereAreNoLabelsAvailable();
        }

        public static void WhenProtomMailPageIsOpenedNestingOfFoldersIsEnabledAndMaximumFolderLimitCanNotBeExceeded(this FoldersAndLabelsPage foldersAndLabelsPage)
        {
            string baseFolderName = RandomDataGenerator.RandomAlphaNumericString(10);
            List<string> folderNames = new List<string>() { baseFolderName};

            //Adding base folder
            foldersAndLabelsPage.AddBaseFolder(baseFolderName)
                    .VerifyFolderIsAdded(baseFolderName);

            int numberOfFolders = FoldersAndLabelsConstants.MAX_NUMBER_OF_FOLDERS - 1;

            //Adding all nested folders
            while(numberOfFolders != 0)
            {
                string currentBaseFolderFullPath = folderNames[folderNames.Count - 1];
                string[] AllBaseFolders = currentBaseFolderFullPath.Split('/');
                string baseChildFolderName = AllBaseFolders[AllBaseFolders.Length - 1];

                string childFolder = RandomDataGenerator.RandomAlphaNumericString(10);

                foldersAndLabelsPage.AddFolderUnderBaseFolder(childFolder, baseChildFolderName)
                    .VerifyFolderIsAdded(childFolder, baseChildFolderName);

                folderNames.Add($"{currentBaseFolderFullPath}/{childFolder}");

                numberOfFolders--;
            }

            TestExecutionContext.CurrentContext.CurrentTest.Properties.Set(FoldersAndLabelsConstants.ADDED_FOLDERS_LIST, folderNames);
            
            //Adding an extra folder, to verify the folder limit is reached
            baseFolderName = RandomDataGenerator.RandomAlphaNumericString(10);

            foldersAndLabelsPage.AddBaseFolder(baseFolderName)
                    .VerifyModalIsNotClosedAfterSave()
                    .ClickCancelOnTheFoldersModal()
                    .VerifyFolderLimitReachedNotificationIsDisplayed()
                    .VerifyFolderIsNotAdded(baseFolderName);                   ;
        }

        public static void WhenProtonMailPageIsOpenedFolderEditingIsEnabled(this FoldersAndLabelsPage foldersAndLabelsPage)
        {
            string baseFolderName = RandomDataGenerator.RandomAlphaNumericString(10);
            string childFolder = RandomDataGenerator.RandomAlphaNumericString(10);
            string newChildFolderName = RandomDataGenerator.RandomAlphaNumericString(10);
            List<string> folderNames = new List<string>() { baseFolderName, newChildFolderName};

            TestExecutionContext.CurrentContext.CurrentTest.Properties.Set(FoldersAndLabelsConstants.ADDED_FOLDERS_LIST, folderNames);


            //Adding base folder
            foldersAndLabelsPage.AddBaseFolder(baseFolderName)
                    .VerifyEntityCreatedNotificationIsDisplayed(baseFolderName)
                    .VerifyFolderIsAdded(baseFolderName);

            //Adding nested folder            
            foldersAndLabelsPage.AddFolderUnderBaseFolder(childFolder, baseFolderName)
                .VerifyFolderIsAdded(childFolder, baseFolderName);

            //Editing child folder name and folder base  
            foldersAndLabelsPage.EditFolderFromFoldersList(childFolder, baseFolderName, newChildFolderName)
                .VerifyEntityUpdatedNotificationIsDisplayed(newChildFolderName)
                .VerifyFolderIsAdded(newChildFolderName); 


        }

        public static void WhenProtonMailPageIsOpenedAndFolderWithSameNameAsExistingFolderOnTheSameLevelFolderCanNotBeAdded(this FoldersAndLabelsPage foldersAndLabelsPage)
        {
            string baseFolderName = RandomDataGenerator.RandomAlphaNumericString(10);
            List<string> folderNames = new List<string>() { baseFolderName };

            //Adding two folders with the same name under same level and verifying that the second one can not be added to the folders list
            foldersAndLabelsPage.AddBaseFolder(baseFolderName)
                    .VerifyEntityCreatedNotificationIsDisplayed(baseFolderName)
                    .VerifyFolderIsAdded(baseFolderName)
                    .AddNewFolder(baseFolderName)
                    .VerifyModalIsNotClosedAfterSave()
                    .ClickCancelOnTheFoldersModal();

            TestExecutionContext.CurrentContext.CurrentTest.Properties.Set(FoldersAndLabelsConstants.ADDED_FOLDERS_LIST, folderNames);

        }

        public static void WhenProtonMailPageIsOpenedAndFolderWithSameNameAsExistingCanBeAddedOnADifferentLevel(this FoldersAndLabelsPage foldersAndLabelsPage)
        {
            string baseFolderName = RandomDataGenerator.RandomAlphaNumericString(10);
            List<string> folderNames = new List<string>() { baseFolderName };

            TestExecutionContext.CurrentContext.CurrentTest.Properties.Set(FoldersAndLabelsConstants.ADDED_FOLDERS_LIST, folderNames);

            //Adding two folders with the same name, just a different location, and verifying that this action can be perfomed
            foldersAndLabelsPage.AddBaseFolder(baseFolderName)
                    .VerifyEntityCreatedNotificationIsDisplayed(baseFolderName)
                    .VerifyFolderIsAdded(baseFolderName)
                    .AddNewFolder(baseFolderName, baseFolderName)
                    .VerifyEntityCreatedNotificationIsDisplayed(baseFolderName);
        }

        public static void WhenProtonMailPageIsOpenedLabelWithNameSameAsExistingFolderCanNotBeAdded(this FoldersAndLabelsPage foldersAndLabelsPage)
        {
            string baseFolderName = RandomDataGenerator.RandomAlphaNumericString(10);
            List<string> folderNames = new List<string>() { baseFolderName };
            TestExecutionContext.CurrentContext.CurrentTest.Properties.Set(FoldersAndLabelsConstants.ADDED_FOLDERS_LIST, folderNames);

            //Adding base folder and adding a new label with the same name as the folder
            foldersAndLabelsPage.AddBaseFolder(baseFolderName)
                    .VerifyFolderIsAdded(baseFolderName)
                    .VerifyEntityCreatedNotificationIsDisplayed(baseFolderName)
                    .AddNewLabel(baseFolderName)
                    .VerifyLabelModalIsNotClosedAfterSave()
                    .VerifyALabelOrFolderWithThisNameAlreadyExistsNotificationIsDisplayed()
                    .ClickCancelOnTheLabelsModal();            
        }

        public static void WhenProtonMailPageIsOpenedFolderNotificationsCanBeDisabled(this FoldersAndLabelsPage foldersAndLabelsPage)
        {
            string baseFolderName = RandomDataGenerator.RandomAlphaNumericString(10);
            List<string> folderNames = new List<string>() { baseFolderName };
            TestExecutionContext.CurrentContext.CurrentTest.Properties.Set(FoldersAndLabelsConstants.ADDED_FOLDERS_LIST, folderNames);

            //Adding base folder and updating the folder notification from the folder row
            foldersAndLabelsPage.AddBaseFolder(baseFolderName)
                    .VerifyEntityCreatedNotificationIsDisplayed(baseFolderName)
                    .VerifyFolderIsAdded(baseFolderName)
                    .ToggleNotificationFromFoldersList(baseFolderName)
                    .VerifyEntityUpdatedNotificationIsDisplayed(baseFolderName);
        }

        public static void WhenProtonMailPageIsOpenedLabelWithSameNameAsExistingCanNotBeAdded(this FoldersAndLabelsPage foldersAndLabelsPage)
        {
            string labelName = RandomDataGenerator.RandomAlphaNumericString(10);
            string labelColor = RandomDataGenerator.RandomItemFromList(FoldersAndLabelsConstants.COLOR_CHOISES.Split('|').ToList());
            string secondLabelColor = RandomDataGenerator.RandomItemFromList(FoldersAndLabelsConstants.COLOR_CHOISES.Split('|').ToList());

            List<string> labelNames = new List<string>() { labelName};
            TestExecutionContext.CurrentContext.CurrentTest.Properties.Set(FoldersAndLabelsConstants.ADDED_LABELS_LIST, labelNames);

            //Adding two labels with the same name and verifying the second can not be added
            foldersAndLabelsPage
                    .AddNewLabel(labelName, labelColor)
                    .VerifyEntityCreatedNotificationIsDisplayed(labelName)
                    .VerifylabelIsAdded(labelName, labelColor)
                    .AddNewLabel(labelName, secondLabelColor)
                    .VerifyLabelModalIsNotClosedAfterSave()
                    .VerifyALabelOrFolderWithThisNameAlreadyExistsNotificationIsDisplayed()
                    .ClickCancelOnTheLabelsModal();
        }

        public static void WhenProtonMailPageIsOpenedLabelEditingIsEnabled(this FoldersAndLabelsPage foldersAndLabelsPage)
        {
            string labelName = RandomDataGenerator.RandomAlphaNumericString(10);
            string labelColor = RandomDataGenerator.RandomItemFromList(FoldersAndLabelsConstants.COLOR_CHOISES.Split('|').ToList());
            string newLabelName = RandomDataGenerator.RandomAlphaNumericString(10);
            string newLabelColor = RandomDataGenerator.RandomItemFromList(FoldersAndLabelsConstants.COLOR_CHOISES.Split('|').ToList());

            List<string> labelNames = new List<string>() { newLabelName };
            TestExecutionContext.CurrentContext.CurrentTest.Properties.Set(FoldersAndLabelsConstants.ADDED_LABELS_LIST, labelNames);

            //Adding label and verifying the same one can be edited
            foldersAndLabelsPage
                    .AddNewLabel(labelName, labelColor)
                    .VerifyEntityCreatedNotificationIsDisplayed(labelName)
                    .VerifylabelIsAdded(labelName, labelColor)
                    .EditExistingLabel(labelName, newLabelName, newLabelColor)
                    .VerifyEntityUpdatedNotificationIsDisplayed(newLabelName)
                    .VerifylabelIsAdded(newLabelName, newLabelColor)
                    .VerifyOldLabelDoesNotExist(labelName, labelColor);
        }

    }
}
