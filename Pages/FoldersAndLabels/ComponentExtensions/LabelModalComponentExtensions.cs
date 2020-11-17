using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Pages.FoldersAndLabels.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pages.FoldersAndLabels.ComponentExtensions
{
    public static class LabelModalComponentExtensions
    {
        public static LabelModalComponent FillLabelNameField(this LabelModalComponent labelModalComponent, string labelName = "", bool isUpdate = false)
        {
            if (isUpdate)
            {
                labelModalComponent.LabelNameField.Click();
                labelModalComponent.LabelNameField.SendKeys(Keys.Control + "a");
                labelModalComponent.LabelNameField.SendKeys(Keys.Backspace);
            }

            labelModalComponent.LabelNameField.SendKeys(labelName);

            return labelModalComponent;
        }

        public static LabelModalComponent ChooseLabelColor(this LabelModalComponent labelModalComponent, string colorCode = "")
        {
            if (!string.IsNullOrEmpty(colorCode))
            {
                labelModalComponent.ColorChoiceDropDown.Click();
                var bla = labelModalComponent.ColorPaletteChoices;
                labelModalComponent.ColorPaletteChoices.FirstOrDefault(x => x.GetAttribute("value").Equals(colorCode)).Click();
                new Actions(labelModalComponent.Driver).SendKeys(Keys.Escape);
            }

            return labelModalComponent;
        }

        public static LabelModalComponent ClickOnSaveButton(this LabelModalComponent labelModalComponent)
        {
            labelModalComponent.SaveButton.Click();

            return labelModalComponent;
        }
        public static LabelModalComponent ClickOnCancelButton(this LabelModalComponent labelModalComponent)
        {
            labelModalComponent.CancelButton.Click();

            return labelModalComponent;
        }

        public static bool IsLabelModalDisplayed(this LabelModalComponent labelModalComponent)
        {
            return labelModalComponent.LabelModal.Displayed;
        }

    }
}
