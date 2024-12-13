namespace Defra.UI.Tests.Pages.AP.Interfaces
{
    public interface IPetMicrochipPage
    {
        bool IsNextPageLoaded(string pageTitle);
        void SelectMicrochippedOption(string option);
        string EnterMicrochipNumber();
        string EnterGivenMicrochipNumber(string microChipNumber);
        void UpdateMicrochipNumber(string microChipNumber);
        void ClickContinueButton();
        bool IsError(string errorMessage);
    }
}