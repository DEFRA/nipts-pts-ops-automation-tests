namespace Defra.UI.Tests.Pages.CP.Interfaces
{
    public interface IApplicationSummaryPage
    {
       bool VerifyTheExpectedStatus(string status);
       void SelectPassRadioButton();
       void SelectFailRadioButton();
       void SelectSaveAndContinue();
       bool IsError(string errorMessage);
        bool VerifyReferenceNumberTable(string status);
        bool VerifyTheBannerColor(string color);
        bool VerifyMicrochipInformationTable();
        bool VerifyPetDetailsTable(string species);
        bool VerifyPetOwnerDetailsTable();
        bool VerifyIssuingAuthorityTable(string status);
    }
}