using DocumentFormat.OpenXml.Wordprocessing;
using System.Security.Cryptography;

namespace Defra.UI.Tests.Pages.AP.Interfaces
{
    public interface IHomePage
    {
        bool IsPageLoaded();
        void ClickApplyForPetTravelDocument();
        void ClickFeedbackLink();
        bool IsNextPageLoaded(string pageTitle);
        void ClickGethelpLink();
        void ClickAccessibilityStatementLink();
        void ClickCookiesLink();
        void ClickPrivacyNoticeLink();
        void ClickTermsAndConditionsLink();
        void ClickCrownCopyrightLink();
        bool VerifyTheExpectedStatus(string petName, string status);
        bool VerifyTheApplicationIsNotAvailable(string PetName);
        void ClickViewLink(string petName);
        void ClickOnManageAccountLink();
        void ClickSignOutLink();
        bool VerifyTheLinkOpensInSameTab();
        bool VerifyInvalidDocumentsLink();
        void ClickInvalidDocumentsLink();
        bool InvalidDocsTableHeadings(string petName, string status);
        bool InvalidDocsTablePTDStatus();
        bool InvalidDocsTableViewLink();
        void CloseCurrentTabAndSwitchBack();
        bool IsInvalidDocumentsPageLoaded(string pageTitle);
        bool VerifyManageAccAndSignOutNotVisible();
        bool VerifySuspensionWarning();
        bool VerifyApplyButtonNotVisible();
    }
}