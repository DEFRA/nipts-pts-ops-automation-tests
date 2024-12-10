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
    }
}