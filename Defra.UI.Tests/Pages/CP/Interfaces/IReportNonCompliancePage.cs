namespace Defra.UI.Tests.Pages.CP.Interfaces
{
    public interface IReportNonCompliancePage
    {
        bool IsPageLoaded();
        void SelectReportNonComplianceButton();
        void ClickPetTravelDocumentDetailsLnk();
        bool VerifyTheExpectedStatus(string status);
        void SelectTypeOfPassenger(string radioButtonValue);
        bool IsError(string errorMessage);
        bool CheckPetTravelDocumentDetailsSection(string status);
        bool VerifyTheTableNameInPTDLink(string tableName);
        bool VerifyReasonsHeadingWithHint(string reasons, string hint);
        bool VerifyGBOutcomeCheckboxes(string checkboxValues);
        bool VerifySPSOutcomeCheckboxes(string checkboxValues);
        bool VerifyDetailsOfOutcome();
        bool VerifyMaxLengthOfDetailsOfOutcomeTextarea(string maxLength);
        bool VerifyThePTDNumber(string ptdNumber);
        bool VerifyTheDateOfIssuance(string dateOfIssuance);
        bool VerifyTheReferenceNumber(string refereneNumber);
        bool VerifyTableNameForApprovedAndRevokedInPTDLink(string tableName);
    }
}