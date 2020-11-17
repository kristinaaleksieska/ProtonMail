using DriverSettings.ExtendedLocators;
using OpenQA.Selenium;
using Pages.Driver;
using Pages.FoldersAndLabels.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pages.FoldersAndLabels.ComponentExtensions
{
    public static class FolderComponentExtensions
    {
        public static FolderComponent ClickOnAddFolder(this FolderComponent folderComponent)
        {
            Thread.Sleep(1000);

            folderComponent.AddFolderButton.Click();

            return folderComponent;
        }

        public static FolderComponent ClickOnEditFolder(this FolderComponent folderComponent, string folderToEdit, string oldBaseFolder)
        {
            IWebElement folderRow = folderComponent.GetFolderRow(folderToEdit, oldBaseFolder);

            Thread.Sleep(1000);

            folderRow.WaitUntilElement(ExtendedBy.DataTestId("folders/labels:item-edit")).Click();

            return folderComponent;
        }

        public static FolderComponent ClickOnToggleNotifications(this FolderComponent folderComponent, string folderName)
        {
            IWebElement folderRow = folderComponent.GetFolderRow(folderName);

            Thread.Sleep(1000);

            folderRow.WaitUntilElement(folderComponent.ToggleLabelText).Click();

            return folderComponent;
        }

        public static FolderComponent DeleteFolder(this FolderComponent folderComponent, string folderToDelete, string baseFolder)
        {
            IWebElement folderRow = folderComponent.GetFolderRow(folderToDelete, baseFolder);

            Thread.Sleep(2000);
            folderRow.WaitUntilElement(ExtendedBy.DataTestId("dropdown:open")).Click();
            folderComponent.DeleteButton.WaitUntilElement(ExtendedBy.ButtonText(FoldersAndLabelsConstants.DELETE)).Click();

            Thread.Sleep(1000);
            folderComponent.DeleteButton.WaitUntilElement(ExtendedBy.ButtonText(FoldersAndLabelsConstants.DELETE), 15).Click();

            return folderComponent;
        }

        public static FolderComponent AddANewFolder(this FolderComponent folderComponent, string folderName, string baseFolder = "", bool toggleNotification = false)
        {
            folderComponent
                .ClickOnAddFolder()
                .PerformCommonAddOrEditFolderActions(folderName, baseFolder, toggleNotification);

            return folderComponent;
        }

        public static FolderComponent EditFolder(this FolderComponent folderComponent, string oldFolderName, string oldBaseFolder, string newFolderName, string newBaseFolder = "", bool toggleNotification = false)
        {
            folderComponent
                .ClickOnEditFolder(oldFolderName, oldBaseFolder)
                .PerformCommonAddOrEditFolderActions(newFolderName, newBaseFolder, toggleNotification, true);

            return folderComponent;
        }

        public static FolderComponent PerformCommonAddOrEditFolderActions(this FolderComponent folderComponent, string folderName, string baseFolder = "", bool toggleNotification = false, bool isUpdate = false)
        {
            folderComponent.FolderModalComponent
                .FillFolderNameField(folderName, isUpdate)
                .ChooseBaseFolder(baseFolder)
                .ToggleNotification(toggleNotification)
                .ClickOnSaveButton();

            return folderComponent;
        }

        public static bool GetFolderStructure(this FolderComponent folderComponent, string folderName, string baseFolderName)
        {
            IWebElement folderRow = folderComponent.GetFolderRow(folderName, baseFolderName);
            
            return folderRow != null;
        }

        public static IWebElement GetFolderRow(this FolderComponent folderComponent, string folderName, string baseFolderName = "")
        {
            string folderPath = string.IsNullOrEmpty(baseFolderName) ? folderName : $"{baseFolderName}/{folderName}";

            List<IWebElement> folderRows = folderComponent.BaseFolderList;
            bool isFound = false;

            IWebElement folderRow = folderComponent.BaseFolderList.FirstOrDefault();

            foreach (var possibleFolderRow in folderRows)
            {
                folderRow = possibleFolderRow.FindElements(By.TagName("li"))
                    .FirstOrDefault(p => p.GetAttribute("title")
                    .Contains(folderPath));

                if (folderRow != null)
                {
                    isFound = true;
                    break;
                }
            }

            return folderRow;
        }

        public static bool IsNoFoldersAvailableTextPresent(this FolderComponent folderComponent)
        {
            Thread.Sleep(2000);

            return folderComponent.NoFoldersAvailableText.FirstOrDefault(x => x.Text.Equals(FoldersAndLabelsConstants.NO_FOLDERS_AVAILABLE)) != null;
        }
    }
}
