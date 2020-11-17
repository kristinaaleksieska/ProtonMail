using OpenQA.Selenium;
using Pages.Base;
using Pages.FoldersAndLabels.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pages.FoldersAndLabels
{
    public class FoldersAndLabelsPage : BasePage
    {
        public override string PageUrl { get; set; } = "https://beta.protonmail.com/settings/u/0/labels";

        public FolderComponent FolderComponent;
        public LabelComponent LabelComponent;
        public NotificationComponent NotificationComponent;

        public FoldersAndLabelsPage(IWebDriver driver) : base(driver)
        {
            FolderComponent = new FolderComponent(driver);
            LabelComponent = new LabelComponent(driver);
            NotificationComponent = new NotificationComponent(driver);
        }

        public IWebElement CloseModal => Driver.FindElement(ModalClose);
        public By ModalClose => By.ClassName("pm-modalClose");
    }
}
