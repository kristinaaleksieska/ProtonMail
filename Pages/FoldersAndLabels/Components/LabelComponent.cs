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
    public class LabelComponent : BaseComponent
    {
        public LabelModalComponent LabelModalComponent;

        public LabelComponent(IWebDriver driver) : base(driver)
        {
            LabelModalComponent = new LabelModalComponent(driver);
        }

        public IWebElement LabelSection => Driver.FindElement(By.CssSelector("section[data-target-id='labellist']"));
        public IWebElement AddLabelButton => LabelSection.FindElement(By.TagName("button"));
        public IWebElement LabelTable => LabelSection.FindElement(By.TagName("table"));
        public List<IWebElement> LabelList => LabelTable.FindElements(By.CssSelector("tr[data-test-id='folders/labels:item-type:label']")).ToList();
        public IWebElement DeleteButton => Driver.FindElement(ExtendedBy.ButtonText(FoldersAndLabelsConstants.DELETE));
        public List<IWebElement> NoLabelsAvailableText => LabelSection.FindElements(By.CssSelector(".mb1.block-info-standard")).ToList();

    }
}
