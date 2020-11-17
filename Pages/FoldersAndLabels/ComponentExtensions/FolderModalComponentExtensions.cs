using OpenQA.Selenium;
using Pages.FoldersAndLabels.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pages.FoldersAndLabels.ComponentExtensions
{
    public static class FolderModalComponentExtensions
    {
        public static FolderModalComponent FillFolderNameField(this FolderModalComponent folderModalComponent, string folderName, bool isUpdate)
        {
            if (isUpdate)
            {
                folderModalComponent.FolderNameField.Click();
                folderModalComponent.FolderNameField.SendKeys(Keys.Control + "a");
                folderModalComponent.FolderNameField.SendKeys(Keys.Backspace);
            }

            folderModalComponent.FolderNameField.SendKeys(folderName);

            return folderModalComponent;
        }

        public static FolderModalComponent ChooseBaseFolder(this FolderModalComponent folderModalComponent, string parentFolder = "")
        {
            folderModalComponent.FolderLocationDropDownOptions.FirstOrDefault(x => x.Text.Contains(parentFolder)).Click();

            return folderModalComponent;
        }

        public static FolderModalComponent ToggleNotification(this FolderModalComponent folderModalComponent, bool toggleNotification = false)
        {
            if (toggleNotification)
            {
                folderModalComponent.NotificationOptions.FirstOrDefault().Click();
            }

            return folderModalComponent;
        }

        public static FolderModalComponent ClickOnSaveButton(this FolderModalComponent folderModalComponent)
        {
            folderModalComponent.SaveButton.Click();

            return folderModalComponent;
        }
        public static FolderModalComponent ClickOnCancelButton(this FolderModalComponent folderModalComponent)
        {
            Thread.Sleep(1000);

            folderModalComponent.CancelButton.Click();

            return folderModalComponent;
        }

        public static bool IsFolderModalDisplayed(this FolderModalComponent folderModalComponent)
        {
            return folderModalComponent.FolderModal.Displayed;
        }

    }
}
