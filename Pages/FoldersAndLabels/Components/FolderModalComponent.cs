using DriverSettings.ExtendedLocators;
using OpenQA.Selenium;
using Pages.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pages.FoldersAndLabels.Components
{
    public class FolderModalComponent : BaseComponent
    {
        public FolderModalComponent(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement FolderModal => Driver.FindElement(By.ClassName("pm-modalContent"));
        public IWebElement FolderNameField => FolderModal.FindElement(By.Id("accountName"));
        public IWebElement FolderLocationDropDown => FolderModal.FindElement(By.Id("parentID"));
        public List<IWebElement> FolderLocationDropDownOptions => FolderLocationDropDown.FindElements(By.TagName("option")).ToList();
        public List<IWebElement> NotificationOptions => FolderModal.FindElements(By.ClassName("pm-toggle-label-text")).ToList();
        public IWebElement SaveButton => FolderModal.FindElement(ExtendedBy.ButtonText(FoldersAndLabelsConstants.SAVE));
        public IWebElement CancelButton => FolderModal.FindElement(ExtendedBy.ButtonText(FoldersAndLabelsConstants.CANCEL));
    }
}
