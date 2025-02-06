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
        bool VerifyRefNumTableValues(string values, string status);
        bool VerifyMCTableValues(string values, string status);
        bool VerifyPetDetailsValues(string values, string species);
        bool VerifyPetOwnerDetailsValues(string values);
    }
}