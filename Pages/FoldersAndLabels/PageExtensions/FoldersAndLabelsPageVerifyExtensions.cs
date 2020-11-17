using Logger.Helper;
using NUnit.Framework;
using Pages.FoldersAndLabels.ComponentExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pages.FoldersAndLabels.PageExtensions
{
    public static class FoldersAndLabelsPageVerifyExtensions
    {
        public static FoldersAndLabelsPage VerifyFolderIsAdded(this FoldersAndLabelsPage foldersAndLabelsPage, string folderName, string baseFolderName = "")
        {
            foldersAndLabelsPage.Logger.Info($"Verifying folder with name: {folderName} is added");

            bool isFolderAdded = foldersAndLabelsPage.FolderComponent.GetFolderStructure(folderName, baseFolderName);

            Assert.IsTrue(isFolderAdded, $"The folder with the following name: {folderName} is not added in the folder structure");

            return foldersAndLabelsPage;
        }

        public static FoldersAndLabelsPage VerifyModalIsNotClosedAfterSave(this FoldersAndLabelsPage foldersAndLabelsPage)
        {
            foldersAndLabelsPage.Logger.Info("Verifying Modal is closed after Save button is clicked");

            bool isModalClosed = !foldersAndLabelsPage.FolderComponent.FolderModalComponent.IsFolderModalDisplayed();

            Assert.IsFalse(isModalClosed, "The folder's modal is not closed");

            return foldersAndLabelsPage;
        }

        public static FoldersAndLabelsPage VerifyFolderIsNotAdded(this FoldersAndLabelsPage foldersAndLabelsPage, string folderName, string baseFolderName = "")
        {
            foldersAndLabelsPage.Logger.Info($"Verifying folder with name: {folderName} is not present in the folder's list");

            bool isFolderAdded = foldersAndLabelsPage.FolderComponent.GetFolderStructure(folderName, baseFolderName);

            Assert.IsFalse(isFolderAdded, $"The folder with the following name: {folderName} is added in the folder structure");

            return foldersAndLabelsPage;
        }

        public static FoldersAndLabelsPage VerifyThereAreNoFoldersAvailable(this FoldersAndLabelsPage foldersAndLabelsPage)
        {
            foldersAndLabelsPage.Logger.Info($"Verifying folder's list is empty");

            bool isFoldersListPresentText = foldersAndLabelsPage.FolderComponent.IsNoFoldersAvailableTextPresent();

            Assert.IsTrue(isFoldersListPresentText, "There are folders still present");

            return foldersAndLabelsPage;
        }

        public static FoldersAndLabelsPage VerifyLabelModalIsNotClosedAfterSave(this FoldersAndLabelsPage foldersAndLabelsPage)
        {
            foldersAndLabelsPage.Logger.Info("Verifying label's modal is not closed after clicking on the Save button");

            bool isModalClosed = !foldersAndLabelsPage.LabelComponent.LabelModalComponent.IsLabelModalDisplayed();

            Assert.IsFalse(isModalClosed, $"The label's modal is not closed");

            return foldersAndLabelsPage;
        }

        public static FoldersAndLabelsPage VerifyLabelModalIsClosedAfterSave(this FoldersAndLabelsPage foldersAndLabelsPage)
        {
            foldersAndLabelsPage.Logger.Info("Verifying label's modal is closed after clicking on the Save button");

            bool isModalOpen = foldersAndLabelsPage.LabelComponent.LabelModalComponent.IsLabelModalDisplayed();

            Assert.True(isModalOpen, $"The label's modal is closed");

            return foldersAndLabelsPage;
        }


        public static FoldersAndLabelsPage VerifylabelIsAdded(this FoldersAndLabelsPage foldersAndLabelsPage, string labelName, string labelColor)
        {
            foldersAndLabelsPage.Logger.Info($"Verifying label: {labelName} is added with color: {labelColor}");

            labelColor = Helpers.GetRGBFromColorCode(labelColor);

            bool isLabelAdded = foldersAndLabelsPage.LabelComponent.IsLabelAddedWithColor(labelName, labelColor);

            Assert.IsTrue(isLabelAdded, $"The following label is not added to the list of labels: {labelName}");

            return foldersAndLabelsPage;
        }

        public static FoldersAndLabelsPage VerifyOldLabelDoesNotExist(this FoldersAndLabelsPage foldersAndLabelsPage, string labelName, string labelColor)
        {
            foldersAndLabelsPage.Logger.Info($"Verifying label: {labelName} is not present under the label's list");

            labelColor = Helpers.GetRGBFromColorCode(labelColor);

            bool isLabelAdded = foldersAndLabelsPage.LabelComponent.IsLabelAddedWithColor(labelName, labelColor);

            Assert.False(isLabelAdded, $"The following label still exists to the list of labels: {labelName}");

            return foldersAndLabelsPage;
        }

        public static FoldersAndLabelsPage VerifyThereAreNoLabelsAvailable(this FoldersAndLabelsPage foldersAndLabelsPage)
        {
            foldersAndLabelsPage.Logger.Info("Verifying there are no labels that are present");

            bool isFoldersListPresentText = foldersAndLabelsPage.LabelComponent.IsNoLabelsAvailableTextPresent();

            Assert.IsTrue(isFoldersListPresentText, "There are labels still present");

            return foldersAndLabelsPage;
        }

        public static FoldersAndLabelsPage VerifyEntityCreatedNotificationIsDisplayed(this FoldersAndLabelsPage foldersAndLabelsPage, string entityName)
        {
            string expectedNotificationText = $"{entityName} {FoldersAndLabelsConstants.CREATED}";

            foldersAndLabelsPage.Logger.Info($"Verifying notification: {expectedNotificationText} is displayed on the UI");

            string actualNotificationText = foldersAndLabelsPage.NotificationComponent.GetNotificationText();

            Assert.AreEqual(expectedNotificationText, actualNotificationText, $"No created notification is displayed.");

            return foldersAndLabelsPage;
        }

        public static FoldersAndLabelsPage VerifyEntityRemovedNotificationIsDisplayed(this FoldersAndLabelsPage foldersAndLabelsPage, string entityName)
        {
            string expectedNotificationText = $"{entityName} {FoldersAndLabelsConstants.REMOVED}";

            foldersAndLabelsPage.Logger.Info($"Verifying notification: {expectedNotificationText} is displayed on the UI");

            string actualNotificationText = foldersAndLabelsPage.NotificationComponent.GetNotificationText();

            Assert.AreEqual(expectedNotificationText, actualNotificationText, $"No removed notification is displayed.");

            return foldersAndLabelsPage;
        }

        public static FoldersAndLabelsPage VerifyEntityUpdatedNotificationIsDisplayed(this FoldersAndLabelsPage foldersAndLabelsPage, string entityName)
        {
            string expectedNotificationText = $"{entityName} {FoldersAndLabelsConstants.UPDATED}";

            foldersAndLabelsPage.Logger.Info($"Verifying notification: {expectedNotificationText} is displayed on the UI");

            string actualNotificationText = foldersAndLabelsPage.NotificationComponent.GetNotificationText();

            Assert.AreEqual(expectedNotificationText, actualNotificationText, $"No updated notification is displayed.");

            return foldersAndLabelsPage;
        }

        public static FoldersAndLabelsPage VerifyALabelOrFolderWithThisNameAlreadyExistsNotificationIsDisplayed(this FoldersAndLabelsPage foldersAndLabelsPage)
        {
            foldersAndLabelsPage.Logger.Info($"Verifying notification: {FoldersAndLabelsConstants.A_LABEL_OR_FOLDER_WITH_THIS_NAME_ALREADY_EXISTS} is displayed on the UI");

            string actualNotificationText = foldersAndLabelsPage.NotificationComponent.GetNotificationText();

            Assert.AreEqual(FoldersAndLabelsConstants.A_LABEL_OR_FOLDER_WITH_THIS_NAME_ALREADY_EXISTS, actualNotificationText, $"No {FoldersAndLabelsConstants.A_LABEL_OR_FOLDER_WITH_THIS_NAME_ALREADY_EXISTS} notification displayed");

            return foldersAndLabelsPage;
        }

        public static FoldersAndLabelsPage VerifyFolderLimitReachedNotificationIsDisplayed(this FoldersAndLabelsPage foldersAndLabelsPage)
        {
            foldersAndLabelsPage.Logger.Info($"Verifying notification: {FoldersAndLabelsConstants.FOLDER_LIMIT_REACHED} is displayed on the UI");

            string actualNotificationText = foldersAndLabelsPage.NotificationComponent.GetNotificationText();

            Assert.AreEqual(FoldersAndLabelsConstants.FOLDER_LIMIT_REACHED, actualNotificationText, $"No {FoldersAndLabelsConstants.FOLDER_LIMIT_REACHED} notification displayed");

            return foldersAndLabelsPage;
        }
    }
}
