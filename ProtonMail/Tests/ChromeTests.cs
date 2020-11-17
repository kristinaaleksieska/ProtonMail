using NUnit.Framework;
using ProtonMail.TestBase;
using ProtonMail.Tests.CommonTestHelper;

namespace ProtonMail.Tests
{
    [TestFixture]
    public class ChromeTests : ChromeTestBase
    {
        [Test, Category("ChromeDriver"), Category("FolderComponent")]
        public void WhenProtomMailPageIsOpenedNestingOfFoldersIsEnabledAndMaximumFolderLimitCanNotBeExceeded()
        {
            FoldersAndLabelsPage.WhenProtomMailPageIsOpenedNestingOfFoldersIsEnabledAndMaximumFolderLimitCanNotBeExceeded();
        }

        [Test, Category("ChromeDriver"), Category("FolderComponent")]
        public void WhenProtonMailPageIsOpenedFolderEditingIsEnabled()
        {
            FoldersAndLabelsPage.WhenProtonMailPageIsOpenedFolderEditingIsEnabled();
        }

        [Test, Category("ChromeDriver"), Category("FolderComponent")]
        public void WhenProtonMailPageIsOpenedAndFolderWithSameNameAsExistingFolderOnTheSameLevelFolderCanNotBeAdded()
        {
            FoldersAndLabelsPage.WhenProtonMailPageIsOpenedAndFolderWithSameNameAsExistingFolderOnTheSameLevelFolderCanNotBeAdded();
        }

        [Test, Category("ChromeDriver"), Category("FolderComponent")]
        public void WhenProtonMailPageIsOpenedAndFolderWithSameNameAsExistingCanBeAddedOnADifferentLevel()
        {
            FoldersAndLabelsPage.WhenProtonMailPageIsOpenedAndFolderWithSameNameAsExistingCanBeAddedOnADifferentLevel();
        }

        [Test, Category("ChromeDriver"), Category("FolderComponent")]
        public void WhenProtonMailPageIsOpenedFolderNotificationsCanBeDisabled()
        {
            FoldersAndLabelsPage.WhenProtonMailPageIsOpenedFolderNotificationsCanBeDisabled();
        }

        [Test, Category("ChromeDriver"), Category("FolderComponent"), Category("LabelComponent")]
        public void WhenProtonMailPageIsOpenedLabelWithNameSameAsExistingFolderCanNotBeAdded()
        {
            FoldersAndLabelsPage.WhenProtonMailPageIsOpenedLabelWithNameSameAsExistingFolderCanNotBeAdded();
        }

        [Test, Category("ChromeDriver"), Category("LabelComponent")]
        public void WhenProtonMailPageIsOpenedLabelWithSameNameAsExistingCanNotBeAdded()
        {
            FoldersAndLabelsPage.WhenProtonMailPageIsOpenedLabelWithSameNameAsExistingCanNotBeAdded();
        }
        
        [Test, Category("ChromeDriver"), Category("LabelComponent")]
        public void WhenProtonMailPageIsOpenedLabelEditingIsEnabled()
        {
            FoldersAndLabelsPage.WhenProtonMailPageIsOpenedLabelEditingIsEnabled();
        }        
    } 
}
