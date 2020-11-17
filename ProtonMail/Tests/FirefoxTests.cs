using NUnit.Framework;
using ProtonMail.TestBase;
using ProtonMail.Tests.CommonTestHelper;

namespace ProtonMail.Tests
{
    [TestFixture]
    public class FirefoxTests : FirefoxTestBase
    {

        [Test, Category("FirefoxDriver"), Category("FolderComponent")]
        public void WhenProtomMailPageIsOpenedNestingOfFoldersIsEnabledAndMaximumFolderLimitCanNotBeExceeded()
        {
            FoldersAndLabelsPage.WhenProtomMailPageIsOpenedNestingOfFoldersIsEnabledAndMaximumFolderLimitCanNotBeExceeded();
        }

        [Test, Category("FirefoxDriver"), Category("FolderComponent")]
        public void WhenProtonMailPageIsOpenedFolderEditingIsEnabled()
        {
            FoldersAndLabelsPage.WhenProtonMailPageIsOpenedFolderEditingIsEnabled();
        }

        [Test, Category("FirefoxDriver"), Category("FolderComponent")]
        public void WhenProtonMailPageIsOpenedAndFolderWithSameNameAsExistingFolderOnTheSameLevelFolderCanNotBeAdded()
        {
            FoldersAndLabelsPage.WhenProtonMailPageIsOpenedAndFolderWithSameNameAsExistingFolderOnTheSameLevelFolderCanNotBeAdded();
        }

        [Test, Category("FirefoxDriver"), Category("FolderComponent")]
        public void WhenProtonMailPageIsOpenedAndFolderWithSameNameAsExistingCanBeAddedOnADifferentLevel()
        {
            FoldersAndLabelsPage.WhenProtonMailPageIsOpenedAndFolderWithSameNameAsExistingCanBeAddedOnADifferentLevel();
        }

        [Test, Category("FirefoxDriver"), Category("FolderComponent")]
        public void WhenProtonMailPageIsOpenedFolderNotificationsCanBeDisabled()
        {
            FoldersAndLabelsPage.WhenProtonMailPageIsOpenedFolderNotificationsCanBeDisabled();
        }

        [Test, Category("FirefoxDriver"), Category("FolderComponent"), Category("LabelComponent")]
        public void WhenProtonMailPageIsOpenedLabelWithNameSameAsExistingFolderCanNotBeAdded()
        {
            FoldersAndLabelsPage.WhenProtonMailPageIsOpenedLabelWithNameSameAsExistingFolderCanNotBeAdded();
        }

        [Test, Category("FirefoxDriver"), Category("LabelComponent")]
        public void WhenProtonMailPageIsOpenedLabelWithSameNameAsExistingCanNotBeAdded()
        {
            FoldersAndLabelsPage.WhenProtonMailPageIsOpenedLabelWithSameNameAsExistingCanNotBeAdded();
        }

        [Test, Category("FirefoxDriver"), Category("LabelComponent")]
        public void WhenProtonMailPageIsOpenedLabelEditingIsEnabled()
        {
            FoldersAndLabelsPage.WhenProtonMailPageIsOpenedLabelEditingIsEnabled();
        }
    }
}
