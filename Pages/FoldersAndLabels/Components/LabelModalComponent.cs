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
    public class LabelModalComponent : BaseComponent
    {
        public LabelModalComponent(IWebDriver driver) : base(driver)
        {
        }
        public IWebElement LabelModal => Driver.FindElement(By.ClassName("pm-modalContent"));
        public IWebElement LabelNameField => LabelModal.FindElement(By.Id("accountName"));
        public IWebElement SaveButton => LabelModal.FindElement(ExtendedBy.ButtonText(FoldersAndLabelsConstants.SAVE));
        public IWebElement CancelButton => LabelModal.FindElement(ExtendedBy.ButtonText(FoldersAndLabelsConstants.CANCEL));
        public IWebElement ColorParentDiv => LabelModal.FindElements(By.CssSelector(".flex.flex-nowrap.mb1.onmobile-flex-column")).ToList().ElementAt(1);
        public IWebElement ColorChoiceDropDown => ColorParentDiv.FindElement(By.TagName("svg"));
        public IWebElement ColorDropDownParent => Driver.FindElement(By.ClassName("dropDown-content"));
        public List<IWebElement> ColorPaletteChoices => ColorDropDownParent.FindElements(By.Name("paletteColor")).ToList();

    }
}
