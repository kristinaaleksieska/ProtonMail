using Pages.FoldersAndLabels.ComponentExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pages.FoldersAndLabels.PageExtensions
{
    public static class FoldersAndLabelsPageActionExtensions
    {
        public static FoldersAndLabelsPage CloseModalWindow(this FoldersAndLabelsPage foldersAndLabelsPage)
        {
            foldersAndLabelsPage.Logger.Info("Closing black Friday's sale modal");

            foldersAndLabelsPage.CloseModal.Click();

            return foldersAndLabelsPage;
        }

        public static FoldersAndLabelsPage AddNewFolder(this FoldersAndLabelsPage foldersAndLabelsPage, string folderName, string baseFolder = "", bool toggleNotification = false)
        {
            baseFolder = string.IsNullOrEmpty(baseFolder) ? FoldersAndLabelsConstants.NO_PARENT_FOLDER : baseFolder;

            foldersAndLabelsPage.Logger.Info($"Adding a new folder {folderName} under the base: {baseFolder}");

            foldersAndLabelsPage.FolderComponent.AddANewFolder(folderName, baseFolder, toggleNotification);

            return foldersAndLabelsPage;
        }

        public static FoldersAndLabelsPage AddBaseFolder(this FoldersAndLabelsPage foldersAndLabelsPage, string baseFolderName)
        {
            foldersAndLabelsPage.AddNewFolder(baseFolderName);

            return foldersAndLabelsPage;
        }

        public static FoldersAndLabelsPage AddFolderUnderBaseFolder(this FoldersAndLabelsPage foldersAndLabelsPage, string folderName, string baseFolderName)
        {
            foldersAndLabelsPage.AddNewFolder(folderName, baseFolderName);

            return foldersAndLabelsPage;
        }
        public static FoldersAndLabelsPage ClickCancelOnTheFoldersModal(this FoldersAndLabelsPage foldersAndLabelsPage)
        {
            foldersAndLabelsPage.Logger.Info("Clicking Cancel on the folder's modal");

            foldersAndLabelsPage.FolderComponent.FolderModalComponent.ClickOnCancelButton();

            return foldersAndLabelsPage;
        }

        public static FoldersAndLabelsPage DeleteFolderFromFoldersList(this FoldersAndLabelsPage foldersAndLabelsPage, string folderName, string baseFolder = "")
        {
            foldersAndLabelsPage.Logger.Info($"Deleting folder : {folderName} and all of its children");

            foldersAndLabelsPage.FolderComponent.DeleteFolder(folderName, baseFolder);

            return foldersAndLabelsPage;
        }

        public static FoldersAndLabelsPage ToggleNotificationFromFoldersList(this FoldersAndLabelsPage foldersAndLabelsPage, string folderName)
        {
            foldersAndLabelsPage.Logger.Info($"Toggling the notifications from the base folder list for the folder: {folderName}");

            foldersAndLabelsPage.FolderComponent.ClickOnToggleNotifications(folderName);

            return foldersAndLabelsPage;
        }
        
        public static FoldersAndLabelsPage EditFolderFromFoldersList(this FoldersAndLabelsPage foldersAndLabelsPage, string oldFolderName, string oldBaseFolder,string newFolderName, string newBaseFolder = "No parent folder", bool toggleNotification = true)
        {
            foldersAndLabelsPage.Logger.Info($"Editing folder: {oldFolderName}");
            foldersAndLabelsPage.Logger.Info($"Renaming folder: {oldFolderName} to be: {newFolderName}");
            foldersAndLabelsPage.Logger.Info($"Moving folder from : {oldBaseFolder} to be under: {newBaseFolder}");
            foldersAndLabelsPage.Logger.Info($"Toggling notification");

            foldersAndLabelsPage.FolderComponent.EditFolder(oldFolderName, oldBaseFolder, newFolderName, newBaseFolder, toggleNotification);

            return foldersAndLabelsPage;
        }

        public static FoldersAndLabelsPage AddNewLabel(this FoldersAndLabelsPage foldersAndLabelsPage, string labelName, string colorCode = "")
        {
            foldersAndLabelsPage.Logger.Info($"Adding a new label: {labelName} with color with code: {colorCode}");

            foldersAndLabelsPage.LabelComponent.AddANewLabel(labelName, colorCode);

            return foldersAndLabelsPage;
        }

        public static FoldersAndLabelsPage EditExistingLabel(this FoldersAndLabelsPage foldersAndLabelsPage, string oldLabelName, string newLabelName, string newColorCode = "")
        {
            foldersAndLabelsPage.Logger.Info($"Editing label: {oldLabelName}");
            foldersAndLabelsPage.Logger.Info($"Renaming label: {oldLabelName} to: {newLabelName}");
            foldersAndLabelsPage.Logger.Info($"Choosing new color with code: {newColorCode}");

            foldersAndLabelsPage.LabelComponent.EditLabel(oldLabelName, newLabelName, newColorCode);

            return foldersAndLabelsPage;
        }

        public static FoldersAndLabelsPage ClickCancelOnTheLabelsModal(this FoldersAndLabelsPage foldersAndLabelsPage)
        {
            foldersAndLabelsPage.Logger.Info("Clicking cancel on label's modal");

            foldersAndLabelsPage.LabelComponent.LabelModalComponent.ClickOnCancelButton();

            return foldersAndLabelsPage;
        }

        public static FoldersAndLabelsPage DeleteLabelFromLabelsList(this FoldersAndLabelsPage foldersAndLabelsPage, string labelName)
        {
            foldersAndLabelsPage.Logger.Info($"Deleting label: {labelName} from the label's list");

            foldersAndLabelsPage.LabelComponent.DeleteLabel(labelName);

            return foldersAndLabelsPage;
        }

    }
}
