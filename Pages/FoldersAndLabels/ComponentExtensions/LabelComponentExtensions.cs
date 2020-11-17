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
    public static class LabelComponentExtensions
    {
        public static LabelComponent ClickOnAddLabelButton(this LabelComponent labelComponent)
        {
            Thread.Sleep(1000);

            labelComponent.AddLabelButton.Click();

            return labelComponent;
        }

        public static LabelComponent AddANewLabel(this LabelComponent labelComponent, string labelName, string colorCode)
        {
            labelComponent.ClickOnAddLabelButton()
                .PerformCommonAddOrEditLabelActions(labelName, colorCode);

            return labelComponent;
        }

        public static LabelComponent EditLabel(this LabelComponent labelComponent, string oldLabelName, string newLabelName = "", string newColorCode = "")
        {
            labelComponent.ClickOnEditLabel(oldLabelName)
                .PerformCommonAddOrEditLabelActions(newLabelName, newColorCode, true);

            return labelComponent;
        }


        public static LabelComponent ClickOnEditLabel(this LabelComponent labelComponent, string oldLabelName)
        {
            IWebElement labelRow = labelComponent
              .LabelList
              .FirstOrDefault(x => x.Text.Contains(oldLabelName));

            labelRow.WaitUntilElement(ExtendedBy.DataTestId("folders/labels:item-edit")).Click();

            return labelComponent;
        }

        public static LabelComponent DeleteLabel(this LabelComponent labelComponent, string labelToDelete)
        {
            IWebElement labelRow = labelComponent
              .LabelList
              .FirstOrDefault(x => x.Text.Contains(labelToDelete));

            Thread.Sleep(2000);
            labelRow.WaitUntilElement(ExtendedBy.DataTestId("dropdown:open")).Click();
            labelComponent.DeleteButton.WaitUntilElement(ExtendedBy.ButtonText(FoldersAndLabelsConstants.DELETE)).Click();

            Thread.Sleep(1000);
            labelComponent.DeleteButton.WaitUntilElement(ExtendedBy.ButtonText(FoldersAndLabelsConstants.DELETE), 15).Click();

            return labelComponent;
        }
        public static LabelComponent PerformCommonAddOrEditLabelActions(this LabelComponent labelComponent, string newLabelName = "", string newLabelColor = "", bool isUpdate = false)
        {
            labelComponent.LabelModalComponent
                .FillLabelNameField(newLabelName, isUpdate)
                .ChooseLabelColor(newLabelColor)
                .ClickOnSaveButton();

            return labelComponent;
        }

        public static bool IsLabelAddedWithColor(this LabelComponent labelComponent, string labelName, string labelColor)
        {
            Thread.Sleep(1000);

            List<IWebElement> labelsList = labelComponent.LabelList;
            List<string> labelNames = new List<string>();
            Dictionary<string, string> labelNamesAndColors = new Dictionary<string, string>();

            foreach (var label in labelsList)
            {
                string labelNameText = label.FindElement(By.CssSelector("td > div > span")).Text;
                string labelNameColor = label.FindElement(By.CssSelector("td > div > svg")).GetCssValue("fill");
                labelNamesAndColors.Add(labelNameText, labelNameColor);
            }

            return labelNamesAndColors.FirstOrDefault(x => x.Key.Equals(labelName)).Value?.Equals(labelColor) ?? false;
        }
        public static bool IsNoLabelsAvailableTextPresent(this LabelComponent labelComponent)
        {
            Thread.Sleep(1000);

            return labelComponent.NoLabelsAvailableText.FirstOrDefault(x => x.Text.Equals(FoldersAndLabelsConstants.NO_LABELS_AVAILABLE)) != null;
        }
    }
}
