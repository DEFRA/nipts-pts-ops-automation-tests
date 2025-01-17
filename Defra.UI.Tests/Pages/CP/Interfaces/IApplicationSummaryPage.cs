namespace Defra.UI.Tests.Pages.CP.Interfaces
{
    public interface IApplicationSummaryPage
    {
       bool VerifyTheExpectedStatus(string status);
       void SelectPassRadioButton();
       void SelectFailRadioButton();
       void SelectSaveAndContinue();
       bool IsError(string errorMessage);
       bool VerifyTheBannerColor(string color);
        bool VerifyReferenceNumberTable(string Status);
    }
}