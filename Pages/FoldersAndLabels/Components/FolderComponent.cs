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
    public class FolderComponent : BaseComponent
    {
        public FolderModalComponent FolderModalComponent;
        public FolderComponent(IWebDriver driver) : base(driver)
        {
            FolderModalComponent = new FolderModalComponent(driver);
        }
        
        public IWebElement FoldersSection => Driver.FindElement(By.CssSelector("section[data-target-id='folderlist']"));
        public List<IWebElement> BaseFolderList => FoldersSection.FindElements(By.CssSelector(".treeview-container.unstyled.mt0.mb0")).ToList();
        public IWebElement AddFolderButton => FoldersSection.FindElement(By.TagName("button"));
        public IWebElement DeleteButton => Driver.FindElement(ExtendedBy.ButtonText(FoldersAndLabelsConstants.DELETE));
        public List<IWebElement> NoFoldersAvailableText => FoldersSection.FindElements(By.CssSelector(".mb1.block-info-standard")).ToList();

        public By ToggleLabelText = By.ClassName("pm-toggle-label-text");
    }
}
